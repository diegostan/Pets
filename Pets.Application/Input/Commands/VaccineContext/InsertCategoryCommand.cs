using System;
using Pets.Application.Input.Commands.Interfaces;

namespace Pets.Application.Input.Commands.VaccineContext
{
    public class InsertCategoryCommand : ICommandBase
    {        
        public string Description { get; set; }                
    }
}