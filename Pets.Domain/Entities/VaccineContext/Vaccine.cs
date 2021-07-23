using System;
using Pets.Domain.Notifications;
using Pets.Domain.Validations;
using Pets.Domain.Validations.Interfaces;

namespace Pets.Domain.Entities.VaccineContext
{ 
    public class Vaccine : BaseEntity, IValidate
    {
        public Vaccine(string description, Guid categoryId, Guid petId)
        {
            Description = description;
            CategoryId = categoryId;
            PetId = petId;
        }

        public string Description { get; private set; }
        public Guid CategoryId { get; private set; }
        public Guid PetId { get; private set; }

        public bool Validate()
        {
            // if (DescriptionValidations.DescriptionIsNotNull(Description))
            //     this.AddNotification(new Notification(message: "A descrição não pode estar em branco"
            //     , propertyName: nameof(Description)));

            // if (DescriptionValidations.DescriptionLenghtOk(Description, 5, 50))
            //     this.AddNotification(new Notification(message: "A descrição deve conter entre 5 e 50 caracteres"
            //         , propertyName: nameof(Description)));

            // if (GuidValidations.IsGuid(CategoryId))
            //     this.AddNotification(new Notification(message: "O código do categoria de vacina não é válido"
            //     , propertyName: nameof(CategoryId)));
            
            // if (GuidValidations.IsGuid(PetId))
            //     this.AddNotification(new Notification(message: "O código do animal não é válido"
            //     , propertyName: nameof(PetId)));
            
            
            return (this.GetNotificationCount== 0? true : false);
        }
    }
}