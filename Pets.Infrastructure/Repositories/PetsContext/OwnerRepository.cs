using System;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Pets.Application.AbsFactory;
using Pets.Application.Output.DTO;
using Pets.Application.Output.Requests.PetsRequests;
using Pets.Application.Output.Results;
using Pets.Application.Output.Results.Interfaces;
using Pets.Application.Repositories.PetsContext;
using Pets.Domain.Entities.PetsContext;

namespace Pets.Infrastructure.Repositories.PetsContext
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly IDbConnection _connection;
        public OwnerRepository(AbsDBFactory factory)
        {
            _connection = factory.CreateConnection();
        }

        public IResultBase DeleteOwnerById(Guid ownerId)
        {
            try
            {
                using (_connection)
                {
                    if (_connection.Execute(Queries.OwnerQueries.DeleteOwnerById(ownerId)) > 0)
                        return new Result(200, "Dono apagado com sucesso", true);

                    return new Result(404, "Não foram encontrados donos com esse ID", true);
                }
            }
            catch (Exception ex)
            {
                return new Result(500, $"Erro interno ao tentar apagar dono. Mais detalhes: {ex.Message}", false);
            }
        }

        public async Task<OwnerRequest> GetOwnerByDocumentAsync(string document)
        {
            var ownerRequest = new OwnerRequest();

            using (_connection)
            {
                try
                {
                    ownerRequest.Owner = await _connection.QueryFirstOrDefaultAsync<OwnerDTO>(Queries.OwnerQueries.GetOwnerByDocument(document));
                    ownerRequest.Result = (ownerRequest.Owner.DocumentNumber != null ? new Result(200, $"Requisição realizada com sucesso", true)
                    : new Result(404, $"Não foram encontrados donos com esse numero de documento.", true));
                }
                catch (Exception ex)
                {
                    ownerRequest.Result = new Result(500, $"Erro interno do servidor, detalhes: {ex.Message}", false);
                }
            }
            return ownerRequest;
        }

        public async Task<OwnerRequest> GetOwnerByEmailAsync(string email)
        {
            var ownerRequest = new OwnerRequest();

            using (_connection)
            {
                try
                {
                    ownerRequest.Owner = await _connection.QueryFirstOrDefaultAsync<OwnerDTO>(Queries.OwnerQueries.GetOwnerByEmail(email));
                     ownerRequest.Result = (ownerRequest.Owner.DocumentNumber != null ? new Result(200, $"Requisição realizada com sucesso", true)
                    : new Result(404, $"Não foram encontrados donos com esse e-mail.", true));
                    
                }
                catch (Exception ex)
                {
                    ownerRequest.Result = new Result(500, $"Erro interno do servidor, detalhes: {ex.Message}", false);
                }
            }
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