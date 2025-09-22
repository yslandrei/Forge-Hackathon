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
            return _container.Resolve(type) as BaseAction;
        }

        public BaseAction CreateInstance(Type type, TreeWalkerParameters parameters)
        {
            return _container.Resolve(type, new NamedParameter("parameters", parameters)) as BaseAction;
        }
    }
}
