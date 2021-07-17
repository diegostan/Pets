using System;
using Pets.Application.Input.Commands.Interfaces;

namespace Pets.Application.Input.Commands.VaccineContext
{
    public class DeleteCategoryCommand : ICommandBase
    {
        public Guid CategoryId { get; set; }

    }
}