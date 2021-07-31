using System;
using Pets.Domain.Entities.VaccineContext;

namespace Pets.Infrastructure.Queries
{
    public static class CategoryQueries
    {
        private static string _table;
        private static string _query;

        public static string GetAllCategories()
        {
            _table = Map.ContextMapping.GetCategoryTable();
            _query = $@"
            SELECT [Id], [Description], [DateCreated] FROM [Category]
            ";
            return _query;
        }

        public static string InsertCategory(Category category)
        {
            _table = Map.ContextMapping.GetCategoryTable();
            _query = $@"
            INSERT INTO {_table}
            VALUES 
            ('{category.Id}', 
            '{category.Description}', 
            '{category.DateCreated.ToString("yyyy-dd-MM HH:mm:ss")}')
            ";

            return _query;
        }

        public static string DeleteCategoryById(Guid categoryId)
        {
            _table = Map.ContextMapping.GetCategoryTable();
            _query = $@"
            DELETE [Category] WHERE [Id] = '{categoryId}'
            ";

            return _query;
        }
    }
}