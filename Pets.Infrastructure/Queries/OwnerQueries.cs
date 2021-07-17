using System;
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
            _query = $@"SELECT TOP 1 * FROM [Owner] WHERE [Email] = '{email}'";
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
             {Convert.ToInt16(owner.Document.DocumentType)}, 
            '{owner.Email}', 
            '{owner.DateCreated.ToString("yyyy-dd-MM hh:mm:ss")}'
            )";

            return _query;
        }
    }
}