using System;
using System.Collections.Generic;
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
    [Route("api/[Controller]")]
    public class PetController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        [Route("GetPetsByOwnerId")]
        public async Task<PetRequest> GetPetsByOwnerId([FromServices] IPetRepository repository, Guid ownerId)
        {
            return await repository.GetPetsByOwnerIdAsync(ownerId);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("PostPet")]
        public Result PostPet([FromServices] InsertPetHandler handler, InsertPetCommand command)
        {
            return (Result)handler.Handle(command);
        }

        [AllowAnonymous]
        [HttpDelete]
        [Route("DeletePet")]
        public Result DeletePet([FromServices] IPetRepository repository, Guid ownerId)
        {
            return (Result)repository.DeletePetById(ownerId);
        }
    }
}