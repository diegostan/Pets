using Pets.Application.Input.Commands.Interfaces;
using Pets.Application.Output.Results.Interfaces;

namespace Pets.Application.Input.Handlers.Interfaces
{
    public interface IHandlerBase<T> where T : ICommandBase
    {
        IResultBase Handle(T command);
    }
}