
namespace Microsoft.Forge.TreeWalker.Autofac
{
    public class AutofacTreeWalkerSessionFactory : ITreeWalkerSessionFactory
    {
        private readonly IForgeActionFactory actionFactory;

        public AutofacTreeWalkerSessionFactory(IForgeActionFactory actionFactory)
        {
            this.actionFactory = actionFactory;
        }

        public TreeWalkerSession CreateInstance(TreeWalkerParameters parameters)
        {
            return new TreeWalkerSession(parameters, actionFactory);
        }
    }
}
