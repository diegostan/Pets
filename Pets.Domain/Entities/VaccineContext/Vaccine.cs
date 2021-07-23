using System;
using System.Collections.Generic;
using Pets.Domain.Notifications;
using Pets.Domain.Validations;
using Pets.Domain.Validations.Interfaces;

namespace Pets.Domain.Entities.VaccineContext
{ 
    public class Vaccine : BaseEntity, IValidate, IContract
    {
        public Vaccine(string description, Guid categoryId, Guid petId)
        {
            Description = description;
            CategoryId = categoryId;
            PetId = petId;
        }

        public string Description { get; private set; }
        public int MaxAge { get; private set; }
        public Guid CategoryId { get; private set; }
        public Guid PetId { get; private set; }

        public bool Validate()
        {
           var contractValidation =
           new ContractValidations<Vaccine>()
           .DescriptionIsOk(this.Description, 50, 15, "A descrição de vacina deve conter entre 15 e 50 caracteres", "Description")
           .IsGuid(this.CategoryId, "A vacina deve ter um id de categoria válido", "CategoryId")
           .IsGuid(this.PetId, "A vacina deve ter um id de pet válido", "PetId");           

            this.SetNotificationList(contractValidation.Notifications as List<Notification>);
            return (contractValidation.Notifications.Count == 0 ? true : false);
        }
    }
}