namespace DomainEventExtensions
{
    public interface IDomainEventHandler<T> where T: IDomainEvent
    {
        void Handle(T domainEvent);
    }
}