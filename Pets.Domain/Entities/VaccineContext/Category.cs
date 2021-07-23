using System.Collections.Generic;
using Pets.Domain.Notifications;
using Pets.Domain.Validations;
using Pets.Domain.Validations.Interfaces;

namespace Pets.Domain.Entities.VaccineContext
{
    public class Category : BaseEntity, IContract
    {
        public Category(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }

        public override bool Validate()
        {
           var contracts =
           new ContractValidations<Category>()
           .DescriptionIsOk(this.Description, 50, 15, "A descrição de categoria deve conter entre 15 e 50 caracteres", "Description");           

            this.SetNotificationList(contracts.Notifications as List<Notification>);
            return (contracts.IsValid());
            
        }
    }
}