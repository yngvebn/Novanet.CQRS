using System;

namespace Novanet.CQRS.Commands
{
    public interface ICommandExecutor
    {
        CommandResult Execute(Command command);
        CommandResult Execute<T>(Action<T> commandBuilder) where T : Command, new();
    }
}