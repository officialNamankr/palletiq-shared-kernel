using System;
using System.Collections.Generic;
using System.Text;

namespace PalletIQ.SharedKernel.BaseEntities
{
    public abstract class Entity
    {
        private readonly List<IDomainEvent> _domainEvents = [];

        protected Entity() { }

        protected Entity(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; protected set; } = Guid.NewGuid();

        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
    public interface IDomainEvent : MediatR.INotification
    {
        Guid EventId { get; }
        DateTime OccurredAt { get; }
    }


    public abstract record DomainEvent : IDomainEvent
    {
        public Guid EventId { get; init; } = Guid.NewGuid();
        public DateTime OccurredAt { get; init; } = DateTime.UtcNow;
    }  
}



