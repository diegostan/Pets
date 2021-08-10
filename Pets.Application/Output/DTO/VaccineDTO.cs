using System;

namespace Pets.Application.Output.DTO
{
    public struct VaccineDTO
    {
        public Guid Id { get; set; }                
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}