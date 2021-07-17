using System;
using Pets.Application.Input.Commands.Interfaces;

namespace Pets.Application.Input.Commands.VaccineContext
{
    public class InsertVaccineCommand : ICommandBase
    {
        public Guid CategortyId { get; set; }
        public string Description { get; set; }

    }
}