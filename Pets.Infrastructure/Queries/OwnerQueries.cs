using System;
using Pets.Domain.Entities.PetsContext;

namespace Pets.Infrastructure.Queries
{
    public static class OwnerQueries
    {
        private static string _table;
        private static string _query;
        private static object _parameters;
        public static object[] GetOwnerByDocument(string document)
        {
            _table = Map.ContextMapping.GetOwnerTable();
            _query = $@"SELECT * FROM {_table} WHERE DocumentNumber = @Document";
            _parameters = new { Document = document };
            return new object[] { _query, _parameters };
        }

        public static object[] GetOwnerByEmail(string email)
        {
            _table = Map.ContextMapping.GetOwnerTable();
            _query = $"SELECT * FROM {_table} WHERE Email = @Email";
            _parameters = new { Email = email };
            return new object[] { _query, _parameters };
        }

        public static object[] InsertOwner(Owner owner)
        {
            _table = Map.ContextMapping.GetOwnerTable();
            _query = $@"
            INSERT INTO {_table}             
            VALUES 
            (@Id, @FirstName, @LastName, @DocumentNumber, @DocumentType, @Email, @DateCreated)";

            _parameters = new
            {
                Id = owner.Id,
                FirstName = owner.Name.FirstName,
                LastName = owner.Name.LastName,
                DocumentNumber = owner.Document.DocumentNumber,
                DocumentType = (Int16)owner.Document.DocumentType,
                Email = owner.Email,
                DateCreated = owner.DateCreated.ToString("yyyy-dd-MM HH:mm:ss")
            };

            return new object[] { _query, _parameters };
        }

        public static object[] DeleteOwnerById(Guid ownerId)
        {
            _table = Map.ContextMapping.GetOwnerTable();
            _query = $@"DELETE FROM {_table} WHERE Id = @OwnerId";
            _parameters = new { OwnerId = ownerId };
            return new object[] { _query, _parameters };
        }
    }
}