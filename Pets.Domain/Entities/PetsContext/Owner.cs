using Pets.Domain.Enums;
using Pets.Domain.Notifications;
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

            if (Document.DocumentType == EDocumentType.CPF)
                if (!DocumentValidations.IsCpf(Document.DocumentNumber))
                    this.AddNotification(new Notification(message: "CPF inválido"
               , propertyName: nameof(Document)));

            if (Document.DocumentType == EDocumentType.CNPJ)
                if (!DocumentValidations.IsCnpj(Document.DocumentNumber))
                    this.AddNotification(new Notification(message: "CNPJ inválido"
               , propertyName: nameof(Document)));

            return (this.GetNotificationCount == 0 ? true : false);
        }
    }
}