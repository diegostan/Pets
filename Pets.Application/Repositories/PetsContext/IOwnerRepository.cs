using System.Threading.Tasks;
using Pets.Domain.Entities.PetsContext;
using Pets.Application.Output.Requests.PetsRequests;

namespace Pets.Application.Repositories.PetsContext
{
    public interface IOwnerRepository
    {
        void InsertOwner(Owner owner);
        Task<OwnerRequest> GetOwnerByDocumentAsync(string document);
        Task<OwnerRequest> GetOwnerByEmailAsync(string email);
        
    }
}