using Pets.Application.Input.Commands.Interfaces;
using Pets.Domain.ValueObjects;

namespace Pets.Application.Input.Commands.PetsContext
{
    public class InsertOwnerCommand : ICommandBase
    {
        public Name Name { get; set; }
        public Document Document { get; set; }
        public string Email { get; set; }
                                                
    }
}