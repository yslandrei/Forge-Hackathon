namespace Forge.Examples.MicrosoftDI
{
    public interface INodeService
    {
        public void DoSomething();
    }

    public class NodeService : INodeService
    {
        public void DoSomething()
        {
            Console.WriteLine("NodeService is doing something.");
        }
    }
}