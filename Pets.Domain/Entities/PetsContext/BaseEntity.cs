using System;
using System.Collections.Generic;
using Pets.Domain.Notifications;
using Pets.Domain.Notifications.Interfaces;
using Pets.Domain.Validations.Interfaces;
using Pets.Domain.ValueObjects;

namespace Pets.Domain.Entities.PetsContext
{
    public abstract class BaseEntity : IValidate
    {
        private List<Notification> _notifications;
        protected BaseEntity(Name name)
        {
            Id = Guid.NewGuid();
            Name = name;
            DateCreated = DateTime.Now;
            _notifications = new List<Notification>();
        }

        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public DateTime DateCreated { get; private set; }
        public IReadOnlyCollection<Notification> Notifications => _notifications;        

        public void SetNotificationList(List<Notification> notifications)
        {
            _notifications = notifications;
        }

        public abstract bool Validate();
        
    }
}