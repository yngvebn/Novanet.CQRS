using System.Linq;
using Autofac;
using Novanet.CQRS.Autofac;
using Xunit;

namespace DomainEvents.AutofacTests
{
    public class DependencyResolverTests
    {
        [Fact]
        public void Resolve_SingleGenericType_Resolved()
        {
            
            var builder = new ContainerBuilder();

            builder.RegisterType<InterfaceImplementationA>().As<IInterfaceToResolve>();

            var container = builder.Build();

            var theResolver = new AutofacDependencyResolver(container);

            Assert.IsType<InterfaceImplementationA>(theResolver.GetService<IInterfaceToResolve>());

        }
        [Fact]
        public void Resolve_SingleTypeParameter_Resolved()
        {
             var builder = new ContainerBuilder();

            builder.RegisterType<InterfaceImplementationA>().As<IInterfaceToResolve>();

            var container = builder.Build();

            var theResolver = new AutofacDependencyResolver(container);

            Assert.IsType<InterfaceImplementationA>(theResolver.GetService(typeof (IInterfaceToResolve)));
        }
        [Fact]
        public void Resolve_MultipleFromGenericType_Resolved()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<InterfaceImplementationA>().As<IInterfaceToResolve>();
            builder.RegisterType<InterfaceImplementationB>().As<IInterfaceToResolve>();

            var container = builder.Build();

            var theResolver = new AutofacDependencyResolver(container);

            Assert.Equal(2,theResolver.GetServices<IInterfaceToResolve>().Count()) ;
        }
        [Fact]
        public void Resolve_MultipleFromTypeParameter_Resolved()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<InterfaceImplementationA>().As<IInterfaceToResolve>();
            builder.RegisterType<InterfaceImplementationB>().As<IInterfaceToResolve>();

            var container = builder.Build();

            var theResolver = new AutofacDependencyResolver(container);

            Assert.Equal(2, theResolver.GetServices(typeof(IInterfaceToResolve)).Count());
        }
    }
}
