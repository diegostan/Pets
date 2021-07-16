using System.Collections.Generic;
using Pets.Application.Input.Commands.PetsContext;
using Pets.Application.Input.Handlers.Interfaces;
using Pets.Application.Output.Results;
using Pets.Application.Output.Results.Interfaces;
using Pets.Application.Repositories.PetsContext;
using Pets.Domain.Entities.PetsContext;
using Pets.Domain.Notifications;

namespace Pets.Application.Input.Handlers.PetsContext
{
    public class InsertOwnerHandler : IHandlerBase<InsertOwnerCommand>
    {
        private readonly IOwnerRepository _repository;
        public InsertOwnerHandler(IOwnerRepository repository)
        {
            _repository = repository;
        }
        public IResultBase Handle(InsertOwnerCommand command)
        {
            var owner = new Owner(command.Name, command.Email, command.Document);
            Result result;
            if (owner.Validate())
            {
                _repository.InsertOwner(owner);
                result = new Result(200, $"Dono {owner.Name.FirstName} inserido com sucesso", true);
                return result;
            }
            result = new Result(500, $"Falha ao inserir o dono {owner.Name.FirstName} na base de dados", false);
            result.SetNotifications(owner.Notifications as List<Notification>);
            return result;
        }
    }
}