using System;
using Pets.Domain.Notifications;

namespace Pets.Domain.Validations
{
    public partial class ContractValidations<T> : NotificationBase
    {
        public ContractValidations<T> IsGuid(object guid, string message, string propertyName)
        {
            if (guid! is Guid)
                AddNotification(new Notification(message, propertyName));

            return this;
        }
    }
}