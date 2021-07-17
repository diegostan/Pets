using System.Data;
using Microsoft.Data.SqlClient;
using Pets.Infrastructure.AbsFactory;

namespace Pets.Infrastructure.Factory
{
    public class SqlFactory : AbsDBFactory
    {
        private readonly string connectionString;
        public SqlFactory()
        {
            connectionString = Map.Secret.GetConnectionString();
        }
        public override IDbConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}