using Pets.Application.Output.DTO;
using Pets.Application.Output.Requests.Interfaces;
using Pets.Application.Output.Results;

namespace Pets.Application.Output.Requests.PetsRequests
{
    public class OwnerRequest : IRequestBase
    {    
        public Result Result { get; set; }
        public OwnerDTO Owner { get; set; }
    }
}