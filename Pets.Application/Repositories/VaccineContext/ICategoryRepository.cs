using Pets.Application.Output.DTO;
using Pets.Domain.Entities.VaccineContext;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pets.Application.Repositories.VaccineContext
{
    public interface ICategoryRepository
    {
        void InsertCategory(Category category);
        Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync();
    }
}