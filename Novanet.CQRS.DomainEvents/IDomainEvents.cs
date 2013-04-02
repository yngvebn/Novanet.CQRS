using System;

namespace Novanet.CQRS.DomainEvents
{
    public interface IDomainEvents
    {
        void Raise<T>(T domainEvent) where T : IDomainEvent;
        void Raise<T>(Action<T> messageConstructor) where T : IDomainEvent, new();
    }
}