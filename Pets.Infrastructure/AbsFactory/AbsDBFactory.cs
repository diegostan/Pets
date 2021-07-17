using System.Data;

namespace Pets.Infrastructure.AbsFactory
{
    public abstract class AbsDBFactory
    {
        public abstract IDbConnection CreateConnection();
    }
}