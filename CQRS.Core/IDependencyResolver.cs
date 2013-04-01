using System;
using System.Collections.Generic;

namespace CQRS.Core
{
    public interface IDependencyResolver
    {
        T GetService<T>();
        IEnumerable<T> GetServices<T>();
        object GetService(Type type);
        IEnumerable<object> GetServices(Type type);
    }
}