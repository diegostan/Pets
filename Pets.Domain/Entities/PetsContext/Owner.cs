using System.Collections.Generic;
using Pets.Domain.Notifications;
using Pets.Domain.Specs.PetContext;
using Pets.Domain.Validations;
using Pets.Domain.Validations.Interfaces;
using Pets.Domain.ValueObjects;

namespace Pets.Domain.Entities.PetsContext
{
    public class Owner : BaseEntity, IValidate
    {
        public Owner(Name name, string email, Document document)
           : base(name)
        {
            Email = email;
            Document = document;
        }

        public string Email { get; private set; }
        public Document Document { get; private set; }

        public bool Validate()
        {
           var nameValidation = 
           new ContractValidations<Owner>(Name)
           .FirstNameIsNotNull("O primeiro nome não pode estar em branco", "FirstName")
           .LastNameIsNotNull("O segundo nome não pode estar em branco", "LastName")
           .FirstIsLenghtOk(20, 5, "O primeiro nome deve ter entre 3 caracteres e 20 caracteres", "FirstName")
           .LastIsLenghtOk(20, 5, "O segundo nome deve ter entre 3 caracteres e 20 caracteres", "LastName")
           .EmailIsValid(this.Email, "O email não é válido", "Email");
           

           this.SetNotificationList(nameValidation.Notifications as List<Notification>);
           return (nameValidation.Notifications.Count == 0? true : false); 
        }        
    }
    
}