using System.Collections.Generic;
using Pets.Domain.Notifications;
using Pets.Domain.Validations.Interfaces;

namespace Pets.Domain.Specs.Interfaces
{
    public interface ISpecification<in T> where T : IValidate
    {
        IEnumerable<Notification> IsSatisfiedBy(T candidate);        
    }
}