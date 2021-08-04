using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pets.Application.Input.Commands.VaccineContext;
using Pets.Application.Input.Handlers.Interfaces;
using Pets.Application.Output.Results;
using Pets.Application.Output.Results.Interfaces;
using Pets.Application.Repositories.VaccineContext;
using Pets.Domain.Entities.VaccineContext;
using Pets.Domain.Notifications;

namespace Pets.Application.Input.Handlers.VaccineContext
{
    public class InsertCategoryHandler : IHandlerBase<InsertCategoryCommand>
    {
        private readonly ICategoryRepository _repository;
        public InsertCategoryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public IResultBase Handle(InsertCategoryCommand command)
        {
            Result result;
            var category = new Category(command.Description);

            if (category.Validate())
            {
                try
                {
                    _repository.InsertCategory(category);
                    result = new Result(200, "Categoria inserida com sucesso", true);
                    return result;
                }
                catch (Exception ex)
                {
                    result = new Result(500, $"Falha ao cadastrar categoria. Mais detalhes: {ex.Message}", false);
                    return result;
                }
            }

            result = new Result(400, "Requisição inválida! Verifique os campos e tente novamente", true);
            result.SetNotifications(category.Notifications as List<Notification>);
            return result;
        }
    }
}