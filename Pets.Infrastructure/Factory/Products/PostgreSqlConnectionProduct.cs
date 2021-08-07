using System.Data;
using Pets.Application.AbsFactory.Products;

namespace Pets.Infrastructure.Factory.Products
{
    public class PostgreSqlConnectionProduct : DbConnection
    {
        private readonly string _connectionString;
        public PostgreSqlConnectionProduct()
        {
            _connectionString = Map.Secret.GetPostgreSqlConnectionString();
        }
        public override IDbConnection CreateConnection()
        {
            return new Npgsql.NpgsqlConnection(_connectionString);
        }
    }
}