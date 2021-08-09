using System.Data;
using Microsoft.Data.SqlClient;
using Pets.Application.AbsFactory;
using Pets.Application.AbsFactory.Products;
using Pets.Infrastructure.Factory.Products;

namespace Pets.Infrastructure.Factory
{
    public class SqlFactory : AbsDBFactory
    {
        private readonly string connectionString;
        public SqlFactory()
        {
            connectionString = ContextMapping.Secret.GetSqlServerConnectionStringProd();
        }

        public override DbConnection GetPostgreSqlConnection()
        {
            return new PostgreSqlConnectionProduct();
        }

        public override DbConnection GetSqlConnection()
        {
            return new SqlConnectionProduct();
        }        
    }
}