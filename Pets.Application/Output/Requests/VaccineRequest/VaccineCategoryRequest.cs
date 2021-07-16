using System.Collections.Generic;
using Pets.Application.Output.DTO;
using Pets.Application.Output.Results;

namespace Pets.Application.Output.Requests.VaccineRequest
{
    public class VaccineCategoryRequest
    {
        public Result Result { get; set; }
        public CategoryDTO Category { get; set; }
        public IList<VaccineDTO> Vaccines { get; set; }                                
    }
}