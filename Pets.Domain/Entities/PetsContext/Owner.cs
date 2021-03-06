using System.Collections.Generic;
using Pets.Domain.Notifications;
using Pets.Domain.Validations;
using Pets.Domain.Validations.Interfaces;
using Pets.Domain.ValueObjects;

namespace Pets.Domain.Entities.PetsContext
{
    public class Owner : BaseEntity, IContract
    {
        public Owner(Name name, string email, Document document)
           : base(name)
        {
            Email = email;
            Document = document;
        }

        public string Email { get; private set; }
        public Document Document { get; private set; }

        public override bool Validate()
        {
            var contracts =
            new ContractValidations<Owner>()
            .FirstNameIsOk(this.Name, 20, 3, "O primeiro nome deve ter entre 3 caracteres e 20 caracteres", "FirstName")
            .LastNameIsOk(this.Name, 20, 3, "O segundo nome deve ter entre 3 caracteres e 20 caracteres", "LastName")
            .EmailIsValid(this.Email, "O email não é válido", "Email")
            .DocumentIsValid(this.Document, "O documento não é válido", "Document");


            this.SetNotificationList(contracts.Notifications as List<Notification>);
            return (contracts.IsValid());
        }
    }

}