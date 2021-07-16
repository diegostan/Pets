namespace Pets.Domain.ValueObjects
{
    public record Name
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; init; }
        public string LastName { get; init; }
    }
}