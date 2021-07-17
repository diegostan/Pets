using System.Data;
using Pets.Application.Repositories.VaccineContext;
using Pets.Domain.Entities.VaccineContext;
using Pets.Infrastructure.AbsFactory;
using Dapper;

namespace Pets.Infrastructure.Repositories.VaccineContext
{
    public class VaccineRepository : IVaccineRepository
    {
        private readonly IDbConnection _connection;
        public VaccineRepository(AbsDBFactory factory)
        {
            _connection = factory.CreateConnection();
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