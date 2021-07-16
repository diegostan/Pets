using System;
using Pets.Domain.ValueObjects;

namespace Pets.Application.Output.DTO
{
    public struct OwnerDTO
    {
        public Guid Id { get; set; }
        public Name Name { get; set; }
        public Document Document { get; set; }
        public string Email { get; set; }
    }
}