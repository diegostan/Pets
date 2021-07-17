using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Pets.Application.Output.DTO;
using Pets.Application.Repositories.VaccineContext;
using Pets.Domain.Entities.VaccineContext;
using Pets.Infrastructure.AbsFactory;
using Dapper;
using Pets.Application.Output.Results;

namespace Pets.Infrastructure.Repositories.VaccineContext
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbConnection _connection;
        public CategoryRepository(AbsDBFactory factory)
        {
            _connection = factory.CreateConnection();
        }

        public void DeleteCategory(Guid categoryId)
        {
            using (_connection)
            {
                _connection.Execute(Queries.CategoryQueries.DeleteCategoryById(categoryId));
            }
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
        {
            using (_connection)
            {
                var request = await _connection.QueryAsync<CategoryDTO>(Queries.CategoryQueries.GetAllCategories());
                return request;
            }
        }

        public void InsertCategory(Category category)
        {
            using (_connection)
            {
                _connection.Execute(Queries.CategoryQueries.InsertCategory(category));
            }
        }
    }
}