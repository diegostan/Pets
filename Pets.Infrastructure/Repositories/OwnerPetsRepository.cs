using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Pets.Application.AbsFactory;
using Pets.Application.Output.DTO;
using Pets.Application.Output.Requests.PetsRequests;
using Pets.Application.Repositories;
using Pets.Infrastructure.Repositories.PetsContext;

namespace Pets.Infrastructure.Repositories
{
    public class OwnerPetsRepository : IOwnerPetsRepository
    {
        private readonly IDbConnection _connection;
        private readonly OwnerRepository _ownerRepository;
        private readonly PetRepository _petRepository;
        public OwnerPetsRepository(AbsDBFactory factory)
        {
            _connection = factory.CreateConnection();            
            _ownerRepository = new OwnerRepository(_connection);
            _petRepository = new PetRepository(_connection);
        }
        public async Task<OwnerPetsRequest> GetOwnerPetsByDocumentAsync(string document)
        {
            
            var ownerPets = new OwnerPetsRequest();
            ownerPets.Owner = _ownerRepository.GetOwnerByDocumentAsync(document).GetAwaiter().GetResult().Owner;
            ownerPets.Pets = _petRepository.GetPetsByOwnerIdAsync(ownerPets.Owner.Id).GetAwaiter().GetResult().Pets as List<PetDTO>;
            return ownerPets;            
        }
    }
}