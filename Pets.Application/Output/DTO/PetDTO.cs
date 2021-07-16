using System;
using Pets.Domain.ValueObjects;

namespace Pets.Application.Output.DTO
{
    public struct PetDTO
    {
        public Guid Id { get; set; }
        public Name Name { get; set; }                                      
        public int Identifier { get; set; }
        public int Age { get; set; }
    }
}