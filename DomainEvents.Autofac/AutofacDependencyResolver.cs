

using System;
using System.Collections;
using System.Collections.Generic;
using Autofac;
using CQRS.Core;

namespace DomainEvents.Autofac
{
    public class AutofacDependencyResolver : IDependencyResolver
    {
        private readonly IContainer _container;

        public AutofacDependencyResolver(IContainer container )
        {
            _container = container;
        }
        public T GetService<T>()
        {
            return _container.Resolve<T>();
        }

        public IEnumerable<T> GetServices<T>()
        {
            return _container.Resolve<IEnumerable<T>>();
        }

        public object GetService(System.Type type)
        {
            return _container.Resolve(type);
        }

        public IEnumerable<object> GetServices(Type type)
        {
            Type customList = typeof(IEnumerable<>).MakeGenericType(type);

            return (IEnumerable<object>) _container.Resolve(customList);


        }
    }
}
