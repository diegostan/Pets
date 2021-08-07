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
            _connection = factory.GetSqlConnection().CreateConnection();
        }

        public IResultBase DeleteOwnerById(Guid ownerId)
        {
            try
            {
                using (_connection)
                {
                    var query = Queries.OwnerQueries.DeleteOwnerById(ownerId);
                    if (_connection.Execute(query[0].ToString(), query[1]) > 0)
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
                    var query = Queries.OwnerQueries.GetOwnerByDocument(document);
                    ownerRequest.Owner = await _connection.QueryFirstOrDefaultAsync<OwnerDTO>(query[0].ToString(), query[1]);
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
                    var query = Queries.OwnerQueries.GetOwnerByEmail(email);
                    ownerRequest.Owner = await _connection.QueryFirstOrDefaultAsync<OwnerDTO>(query[0].ToString(), query[1]);
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
                var query = Queries.OwnerQueries.InsertOwner(owner);
                _connection.Execute(query[0].ToString(), query[1]);
            }
        }
    }
}