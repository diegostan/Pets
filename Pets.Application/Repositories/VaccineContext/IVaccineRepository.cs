using Pets.Domain.Entities.VaccineContext;
using System.Threading.Tasks; 
using System.Collections.Generic;
using Pets.Application.Output.DTO;
using System;

namespace Pets.Application.Repositories.VaccineContext
{
    public interface IVaccineRepository
    {
        void InsertVaccine(Vaccine vaccine);
        Task<IEnumerable<VaccineDTO>> GetAllVaccinesByCategoryIdAsync(Guid id);
        Task<IEnumerable<VaccineDTO>> GetAllVaccinesByPetIdAsync(Guid id);

    }
}