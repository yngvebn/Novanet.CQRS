namespace CQRS.DomainEvent
{
    public interface IHandleDomainEvent<T> where T: IDomainEvent
    {
        void Handle(T domainEvent);
    }
}