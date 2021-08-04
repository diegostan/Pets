using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Pets.Application.Output.DTO;
using Pets.Application.Repositories.VaccineContext;
using Pets.Domain.Entities.VaccineContext;
using Dapper;
using Pets.Application.Output.Results;
using Pets.Application.Output.Requests.VaccineRequest;
using Pets.Application.AbsFactory;
using Dapper.Contrib.Extensions;
using Pets.Infrastructure.Queries;

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

        public async Task<CategoryRequest> GetAllCategoriesAsync()
        {
            var categoryRequest = new CategoryRequest();
            try
            {
                using (_connection)
                {
                    categoryRequest.Categories = await _connection.QueryAsync<CategoryDTO>(Queries.CategoryQueries.GetAllCategories()) as List<CategoryDTO>;
                    categoryRequest.Result = (categoryRequest.Categories as List<CategoryDTO>).Count !=0 ? new Result(200, "Requisição realizada com sucesso", true)
                    : new Result(404, "Nenhuma categoria encontrada", false);
                    return categoryRequest;
                }
            }
            catch (Exception ex)
            {
                categoryRequest.Result = new Result(500, $"Erro interno do servidor, detalhes: {ex.Message}", false);
            }
            return categoryRequest;
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