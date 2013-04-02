using System;
using System.Collections.Generic;
using Ninject;
using Novanet.CQRS.Core;

namespace Novanet.CQRS.Ninject
{
    public class NinjectDependencyResolver: IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
        }

        public T GetService<T>()
        {
            return _kernel.Get<T>();
        }

        public IEnumerable<T> GetServices<T>()
        {
            return _kernel.GetAll<T>();
        }

        public object GetService(Type type)
        {
            return _kernel.Get(type);
        }

        public IEnumerable<object> GetServices(Type type)
        {
            return _kernel.GetAll(type);
        }
    }
}