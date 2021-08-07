namespace Pets.Infrastructure.Map
{
    public static class ContextMapping
    {
        public static string GetOwnerTable()
        {
            return "Owner";
        }

        public static string GetPetTable()
        {
            return "Pet";
        }
        public static string GetCategoryTable()
        {
            return "Category";
        }
        public static string GetVaccineTable()
        {
            return "Vaccine";
        }
    }
}