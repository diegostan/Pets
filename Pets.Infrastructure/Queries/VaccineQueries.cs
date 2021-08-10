using System;
using Pets.Domain.Entities.VaccineContext;

namespace Pets.Infrastructure.Queries
{
    public static class VaccineQueries
    {
        private static string _table;
        private static string _query;
        private static object _parameters;

        public static object[] GetVaccineByPetId(Guid petId)
        {
            _table = ContextMapping.Tables.GetVaccineTable();
            _query = $"SELECT *FROM {_table} WHERE PetId = @PetId";
            _parameters = new { PetId = petId };
            return new object[] { _query, _parameters };            
        }
        public static object[] InsertVaccine(Vaccine vaccine)
        {
            _table = ContextMapping.Tables.GetVaccineTable();
            _query = $@"
            INSERT INTO {_table}  
            VALUES (@Id, @Description, @CategoryId, @PetId, @CreatedDate)";
            
            _parameters = new 
             {
                Id = vaccine.Id,
                Description = vaccine.Description,
                CategoryId = vaccine.CategoryId,
                PetId = vaccine.PetId,
                CreatedDate = vaccine.DateCreated.ToString("yyyy-dd-MM HH:mm:ss")
             };
            
            return new object[] { _query, _parameters };
        }
    }
}