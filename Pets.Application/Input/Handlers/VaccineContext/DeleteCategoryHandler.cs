using Pets.Application.Input.Commands.VaccineContext;
using Pets.Application.Input.Handlers.Interfaces;
using Pets.Application.Output.Results;
using Pets.Application.Output.Results.Interfaces;
using Pets.Application.Repositories.VaccineContext;
using Pets.Domain.Validations;

namespace Pets.Application.Input.Handlers.VaccineContext
{
    public class DeleteCategoryHandler : IHandlerBase<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _repository;
        public DeleteCategoryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public IResultBase Handle(DeleteCategoryCommand command)
        {
            Result result;
            // if (GuidValidations.IsGuid(command.CategoryId))
            // {
            //     _repository.DeleteCategory(command.CategoryId);
            //     result = new Result(200, "Categoria apagada com sucesso", true);
            //     return result;
            // }

            result = new Result(400, "Categoria inválida", false);
            return result;
        }
    }
}