using System;
using System.Collections.Generic;
using Pets.Domain.Notifications;
using Pets.Domain.Notifications.Interfaces;
using Pets.Domain.Validations.Interfaces;

namespace Pets.Domain.Entities.VaccineContext
{
    public abstract class BaseEntity : IValidate
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

        public void SetNotificationList(List<Notification> notifications)
        {
            _notifications = notifications;
        }

        public abstract bool Validate();
        
    }
}