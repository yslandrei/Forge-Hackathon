using Microsoft.Forge.Attributes;
using Microsoft.Forge.TreeWalker;

namespace Forge.Examples.MicrosoftDI
{
    [ForgeAction(InputType: typeof(ExampleForgeActionInput))]
    public class ExampleForgeAction : BaseAction
    {
        INodeService nodeService;
        public ExampleForgeAction(INodeService nodeService)
        {
            this.nodeService = nodeService;
        }

        public override Task<ActionResponse> RunAction(ActionContext actionContext)
        {
            nodeService.DoSomething();
            ExampleForgeActionInput input = (ExampleForgeActionInput)actionContext.ActionInput ?? new ExampleForgeActionInput();
            Console.WriteLine($"OnExecuteAction - TreeNodeKey: {actionContext.TreeNodeKey}, ActionName: {actionContext.ActionName}, ActionInput: {input.SomeString}");

            return Task.FromResult(new ActionResponse() { Status = "Success", StatusCode = 0 });
        }
    }

    public class ExampleForgeActionInput
    {
        public string SomeString { get; set; }
    }
}
