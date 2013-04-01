namespace Commands
{
    public interface ICommandExecutor
    {
        CommandResult ExecuteCommand(Command command);
    }
}