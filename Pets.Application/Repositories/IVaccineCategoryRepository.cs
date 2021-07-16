using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pets.Application.Output.Requests.PetsRequests;
using Pets.Application.Output.Requests.VaccineRequest;

namespace Pets.Application.Repositories
{
    public interface IVaccineCategoryRepository
    {
        Task<IEnumerable<VaccineCategoryRequest>> GetAllVaccinesByCategoryIdAsync(Guid categoryId);
    }
}