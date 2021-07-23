using System.Collections.Generic;
using Pets.Domain.Notifications;
using Pets.Domain.Notifications.Interfaces;
using Pets.Domain.ValueObjects;

namespace Pets.Domain.Validations
{
    public partial class ContractValidations<T> : NotificationBase
    {        
        public ContractValidations(Name name)
        {
            Name = name;           
        }
        public Name Name { get; private set; }

        public ContractValidations<T> FirstNameIsNotNull(string message, string propertyName)
        {
            if (string.IsNullOrEmpty(Name.FirstName))
                AddNotification(new Notification(message, propertyName));

            return this;
        }

        public ContractValidations<T> LastNameIsNotNull(string message, string propertyName)
        {
            if (string.IsNullOrEmpty(Name.LastName))
                AddNotification(new Notification(message, propertyName));

            return this;
        }

        public ContractValidations<T> FirstIsLenghtOk(short maxLength, short minLength, string message, string propertyName)
        {
            if ((Name.FirstName.Length < minLength) || (Name.FirstName.Length > maxLength))
                AddNotification(new Notification(message, propertyName));

            return this;
        }

        public ContractValidations<T> LastIsLenghtOk(short maxLength, short minLength, string message, string propertyName)
        {
            if ((Name.LastName.Length < minLength) || (Name.LastName.Length > maxLength))
                AddNotification(new Notification(message, propertyName));

            return this;
        }
        
    }
}