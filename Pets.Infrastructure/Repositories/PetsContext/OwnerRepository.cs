using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Pets.Application.Output.DTO;
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
        public async Task<OwnerDTO> GetOwnerByDocumentAsync(string document)
        {
            using (_connection)
            {
                var owner = await _connection.QueryFirstOrDefaultAsync<OwnerDTO>(Queries.OwnerQueries.GetOwnerByDocument(document));
                return owner;
            }
        }

        public async Task<OwnerDTO> GetOwnerByEmailAsync(string email)
        {            
            using (_connection)
            {
                var owner = await _connection.QueryFirstOrDefaultAsync<OwnerDTO>(Queries.OwnerQueries.GetOwnerByEmail(email));
                return owner;
            }            
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