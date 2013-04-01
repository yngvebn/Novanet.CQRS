using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CQRS.Core;

namespace Commands
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly IDependencyResolver _kernel;

        public CommandExecutor(IDependencyResolver kernel)
        {
            _kernel = kernel;
        }

        public CommandResult ExecuteCommand(Command command)
        {
            dynamic handler = FindHandlerForCommand(command);

            try
            {
                handler.Handle(command as dynamic);
                return CommandResult.Executed("Command executed successfully");
            }
            finally
            {
              
            }
        }

        private object FindHandlerForCommand(Command command)
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
            dynamic handler = _kernel.GetService(handlerType);
            return handler;
        }
    }
}
