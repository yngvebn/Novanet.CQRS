namespace Commands
{
    public interface ICommandHandler<in T>
    {
        void Handle(T command);
    }
}