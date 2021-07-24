using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pets.Application.Input.Commands.PetsContext;
using Pets.Application.Input.Handlers.PetsContext;
using Pets.Application.Output.DTO;
using Pets.Application.Output.Requests.PetsRequests;
using Pets.Application.Output.Results;
using Pets.Application.Repositories.PetsContext;

namespace Pets.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("GetOwnerByDocument")]
        public async Task<OwnerRequest> GetOwnerByDocument([FromServices] IOwnerRepository repository, string document)
        {
            return await repository.GetOwnerByDocumentAsync(document);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetOwnerByEmail")]
        public async Task<OwnerRequest> GetOwnerByEmail([FromServices] IOwnerRepository repository, string email)
        {
            return await repository.GetOwnerByEmailAsync(email);            
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("PostOwner")]
        public Result PostOwner([FromServices] InsertOwnerHandler handler, InsertOwnerCommand command)
        {            
            return (Result)handler.Handle(command);
        }
    }
}