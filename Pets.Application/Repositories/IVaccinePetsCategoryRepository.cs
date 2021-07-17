using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pets.Application.Output.Requests.PetsRequests;
using Pets.Application.Output.Requests.VaccineRequest;

namespace Pets.Application.Repositories
{
    public interface IVaccinePetsCategoryRepository
    {
        Task<IEnumerable<VaccinePetsCategoryRequest>> GetAllVaccinesByCategoryIdAsync(Guid categoryId);
    }
}