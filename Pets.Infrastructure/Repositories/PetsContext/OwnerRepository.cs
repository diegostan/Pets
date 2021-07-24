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
    public class OwnerRepository : IOwnerRepository
    {
        private readonly IDbConnection _connection;
        public OwnerRepository(AbsDBFactory factory)
        {
            _connection = factory.CreateConnection();
        }
        public async Task<OwnerRequest> GetOwnerByDocumentAsync(string document)
        {
            var ownerRequest = new OwnerRequest();

            using (_connection)
            {
                try
                {
                    ownerRequest.Owner = await _connection.QueryFirstOrDefaultAsync<OwnerDTO>(Queries.OwnerQueries.GetOwnerByDocument(document));
                    ownerRequest.Result = new Result(200, $"Requisição realizada com sucesso", true);
                }
                catch (Exception ex)
                {
                    ownerRequest.Result = new Result(500, $"Erro interno do servidor, detalhes: {ex.Message}", false);
                }

            }

            if(ownerRequest.Owner.DocumentNumber == null)
                    ownerRequest.Result = new Result(404, $"Não foram encontrados donos com esse numero de documento.", true);

            return ownerRequest;
        }

        public async Task<OwnerRequest> GetOwnerByEmailAsync(string email)
        {
            // Camada de repositorio não tem a responsabilidade de tratar Exceptions------------------------------------------------------------------------------------------------------------------------
            var ownerRequest = new OwnerRequest();

            using (_connection)
            {
                try
                {
                    ownerRequest.Owner = await _connection.QueryFirstOrDefaultAsync<OwnerDTO>(Queries.OwnerQueries.GetOwnerByEmail(email));
                    ownerRequest.Result = new Result(200, $"Requisição realizada com sucesso", true);
                }
                catch (Exception ex)
                {
                    ownerRequest.Result = new Result(500, $"Erro interno do servidor, detalhes: {ex.Message}", false);
                }

            }

            if(ownerRequest.Owner.DocumentNumber == null)
                    ownerRequest.Result = new Result(404, $"Não foram encontrados donos com esse email.", true);

            return ownerRequest;
        }

        public void InsertOwner(Owner owner)
        {
            using (_connection)
            {
                _connection.Execute(Queries.OwnerQueries.InsertOwner(owner));
            }
        }
    }
}