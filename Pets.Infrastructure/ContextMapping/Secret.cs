namespace Pets.Infrastructure.ContextMapping
{
    public static class Secret
    {
        public static string GetSqlServerConnectionStringProd()
        {
            return "Server=.\\SQLEXPRESS;Database=Pets;Integrated Security=True;";
        }

        public static string GetPostgreSqlConnectionStringProd()
        {
            return "Server=localhost;Port=5432;Database=pets;User Id=postgres;Password=191260;";
        }

        
        public static string GetSqlServerConnectionStringDev()
        {
            return "Server=.\\SQLEXPRESS;Database=Pets;Integrated Security=True;";
        }

        public static string GetPostgreSqlConnectionStringDev()
        {
            return "Server=localhost;Port=5432;Database=pets;User Id=postgres;Password=191260;";
        }
    }
}