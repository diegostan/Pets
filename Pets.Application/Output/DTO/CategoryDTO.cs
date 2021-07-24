using System;
using Pets.Application.Output.Results;

namespace Pets.Application.Output.DTO
{
    public struct CategoryDTO
    {        
        public Guid Id { get; set; }
        public string Description { get; set; }                
        
    }
}