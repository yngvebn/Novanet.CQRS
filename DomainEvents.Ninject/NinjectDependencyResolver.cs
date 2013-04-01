using System;
using System.Collections.Generic;
using DomainEventExtensions;
using Ninject;

<<<<<<< HEAD:DomainEvents.Ninject/NinjectDependencyResolver.cs
namespace DomainEvents.Ninject
=======
namespace CQRS.Ninject
>>>>>>> Cleanup and separate Nuget Project:DomainEvents.Ninject/NinjectDependencyResolver.cs
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