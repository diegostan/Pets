using System.Collections.Generic;
using Pets.Domain.Notifications.Interfaces;

namespace Pets.Domain.Notifications
{
    public class NotificationBase : INotification
    {
        private List<Notification> _notifications;
        public NotificationBase()
        {
            _notifications = new List<Notification>();
        }
        public IReadOnlyCollection<Notification> Notifications => _notifications;
        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }
    }
}