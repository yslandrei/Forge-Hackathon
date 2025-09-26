using Autofac;
using System;

namespace Microsoft.Forge.TreeWalker.Autofac
{
    public class AutofacActionFactory : IForgeActionFactory
    {
        private readonly IComponentContext _container;

        public AutofacActionFactory(IComponentContext container)
        {
            _container = container;
        }

        public BaseAction CreateInstance(Type type)
        {
            return _container.ResolveKeyed<BaseAction>(type);
        }

        public BaseAction CreateInstance(Type type, TreeWalkerParameters parameters)
        {
            return _container.ResolveKeyed<BaseAction>(type, new NamedParameter("parameters", parameters));
        }
    }
}
