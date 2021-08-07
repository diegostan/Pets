namespace Pets.Infrastructure.Map
{
    public static class Secret
    {
        public static string GetSqlServerConnectionString()
        {
            return "Server=.\\SQLEXPRESS;Database=Pets;Integrated Security=True;";
        }

        public static string GetPostgreSqlConnectionString()
        {
            return "Server=localhost;Port=5432;Database=pets;User Id=postgres;Password=191260;";
        }
    }
}