using System;
using Pets.Domain.Entities.PetsContext;

namespace Pets.Infrastructure.Queries
{
    public static class PetQueries
    {
        private static string _table;
        private static string _query;
        private static object _parameters;

        public static object[] GetPetsByOwnerId(Guid ownerId)
        {
            _table = Map.ContextMapping.GetPetTable();
            _query = $@"SELECT *FROM {_table} WHERE [OwnerId] = @OwnerId";
            _parameters = new { OwnerId = ownerId };
            return new object[] { _query, _parameters };
        }

        public static object[] InsertPet(Pet pet)
        {
            _table = Map.ContextMapping.GetPetTable();
            _query = $@"
            INSERT INTO {_table}
            VALUES (@Id, @FirstName, @LastName, @Identifier, @Age, @OwnerId, @DateCreated)";
            _parameters = new
            {
                Id = pet.Id,
                FirstName = pet.Name.FirstName,
                LastName = pet.Name.LastName,
                Identifier = pet.Identifier,
                Age = pet.Age,
                OwnerId = pet.OwnerId,
                DateCreated = pet.DateCreated.ToString("yyyy-dd-MM HH:mm:ss")
            };
            return new object[] { _query, _parameters };
        }
        public static object[] DeletePetById(Guid petId)
        {
            _table = Map.ContextMapping.GetPetTable();
            _query = $@"DELETE {_table} WHERE [Id] = @PetId";
            _parameters = new { PetId = petId };
            return new object[] { _query, _parameters };
        }
    }
}