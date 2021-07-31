using System.Collections.Generic;
using Pets.Application.Output.DTO;
using Pets.Application.Output.Results;

namespace Pets.Application.Output.Requests.VaccineRequest
{
    public class CategoryRequest
    {
        public Result Result { get; set; }
        public IList<CategoryDTO> Categories { get; set; }
                                
    }
}