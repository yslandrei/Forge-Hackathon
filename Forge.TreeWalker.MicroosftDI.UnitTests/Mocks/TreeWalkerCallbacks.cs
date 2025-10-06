using Microsoft.Forge.TreeWalker;

namespace Forge.TreeWalker.Microosft.DI.UnitTests.Mocks
{
    public class TreeWalkerCallbacks : ITreeWalkerCallbacksV2
    {
        public Task BeforeVisitNode(TreeNodeContext treeNodeContext)
        {
            Console.WriteLine($"OnBeforeVisitNode - TreeNodeKey: {treeNodeContext.TreeNodeKey}");
            return Task.CompletedTask;
        }

        public Task AfterVisitNode(TreeNodeContext treeNodeContext)
        {
            Console.WriteLine($"OnAfterVisitNode - TreeNodeKey: {treeNodeContext.TreeNodeKey}");
            return Task.CompletedTask;
        }
    }
    public class ForgeUserContext
    {
        public string ResourceType { get; set; }

        public ForgeUserContext(string resourceType)
        {
            this.ResourceType = resourceType;
        }

        public string GetResourceType()
        {
            return this.ResourceType;
        }
    }
}
