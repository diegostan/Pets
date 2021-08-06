using System.Data;
using Pets.Application.Repositories.VaccineContext;
using Pets.Domain.Entities.VaccineContext;
using Dapper;
using Pets.Application.AbsFactory;

namespace Pets.Infrastructure.Repositories.VaccineContext
{
    public class VaccineRepository : IVaccineRepository
    {
        private readonly IDbConnection _connection;
        public VaccineRepository(AbsDBFactory factory)
        {
            _connection = factory.GetConnection().CreateConnection();
        }
        public void InsertVaccine(Vaccine vaccine)
        {
            using (_connection)
            {
                _connection.Execute(Queries.VaccineQueries.InsertVaccine(vaccine));
            }
        }
    }
}