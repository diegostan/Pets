using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Pets.Application.Output.DTO;
using Pets.Application.Repositories.PetsContext;
using Pets.Domain.Entities.PetsContext;
using Pets.Infrastructure.AbsFactory;

namespace Pets.Infrastructure.Repositories.PetsContext
{
    public class PetRepository : IPetRepository
    {
        private readonly IDbConnection _connection;
        public PetRepository(AbsDBFactory factory)
        {
            _connection = factory.CreateConnection();
        }
        public async Task<IEnumerable<PetDTO>> GetPetsByOwnerIdAsync(Guid id)
        {
            using (_connection)
            {
                var pets = await _connection.QueryAsync<PetDTO>(Queries.PetQueries.GetPetsByOwnerId(id));
                return pets;
            }
        }

        public void InsertPet(Pet pet)
        {
            using (_connection)
            {
                _connection.Execute(Queries.PetQueries.InsertPet(pet));
            }

        }
    }
}