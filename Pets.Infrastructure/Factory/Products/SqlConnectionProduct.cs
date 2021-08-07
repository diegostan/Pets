using System.Data;
using Microsoft.Data.SqlClient;
using Pets.Application.AbsFactory.Products;

namespace Pets.Infrastructure.Factory.Products
{
    public class SqlConnectionProduct : DbConnection
    {
        private readonly string _connectionString;
        public SqlConnectionProduct()
        {
            _connectionString = Map.Secret.GetSqlServerConnectionString();
        }
        public override IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}