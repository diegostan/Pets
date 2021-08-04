using System;
using Pets.Domain.Entities.VaccineContext;


namespace Pets.Infrastructure.Queries
{
    public static class CategoryQueries
    {
        private static string _table;
        private static string _query;
        private static object _parameters;

        public static object GetAllCategories()
        {
            _table = Map.ContextMapping.GetCategoryTable();
            _query = $@"
            SELECT [Id], [Description], [DateCreated] FROM {_table}";
            return _query.ToString();
        }

        public static object[] InsertCategory(Category category)
        {
            _table = Map.ContextMapping.GetCategoryTable();
            _query = $@"
            INSERT INTO {_table}
            VALUES (@Id, @Description, @DateCreated)";
            _parameters = new
            {
                Id = category.Id,
                Description = category.Description,
                DateCreated = category.DateCreated.ToString("yyyy-dd-MM HH:mm:ss")
            };
            return new object[] { _query, _parameters };
        }

        public static object[] DeleteCategoryById(Guid categoryId)
        {
            _table = Map.ContextMapping.GetCategoryTable();
            _query = $@"
            DELETE {_table} WHERE [Id] = @CategoryId";
            _parameters = new
            {
                CategoryId = categoryId
            };
            return new object[] { _query, _parameters };            
        }
    }
}