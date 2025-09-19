using Microsoft.Forge.TreeWalker;
using System;
using System.Linq;
using System.Reflection;
using Unity;
using Unity.Injection;

namespace Microsoft.Forge.TreeWalker.UnityExtensions
{
    public static class ForgeContainerExtensions
    {
        public static IUnityContainer RegisterForgeActionsFromAssembly(this IUnityContainer container, Assembly assembly)
        {
            // scan the aseembly for forge actions
            var forgeActionTypes = assembly.GetTypes().Where(t => t.GetCustomAttributes(typeof(Attributes.ForgeActionAttribute), true).Length > 0);
            foreach (var t in forgeActionTypes)
            {
                container.RegisterType(t);
            }
            return container;
        }

        public static IUnityContainer RegisterForge(this IUnityContainer container)
        {

            // Register default SubroutineAction
            container.RegisterType(typeof(SubroutineAction)); // Deafult registration

            //Register ForgeActionFactory
            container.RegisterType<IForgeActionFactory, UnityContainerActionFactory>(new InjectionConstructor(container));

            //Register TreeWalkerSessionFactory
            container.RegisterType<ITreeWalkerSessionFactory, UnityTreeWalkerSessionFactory>(new InjectionConstructor(container.Resolve<IForgeActionFactory>()));

            return container;
        }
    }
}
