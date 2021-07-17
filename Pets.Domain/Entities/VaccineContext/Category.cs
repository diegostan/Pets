using Pets.Domain.Notifications;
using Pets.Domain.Validations;
using Pets.Domain.Validations.Interfaces;

namespace Pets.Domain.Entities.VaccineContext
{
    public class Category : BaseEntity, IValidate
    {
        public Category(string description)
        {
            Description = description;
        }

        public string Description { get; private set; }

        public bool Validate()
        {
            if (DescriptionValidations.DescriptionIsNotNull(Description))
                this.AddNotification(new Notification(message: "A descrição não pode estar em branco"
                , propertyName: nameof(Description)));

            if (DescriptionValidations.DescriptionLenghtOk(Description, 5, 50))
                this.AddNotification(new Notification(message: "A descrição deve conter entre 5 e 50 caracteres"
                    , propertyName: nameof(Description)));

            return (this.GetNotificationCount== 0? true : false);
        }
    }
}