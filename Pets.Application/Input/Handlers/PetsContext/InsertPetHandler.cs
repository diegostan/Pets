using System;
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
    public class InsertPetHandler : IHandlerBase<InsertPetCommand>
    {
        private readonly IPetRepository _repository;
        public InsertPetHandler(IPetRepository repository)
        {
            _repository = repository;
        }
        public IResultBase Handle(InsertPetCommand command)
        {
            Result result;
            var pet = new Pet(command.Name, command.Age, command.Identifier, command.OwnerId);
            if(pet.Validate())
            {
                 try
                {
                    _repository.InsertPet(pet);
                    result = new Result(200, "Pet inserido com sucesso", true);
                    return result;
                }
                catch (Exception ex)
                {
                    result = new Result(500, $"Falha interna do servidor, detalhes: {ex.Message}", false);
                }
                                
            }
            result = new Result(400, "Falha ao inserir o pet. Verifique os campos e tente novamente", false);
            result.SetNotifications(pet.Notifications as List<Notification>);
            return result;
        }
    }
}