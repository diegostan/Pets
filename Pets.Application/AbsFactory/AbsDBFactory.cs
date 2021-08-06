using System.Data;
using Pets.Application.AbsFactory.Products;

namespace Pets.Application.AbsFactory
{
    public abstract class AbsDBFactory
    {
        public abstract DbConnection GetConnection();
        
    }
}