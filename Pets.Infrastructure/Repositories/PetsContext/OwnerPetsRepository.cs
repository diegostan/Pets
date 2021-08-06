using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pets.Application.AbsFactory;
using Pets.Application.Output.DTO;
using Pets.Application.Output.Requests.PetsRequests;
using Pets.Application.Output.Results;
using Pets.Application.Repositories.PetsContext;

namespace Pets.Infrastructure.Repositories.PetsContext
{
    public class OwnerPetsRepository : IOwnerPetsRepository
    {
        private readonly OwnerRepository _ownerRepository;
        private readonly PetRepository _petRepository;
        private readonly AbsDBFactory _factory;
        public OwnerPetsRepository(AbsDBFactory factory)
        {
            _factory = factory;
            _ownerRepository = new OwnerRepository(_factory);
            _petRepository = new PetRepository(_factory);
        }
        public async Task<OwnerPetsRequest> GetOwnerPetsByDocumentAsync(string document)
        {
            var ownerPets = new OwnerPetsRequest();
            try
            {
                var owner = await _ownerRepository.GetOwnerByDocumentAsync(document);
                var pets = await _petRepository.GetPetsByOwnerIdAsync(owner.Owner.Id);
                ownerPets.Owner = owner.Owner;
                ownerPets.Pets = (pets.Pets as List<PetDTO>);
                if (ownerPets.Owner.DocumentNumber == null)
                {                    
                    ownerPets.Result = new Result(404, "Não foram encontrados donos com esse documento", false);
                    return ownerPets;
                }
                if (ownerPets.Pets.Count <= 0)
                {                    
                    ownerPets.Result = new Result(404, "Não foram encontrados pets associados a esse dono", false);
                    return ownerPets;
                }
                
                ownerPets.Result = new Result(200, "Requisição realizada com sucesso", true);                
                return ownerPets;

            }
            catch (Exception ex)
            {
                ownerPets.Result = new Result(500, $"Erro interno do servidor, detalhes: {ex.Message}", false);
                return ownerPets;
            }
        }
    }
}