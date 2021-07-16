using System.Collections.Generic;
using System.Threading.Tasks;
using Pets.Application.Output.Requests.PetsRequests;

namespace Pets.Application.Repositories
{
    public interface IOwnerPetsRepository
    {
        Task<IEnumerable<OwnerPetsRequest>> GetOwnerPetsByDocumentAsync(string document);
    }
}