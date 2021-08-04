using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Pets.Application.AbsFactory;
using Pets.Application.Output.DTO;
using Pets.Application.Output.Requests.PetsRequests;
using Pets.Application.Output.Results;
using Pets.Application.Repositories.PetsContext;
using Pets.Domain.Entities.PetsContext;


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
                    var query = Queries.PetQueries.GetPetsByOwnerId(id);
                    petRequest.Pets = await _connection.QueryAsync<PetDTO>(query[0].ToString(), query[1]);
                    petRequest.Result = ((petRequest.Pets as List<PetDTO>).Count != 0 ? new Result(200, $"Requisição realizada com sucesso", true) 
                    :new Result(404, $"Não foram encontrados pets vinculados a esse dono.", true));
                }
                catch (Exception ex)
                {
                    petRequest.Result = new Result(500, $"Erro interno do servidor, detalhes: {ex.Message}", false);
                }
            }
            return petRequest;
        }

        public void InsertPet(Pet pet)
        {
            using (_connection)
            {
                var query= Queries.PetQueries.InsertPet(pet);
                _connection.Execute(query[0].ToString(), query[1]);
            }

        }
    }
}