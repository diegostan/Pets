namespace Pets.Infrastructure.ContextMapping
{
    public static class Tables
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