using System;
using Pets.Domain.Entities.PetsContext;

namespace Pets.Infrastructure.Queries
{
    public static class PetQueries
    {
        private static string _table;
        private static string _query;

        public static string GetPetsByOwnerId(Guid ownerId)
        {
            _table = Map.ContextMapping.GetPetTable();
            _query = $@"SELECT *FROM {_table} WHERE [OwnerId] = '{ownerId}'";
            return _query;
        }

        public static string InsertPet(Pet pet)
        {
            _table = Map.ContextMapping.GetPetTable();
            _query = $@"
            INSERT INTO {_table}
            VALUES
            ('{pet.Id}',
            '{pet.Name.FirstName}', 
            '{pet.Name.LastName}', 
            {pet.Identifier}, 
            {pet.Age}, 
            '{pet.OwnerId}', 
            '{pet.DateCreated.ToString("yyyy-MM-dd HH:mm:ss")}
            ')";
            return _query;
        }
    }
}