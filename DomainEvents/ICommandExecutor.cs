namespace DomainEvents
{
    public interface ICommandExecutor
    {
        CommandResult Execute<T>(T command) where T : ICommand;

    }
}