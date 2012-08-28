using System;
using DomainEvents;

namespace TestApp.Commands
{
    public class DoSomething: ICommand
    {
        public string Text { get; set; }
    }

    public class DoSomethingCommandHandler: ICommandHandler<DoSomething>
    {
        public void Execute(DoSomething command)
        {
            throw new InvalidOperationException("That text is not valid: " +command.Text);
        }
    }
}