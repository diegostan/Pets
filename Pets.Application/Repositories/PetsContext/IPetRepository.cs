using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pets.Application.Output.Requests.PetsRequests;
using Pets.Domain.Entities.PetsContext;

namespace Pets.Application.Repositories.PetsContext
{
    public interface IPetRepository
    {
        void InsertPet(Pet pet);
        Task<PetRequest> GetPetsByOwnerIdAsync(Guid id);
    }
}