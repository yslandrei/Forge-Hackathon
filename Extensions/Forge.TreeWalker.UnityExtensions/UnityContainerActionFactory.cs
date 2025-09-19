using Microsoft.Forge.TreeWalker;
using System;
using Unity;
using Unity.Resolution;

namespace Microsoft.Forge.TreeWalker.UnityExtensions
{
    public class UnityContainerActionFactory : IForgeActionFactory
    {
        private readonly IUnityContainer container;

        public UnityContainerActionFactory(IUnityContainer container)
        {
            this.container = container;
        }

        public BaseAction CreateInstance(Type type)
        {
            return container.Resolve(type) as BaseAction;
        }

        public BaseAction CreateInstance(Type type, TreeWalkerParameters parameters)
        {
            return container.Resolve(type, new ParameterOverride("parameters", parameters)) as BaseAction;
        }
    }
}
