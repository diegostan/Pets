using System.Data;

namespace Pets.Application.AbsFactory
{
    public abstract class AbsDBFactory
    {
        public abstract IDbConnection CreateConnection();
    }
}