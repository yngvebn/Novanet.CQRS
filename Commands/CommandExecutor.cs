using System;
using CQRS.Core;

namespace CQRS.Commands
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly IDependencyResolver _kernel;

        public CommandExecutor(IDependencyResolver kernel)
        {
            _kernel = kernel;
        }

        public CommandResult Execute(Command command)
        {
            dynamic handler = FindHandlerForCommand(command);

            try
            {
                handler.Handle(command as dynamic);
                return CommandResult.Executed("Command executed successfully");
            }
            catch (Exception ex)
            {
                return CommandResult.Failed(ex.Message);
            }
            finally
            {
              
            }
        }

        public CommandResult Execute<T>(Action<T> commandBuilder) where T : Command, new()
        {
            var command = new T();
            commandBuilder(command);
            return Execute(command);
        }

        private object FindHandlerForCommand(Command command)
        {
            var handlerType = typeof(IHandleCommand<>).MakeGenericType(command.GetType());
            dynamic handler = _kernel.GetService(handlerType);
            return handler;
        }
    }
}
