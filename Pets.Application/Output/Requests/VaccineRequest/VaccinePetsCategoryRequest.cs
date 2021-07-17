using System;
using System.Collections.Generic;
using Pets.Application.Output.DTO;
using Pets.Application.Output.Results;

namespace Pets.Application.Output.Requests.VaccineRequest
{
    public class VaccinePetsCategoryRequest
    {
        public Result Result { get; set; }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Identifier { get; set; }
        public int Age { get; set; }
        public Guid OwnerId { get; set; }
        public string OwnerFirstName { get; set; }
        public string VaccineDescription { get; set; }
        public string CategoryDescription { get; set; }

        public IList<VaccineDTO> Vaccines { get; set; }                                
    }
}