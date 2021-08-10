using Pets.Domain.Entities.VaccineContext;
using System.Threading.Tasks; 
using System.Collections.Generic;
using Pets.Application.Output.DTO;
using System;
using Pets.Application.Output.Requests.VaccineRequest;

namespace Pets.Application.Repositories.VaccineContext
{
    public interface IVaccineRepository
    {
        Task<VaccineRequest> GetVaccinesByPetIdAsync(Guid petId);
        void InsertVaccine(Vaccine vaccine);        

    }
}