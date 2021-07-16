using System.Collections.Generic;
using System.Threading.Tasks;
using Pets.Application.Output.DTO;
using Pets.Domain.Entities.PetsContext;

namespace Pets.Application.Repositories.PetsContext
{
    public interface IOwnerRepository
    {
        void InsertOwner(Owner owner);
        Task<IEnumerable<OwnerDTO>> GetOwnersByDocumentAsync(string document);
        Task<IEnumerable<OwnerDTO>> GetOwnersByEmailAsync(string email);
        
    }
}