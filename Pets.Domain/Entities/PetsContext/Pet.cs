using System;
using System.Collections.Generic;
using Pets.Domain.Notifications;
using Pets.Domain.Specs.PetContext;
using Pets.Domain.Validations;
using Pets.Domain.Validations.Interfaces;
using Pets.Domain.ValueObjects;

namespace Pets.Domain.Entities.PetsContext
{
    public class Pet : BaseEntity, IValidate
    {
        public Pet(Name name, int age, int identifier, Guid ownerId)
        : base(name)
        {
            Age = age;
            Identifier = identifier;
            OwnerId = ownerId;
        }

        public int Age { get; private set; }
        public int Identifier { get; private set; }
        public Guid OwnerId { get; private set; }

        public bool Validate()
        {
            var contractValidation = 
           new ContractValidations<Owner>()                      
           .FirstIsLenghtOk(this.Name, 20, 5, "O primeiro nome deve ter entre 5 caracteres e 20 caracteres", "FirstName")
           .LastIsLenghtOk(this.Name ,20, 5, "O segundo nome deve ter entre 5 caracteres e 20 caracteres", "LastName");                     

           this.SetNotificationList(contractValidation.Notifications as List<Notification>);
           return (contractValidation.Notifications.Count == 0? true : false); 
        }
    }
}
