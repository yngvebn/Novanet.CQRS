using Novanet.CQRS.Commands;

namespace TestApp.Commands
{
    public class DoSomething: Command
    {
        public string Text { get; set; }
    }
}