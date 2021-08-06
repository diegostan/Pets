using System.Collections.Generic;
using System.Threading.Tasks;
using Pets.Application.Output.Requests.PetsRequests;

namespace Pets.Application.Repositories.PetsContext
{
    public interface IOwnerPetsRepository
    {
        Task<OwnerPetsRequest> GetOwnerPetsByDocumentAsync(string document);
    }
}