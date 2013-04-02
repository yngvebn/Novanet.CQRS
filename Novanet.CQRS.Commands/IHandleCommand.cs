namespace Novanet.CQRS.Commands
{
    public interface IHandleCommand<in T>
    {
        void Handle(T command);
    }
}