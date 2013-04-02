using System;
using Novanet.CQRS.Commands;

namespace TestApp.Commands
{
    public class DoSomethingCommandHandler: IHandleCommand<DoSomething>
    {
        public void Handle(DoSomething command)
        {
            if (command.Text.Contains("Hello"))
            {
                throw new InvalidOperationException("That text is not valid: " + command.Text);
            }
            else
            {
                // do nothing
            }
        }
    }
}