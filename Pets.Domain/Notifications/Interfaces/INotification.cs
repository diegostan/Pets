using System.Collections.Generic;

namespace Pets.Domain.Notifications.Interfaces
{
    public interface INotification
    {
        void AddNotification(Notification notification);
    }
}