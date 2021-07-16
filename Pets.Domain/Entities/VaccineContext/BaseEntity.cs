using System;
using System.Collections.Generic;
using Pets.Domain.Notifications;
using Pets.Domain.Notifications.Interfaces;

namespace Pets.Domain.Entities.VaccineContext
{
    public abstract class BaseEntity : INotification
    {
        private List<Notification> _notifications;
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTime.Now;
            _notifications = new List<Notification>();
        }

        public Guid Id { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public int GetNotificationCount => _notifications.Count;

        public void AddNotification(Notification notification)
        {
            throw new NotImplementedException();
        }
    }
}