using System.Text.RegularExpressions;
using Pets.Domain.Notifications;

namespace Pets.Domain.Validations
{
    public partial class ContractValidations<T> : NotificationBase
    {
        public ContractValidations<T> EmailIsValid(string email, string message, string propertyName)
        {
            if(string.IsNullOrEmpty(email) || !Regex.IsMatch(email, @"^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$"))            
                AddNotification(new Notification(message, propertyName));
            
            return this;
        }
    }
}