using System.Data;
using Pets.Application.AbsFactory.Products;

namespace Pets.Infrastructure.Factory.Products
{
    public class PostgreSqlConnectionProduct : DbConnection
    {
        private readonly string _connectionString;
        public PostgreSqlConnectionProduct()
        {
            _connectionString = ContextMapping.Secret.GetPostgreSqlConnectionStringProd();
        }
        public override IDbConnection CreateConnection()
        {
            return new Npgsql.NpgsqlConnection(_connectionString);
        }
    }
}