using Microsoft.Forge.TreeWalker;

namespace Microsoft.Forge.TreeWalker.UnityExtensions
{
    public class UnityTreeWalkerSessionFactory : ITreeWalkerSessionFactory
    {
        private readonly IForgeActionFactory actionFactory;

        public UnityTreeWalkerSessionFactory(IForgeActionFactory actionFactory)
        {
            this.actionFactory = actionFactory;
        }

        public TreeWalkerSession CreateInstance(TreeWalkerParameters parameters)
        {
            return new TreeWalkerSession(parameters, actionFactory);
        }
    }
}
