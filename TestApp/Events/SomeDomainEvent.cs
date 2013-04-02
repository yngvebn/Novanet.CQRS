using Novanet.CQRS.DomainEvents;

namespace TestApp.Events
{
    public class SomeDomainEvent: IDomainEvent
    {
        public string Text { get; set; }
    }


}