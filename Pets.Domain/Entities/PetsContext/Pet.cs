using Pets.Domain.Notifications;
using Pets.Domain.Validations;
using Pets.Domain.Validations.Interfaces;
using Pets.Domain.ValueObjects;

namespace Pets.Domain.Entities.PetsContext
{
    public class Pet : BaseEntity, IValidate
    {
        public Pet(Name name, int age, int identifier) 
        : base(name)
        {
            Age = age;
            Identifier = identifier;
        }

        public int Age { get; private set; }
        public int Identifier { get; private set; }

        public bool Validate()
        {
             if (!NameValidations.FirstIsLenghtOk(Name, 3, 50))
                this.AddNotification(new Notification(message: "Tamanho do primeiro nome deve conter entre 3 e 50 caracters"
                , propertyName: nameof(Name)));

            if (!NameValidations.LastIsLenghtOk(Name, 3, 50))
                this.AddNotification(new Notification(message: "Tamanho do segundo nome deve conter entre 3 e 50 caracters"
               , propertyName: nameof(Name)));

            if (NameValidations.FirstNameIsNotNull(Name))
                this.AddNotification(new Notification(message: "O primeiro nome não pode estar em branco"
               , propertyName: nameof(Name)));

            if (NameValidations.LastNameIsNotNull(Name))
                this.AddNotification(new Notification(message: "O segundo nome não pode estar em branco"
               , propertyName: nameof(Name)));

            return (this.Notifications.Count == 0? true : false);
        }
    }
}