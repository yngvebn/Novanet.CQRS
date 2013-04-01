using System;
using System.Linq;
using System.Text;
using DomainEventExtensions;
using DomainEvents;
using Ninject;
using Ninject.Extensions.Conventions;
using TestApp.Commands;
using TestApp.Events;
using TestApp.Handlers;
using TestApp.Services;
using DomainEvents.Ninject;

namespace TestApp
{
    class Program
    {
        private static IDomainEvents DomainEvents {
            get { return _kernel.Get<IDomainEvents>(); }
        }

        private static ICommandExecutor CommandExecutor
        {
            get { return _kernel.Get<ICommandExecutor>(); }
        }

        static void Main(string[] args)
        {
            SetupKernel();
            DomainEvents.Raise<SomeDomainEvent>(ev =>
                                {
                                    ev.Text = "Hello world";
                                });
            var result = CommandExecutor.Execute(new DoSomething() {Text = "Hello world"});
            Console.WriteLine(result.Message);
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

            _kernel.Bind(syntax => syntax
       .FromAssemblyContaining<DoSomethingCommandHandler>()
       .SelectAllTypes()
       .InNamespaceOf<DoSomethingCommandHandler>()
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
