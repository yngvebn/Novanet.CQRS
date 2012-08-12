using System;
using System.Collections.Generic;

namespace DomainEventExtensions
{
    public interface IDependencyResolver
    {
        T GetService<T>();
        IEnumerable<T> GetServices<T>();
        object GetService(Type type);
        IEnumerable<object> GetServices(Type type);
    }
}