using System.Collections.Generic;
using Pets.Domain.Entities.PetsContext;
using Pets.Domain.Enums;
using Pets.Domain.Notifications;
using Pets.Domain.Specs.Interfaces;
using Pets.Domain.Validations;
using Pets.Domain.ValueObjects;

namespace Pets.Domain.Specs.PetContext
{
    public class OwnerSpecs : ISpecification<Owner>
    {
        public OwnerSpecs()
        {
            _notifications = new List<Notification>();
        }
        private List<Notification> _notifications;
        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public IEnumerable<Notification> IsSatisfiedBy(Owner candidate)
        {
            //  if (NameValidations.FirstIsLenghtOk(candidate.Name, 3, 50))
            //     this.AddNotification(new Notification(message: "Tamanho do primeiro nome deve conter entre 3 e 50 caracters"
            //     , propertyName: nameof(Name)));

            // if (NameValidations.LastIsLenghtOk(candidate.Name, 3, 50))
            //     this.AddNotification(new Notification(message: "Tamanho do segundo nome deve conter entre 3 e 50 caracters"
            //    , propertyName: nameof(Name)));

            // if (NameValidations.FirstNameIsNotNull(candidate.Name))
            //     this.AddNotification(new Notification(message: "O primeiro nome não pode estar em branco"
            //    , propertyName: nameof(Name)));

            // if (NameValidations.LastNameIsNotNull(candidate.Name))
            //     this.AddNotification(new Notification(message: "O segundo nome não pode estar em branco"
            //    , propertyName: nameof(Name)));

            // if (candidate.Document.DocumentType == EDocumentType.CPF)
            //     if (!DocumentValidations.IsCpf(candidate.Document.DocumentNumber))
            //         this.AddNotification(new Notification(message: "CPF inválido"
            //    , propertyName: nameof(Document)));

            // if (candidate.Document.DocumentType == EDocumentType.CNPJ)
            //     if (!DocumentValidations.IsCnpj(candidate.Document.DocumentNumber))
            //         this.AddNotification(new Notification(message: "CNPJ inválido"
            //    , propertyName: nameof(Document)));

            // if(!EmailValidations.IsValid(candidate.Email))
            //     this.AddNotification(new Notification(message: "E-mail inválido"
            //     , propertyName: nameof(candidate.Email)));

            return _notifications;
        }
    }
}