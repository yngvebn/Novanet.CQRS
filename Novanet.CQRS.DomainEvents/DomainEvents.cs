using System;
using System.Collections.Generic;
using Novanet.CQRS.Core;

namespace Novanet.CQRS.DomainEvents
{
    public class DomainEvents : IDomainEvents
    {
        private readonly IDependencyResolver _resolver;

        public DomainEvents(IDependencyResolver resolver)
        {
            _resolver = resolver;
        }

        public void Raise<T>(T domainEvent) where T : IDomainEvent
        {
            foreach (var handler in GetHandlersFor<T>())
            {
                handler.Handle(domainEvent);
            }
        }

        public void Raise<T>(Action<T> messageConstructor) where T : IDomainEvent, new()
        {
            var message = new T();
            messageConstructor(message);
            Raise(message);
        }


        private IEnumerable<dynamic> GetHandlersFor<T>() where T : IDomainEvent
        {
            var handlerType = typeof(IHandleDomainEvent<>);
            var genericHandlerType = handlerType.MakeGenericType(typeof(T));
            return _resolver.GetServices(genericHandlerType);
        }
    }
}