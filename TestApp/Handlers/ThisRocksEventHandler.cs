using System;
using Novanet.CQRS.DomainEvents;
using TestApp.Events;
using TestApp.Services;

namespace TestApp.Handlers
{
    public class ThisRocksEventHandler : IHandleDomainEvent<SomeDomainEvent>
    {
        private readonly ITextProcessor _textProcessor;

        public ThisRocksEventHandler(ITextProcessor textProcessor)
        {
            _textProcessor = textProcessor;
        }

        public void Handle(SomeDomainEvent domainEvent)
        {
            Console.WriteLine("{0} - ThisRocks! {1}", DateTime.Now, _textProcessor.ProcessText(domainEvent.Text));
        }
    }
}