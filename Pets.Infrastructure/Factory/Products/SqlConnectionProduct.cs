using System.Data;
using Microsoft.Data.SqlClient;
using Pets.Application.AbsFactory.Products;

namespace Pets.Infrastructure.Factory.Products
{
    public class SqlConnectionProduct : DbConnection
    {
        private readonly string connectionString;
        public SqlConnectionProduct()
        {
            connectionString = Map.Secret.GetConnectionString();
        }
        public override IDbConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}