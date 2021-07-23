using System.Collections.Generic;
using Pets.Domain.Notifications;
using Pets.Domain.Validations;
using Pets.Domain.Validations.Interfaces;
using Pets.Domain.ValueObjects;

namespace Pets.Domain.Entities.PetsContext
{
    public class Owner : BaseEntity, IValidate, IContract
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
            var contractValidation =
            new ContractValidations<Owner>()
            .FirstNameIsOk(this.Name, 20, 5, "O primeiro nome deve ter entre 5 caracteres e 20 caracteres", "FirstName")
            .LastNameIsOk(this.Name, 20, 5, "O segundo nome deve ter entre 5 caracteres e 20 caracteres", "LastName")
            .EmailIsValid(this.Email, "O email não é válido", "Email")
            .DocumentIsValid(this.Document, "O documento não é válido", "Document");


            this.SetNotificationList(contractValidation.Notifications as List<Notification>);
            return (contractValidation.Notifications.Count == 0 ? true : false);
        }
    }

}