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
            return (BaseAction) _container.Resolve(type);
        }

        public BaseAction CreateInstance(Type type, TreeWalkerParameters parameters)
        {
            return (BaseAction) _container.Resolve(type, new NamedParameter("parameters", parameters));
        }
    }
}
