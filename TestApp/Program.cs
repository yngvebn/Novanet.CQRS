using System;
using System.Linq;
using System.Text;
using DomainEventExtensions;
using Ninject;
using Ninject.Extensions.Conventions;
using TestApp.Events;
using TestApp.Handlers;
using TestApp.Services;

namespace TestApp
{
    class Program
    {
        private static IDomainEvents DomainEvents {
            get { return _kernel.Get<IDomainEvents>(); }
        }

        static void Main(string[] args)
        {
            SetupKernel();
            DomainEvents.Raise<SomeDomainEvent>(ev =>
                                {
                                    ev.Text = "Hello world";
                                });

            Console.Read();
        }

        private static IKernel _kernel;
        private static void SetupKernel()
        {
            _kernel = new StandardKernel();
            _kernel.Bind(syntax => syntax
                .FromAssemblyContaining<SomeDomainEventHandler>()
                .SelectAllTypes()
                .InNamespaceOf<SomeDomainEventHandler>()
                .BindAllInterfaces()
                .Configure(binding => binding.InSingletonScope()));

            _kernel.Bind(
                syntax => syntax
                    .FromAssemblyContaining<IDomainEvent>()
                    .SelectAllClasses()
                    .BindDefaultInterface()
                    .Configure(binding => binding.InSingletonScope()));
            _kernel.Bind<IDependencyResolver>().To<NinjectDependencyResolver>();
            _kernel.Bind<ITextProcessor>().To<TextProcessor>();
        }
    }
}
