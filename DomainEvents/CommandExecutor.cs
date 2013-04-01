using System;
using DomainEventExtensions;

namespace DomainEvents
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly IDependencyResolver _dependencyResolver;

        public CommandExecutor(IDependencyResolver dependencyResolver)
        {
            _dependencyResolver = dependencyResolver;
        }

        public CommandResult Execute<T>(T command) where T : ICommand
        {
            dynamic executor = FindExecutorFor<T>();
            try
            {
                executor.Execute(command);
                return CommandResult.Success();
            }
            catch (Exception ex)
            {
                return CommandResult.Failure(ex.Message);
            }
        }

        private dynamic FindExecutorFor(Type t)
        {
            Type executor = typeof(ICommandHandler<>);
            var genericType = executor.MakeGenericType(t);
            return _dependencyResolver.GetService(genericType);
        }

        private dynamic FindExecutorFor<T>()
        {
            return FindExecutorFor(typeof(T));
        }
    }
}