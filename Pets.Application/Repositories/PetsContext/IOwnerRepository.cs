using System.Collections.Generic;
using System.Threading.Tasks;
using Pets.Application.Output.DTO;
using Pets.Domain.Entities.PetsContext;
using Pets.Application.Output.Results;

namespace Pets.Application.Repositories.PetsContext
{
    public interface IOwnerRepository
    {
        void InsertOwner(Owner owner);
        Task<OwnerDTO> GetOwnerByDocumentAsync(string document);
        Task<OwnerDTO> GetOwnerByEmailAsync(string email);
        
    }
}