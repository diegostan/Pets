using Pets.Domain.Entities.VaccineContext;

namespace Pets.Infrastructure.Queries
{
    public static class VaccineQueries
    {
        private static string _table;
        private static string _query;

        public static string InsertVaccine(Vaccine vaccine)
        {
            _table = Map.ContextMapping.GetVaccineTable();
            _query = $@"
            INSERT INTO {_table}  
            VALUES 
            ('{vaccine.Id}', 
            '{vaccine.Description}', 
            '{vaccine.CategoryId}', 
            '{vaccine.PetId}', 
            '{vaccine.DateCreated.ToString("yyyy-MM-dd HH:mm:ss")}')
            ";
            
            return _query;
        }
    }
}