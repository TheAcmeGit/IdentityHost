using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Domain.Core
{
    public abstract class Entity : IEntity
    {
        public abstract object[] GetKeys();

        #region 
        private List<IDomainEvent> _domainEvents;
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents = _domainEvents ?? new List<IDomainEvent>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
        #endregion

    }
    public abstract class Entity<TKey> : Entity, IEntity<TKey>
    {
        public virtual TKey Id { get; protected set; }
        public override object[] GetKeys()
        {
            return new object[] { Id };
        }

    }

}
