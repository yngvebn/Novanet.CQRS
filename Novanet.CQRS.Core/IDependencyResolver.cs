using System;
using System.Collections.Generic;

namespace Novanet.CQRS.Core
{
    public interface IDependencyResolver
    {
        T GetService<T>();
        IEnumerable<T> GetServices<T>();
        object GetService(Type type);
        IEnumerable<object> GetServices(Type type);
    }
}