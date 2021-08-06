using System.Data;

namespace Pets.Application.AbsFactory.Products
{
    public abstract class DbConnection
    {
        public abstract IDbConnection CreateConnection();
    }
}