using System.Collections.Generic;
using Pets.Domain.Entities.PetsContext;
using Pets.Domain.Notifications;
using Pets.Domain.Specs.Interfaces;
using Pets.Domain.Validations;

namespace Pets.Domain.Specs.PetContext
{
    public class PetSpecs : ISpecification<Pet>
    {
        public PetSpecs()
        {
            _notifications = new List<Notification>();
        }
        private List<Notification> _notifications;
        public void AddNotification(Notification notification)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Notification> IsSatisfiedBy(Pet candidate)
        {
            // if (NameValidations.FirstIsLenghtOk(candidate.Name, 3, 50))
            //     this.AddNotification(new Notification(message: "Tamanho do primeiro nome deve conter entre 3 e 50 caracters"
            //     , propertyName: nameof(candidate.Name)));

            // if (NameValidations.LastIsLenghtOk(candidate.Name, 3, 50))
            //     this.AddNotification(new Notification(message: "Tamanho do segundo nome deve conter entre 3 e 50 caracters"
            //    , propertyName: nameof(candidate.Name)));

            // if (NameValidations.FirstNameIsNotNull(candidate.Name))
            //     this.AddNotification(new Notification(message: "O primeiro nome não pode estar em branco"
            //    , propertyName: nameof(candidate.Name)));

            // if (NameValidations.LastNameIsNotNull(candidate.Name))
            //     this.AddNotification(new Notification(message: "O segundo nome não pode estar em branco"
            //    , propertyName: nameof(candidate.Name)));

            // if (GuidValidations.IsGuid(candidate.OwnerId))
            //     this.AddNotification(new Notification(message: "O id do dono deve ser um Guid"
            //     , propertyName: nameof(candidate.OwnerId)));

            return _notifications;
        }
    }
}