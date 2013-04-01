using System;

namespace DomainEvents
{
    public class CommandResult
    {
        public CommandStatus Status { get; private set; }
        public string Message { get; private set; }

        private CommandResult()
        {

        }
        public static CommandResult Failure(string message)
        {
            return new CommandResult()
                {
                    Message = message,
                    Status = CommandStatus.Failed
                };
        }
        public static CommandResult Success()
        {
            return new CommandResult()
                {
                    Status = CommandStatus.Success,
                    Message = String.Empty
                };
        }
    }
}