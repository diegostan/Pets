using System;
using System.Collections.Generic;
using Pets.Domain.Notifications;
using Pets.Domain.Notifications.Interfaces;

namespace Pets.Domain.Entities.VaccineContext
{
    public abstract class BaseEntity 
    {
        private List<Notification> _notifications;
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            DateCreated = DateTime.Now;
            _notifications = new List<Notification>();
        }

        public Guid Id { get; private set; }
        public DateTime DateCreated { get; private set; }
        public IReadOnlyCollection<Notification> Notifications => _notifications;
        public int GetNotificationCount => _notifications.Count;

        public void SetNotificationList(List<Notification> notifications)
        {
            throw new NotImplementedException();
        }
    }
}