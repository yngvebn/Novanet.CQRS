namespace Novanet.CQRS.DomainEvents
{
    public interface IHandleDomainEvent<T> where T: IDomainEvent
    {
        void Handle(T domainEvent);
    }
}