namespace Novanet.CQRS.Commands
{
    public class CommandResult
    {
        public static CommandResult Executed(string message)
        {
            return new CommandResult { Status = CommandStatus.Executed, Message = message };
        }

        public static CommandResult Failed(string message)
        {
            return new CommandResult { Status = CommandStatus.Failed, Message = message };
        }

        public bool IsExecuted
        {
            get { return Status == CommandStatus.Executed; }
        }

        public string Message { get; set; }

        public CommandStatus Status { get; set; }

    }
}