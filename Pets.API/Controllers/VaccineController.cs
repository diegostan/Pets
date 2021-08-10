using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pets.Application.Input.Commands.VaccineContext;
using Pets.Application.Input.Handlers.VaccineContext;
using Pets.Application.Output.Requests.VaccineRequest;
using Pets.Application.Output.Results;
using Pets.Application.Output.Results.Interfaces;
using Pets.Application.Repositories.VaccineContext;

namespace Pets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineController : ControllerBase
    {
        [HttpGet]
        [Route("/GetVaccineByPetId")]
        public async Task<VaccineRequest> GetVaccineByPetId([FromServices]IVaccineRepository repository, Guid petId)    
        {
            return await repository.GetVaccinesByPetIdAsync(petId);
        }
        
        [HttpPost]
        [Route("/PostVaccine")]
        public IResultBase PostVaccine([FromServices]InsertVaccineHandler handler, [FromBody] InsertVaccineCommand command)
        {
            return (Result)handler.Handle(command);
        }
    }
}