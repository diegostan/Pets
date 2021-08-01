using System;
using System.Collections.Generic;
using Pets.Application.Input.Commands.VaccineContext;
using Pets.Application.Input.Handlers.Interfaces;
using Pets.Application.Output.Results;
using Pets.Application.Output.Results.Interfaces;
using Pets.Application.Repositories.VaccineContext;
using Pets.Domain.Entities.VaccineContext;
using Pets.Domain.Notifications;

namespace Pets.Application.Input.Handlers.VaccineContext
{
    public class InsertVaccineHandler : IHandlerBase<InsertVaccineCommand>
    {
        private readonly IVaccineRepository _repository;
        public InsertVaccineHandler(IVaccineRepository repository)
        {
            _repository = repository;
        }
        public IResultBase Handle(InsertVaccineCommand command)
        {
            Result result;
            var vaccine = new Vaccine(command.Description, command.CategortyId, command.PetId);
            if (vaccine.Validate())
            {
                try
                {
                    _repository.InsertVaccine(vaccine);
                    result = new Result(200, "Vacina adicionada com sucesso", true);
                }
                catch (Exception ex)
                {
                    result = new Result(500, $"Falha ao cadastrar categoria. Mais detalhes: {ex.Message}", false);
                }


            }
             result = new Result(400, "Requisição inválida! Verifique os campos e tente novamente", true);
            result.SetNotifications(vaccine.Notifications as List<Notification>);
            return result;
        }
    }
}