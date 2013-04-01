namespace DomainEventExtensions
{
    public interface IHandleDomainEvent<T> where T: IDomainEvent
    {
        void Handle(T domainEvent);
    }
}