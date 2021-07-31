using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pets.Application.Input.Commands.VaccineContext;
using Pets.Application.Input.Handlers.VaccineContext;
using Pets.Application.Output.Requests.VaccineRequest;
using Pets.Application.Output.Results;
using Pets.Application.Repositories.VaccineContext;

namespace Pets.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("/GetAllCategories")]        
        public async Task<CategoryRequest> GetCategories([FromServices]ICategoryRepository repository)    
        {
            return await repository.GetAllCategoriesAsync();
        }        

        [AllowAnonymous]
        [HttpPost("/PostCategory")]        
        public Result PostCategory([FromServices]InsertCategoryHandler handler, InsertCategoryCommand command)    
        {
            return (Result)handler.Handle(command);
        }        
    }
}