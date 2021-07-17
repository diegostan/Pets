using System;
using Pets.Application.Input.Commands.Interfaces;
using Pets.Domain.ValueObjects;

namespace Pets.Application.Input.Commands.PetsContext
{
    public class InsertPetCommand : ICommandBase
    {
        public Name Name { get; set; }
        public int Age { get; set; }       
        public int Identifier { get; set; } 
        public Guid OwnerId { get; set; }     
    }
}