using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Pets.Application.Output.DTO;
using Pets.Application.Output.Requests.PetsRequests;
using Pets.Application.Output.Results;
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
        public async Task<PetRequest> GetPetsByOwnerIdAsync(Guid id)
        {
            var petRequest = new PetRequest();

            using (_connection)
            {
                try
                {
                    petRequest.Pets = await _connection.QueryAsync<PetDTO>(Queries.PetQueries.GetPetsByOwnerId(id));
                    petRequest.Result = new Result(200, $"Requisição realizada com sucesso", true);
                }
                catch (Exception ex)
                {
                    petRequest.Result = new Result(500, $"Erro interno do servidor, detalhes: {ex.Message}", false);
                }

            }

            if((petRequest.Pets as List<PetDTO>).Count == 0)
                    petRequest.Result = new Result(404, $"Não foram encontrados pets vinculados a esse dono.", true);

            return petRequest;
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