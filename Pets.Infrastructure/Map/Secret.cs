namespace Pets.Infrastructure.Map
{
    public static class Secret
    {
        public static string GetConnectionString()
        {
            return "Server=.\\SQLEXPRESS;Database=Pets;Integrated Security=True;";
        }
    }
}