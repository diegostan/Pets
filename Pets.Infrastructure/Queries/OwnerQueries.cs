using Pets.Domain.Entities.PetsContext;

namespace Pets.Infrastructure.Queries
{
    public static class OwnerQueries
    {
        private static string _table;
        private static string _query;
        public static string GetOwnerByDocument(string document)
        {
            _table = Map.ContextMapping.GetOwnerTable();
            _query = $@"SELECT TOP 1 * FROM {_table} WHERE [DocumentNumber] = '{document}'";
            return _query;
        }

        public static string GetOwnerByEmail(string email)
        {
            _table = Map.ContextMapping.GetOwnerTable();
            _query = $@"SELECT TOP 1 * FROM [Owner] WHERE [Email] = '12356875898'";
            return _query;
        }

        public static string InsertOwner(Owner owner)
        {
            _table = Map.ContextMapping.GetOwnerTable();
            _query = $@"
            INSERT INTO {_table}             
            VALUES 
            ('{owner.Id}', 
            '{owner.Name.FirstName}', 
            '{owner.Name.LastName}', 
            '{owner.Document.DocumentNumber}', 
             {owner.Document.DocumentType}, 
            '{owner.Email}', 
            {owner.DateCreated.ToString("yyyy-MM-dd HH:mm:ss")}
            )";

            return _query;
        }
    }
}