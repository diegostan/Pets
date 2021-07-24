using System.Collections.Generic;
using Pets.Application.Output.DTO;
using Pets.Application.Output.Requests.Interfaces;
using Pets.Application.Output.Results;

namespace Pets.Application.Output.Requests.PetsRequests
{
    public class PetRequest : IRequestBase
    {
        public Result Result { get; set; }
        public IEnumerable<PetDTO> Pets { get; set; }                                
    }
}