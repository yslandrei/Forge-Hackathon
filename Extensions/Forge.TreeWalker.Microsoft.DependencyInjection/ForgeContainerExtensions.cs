using Microsoft.Extensions.DependencyInjection;
using Microsoft.Forge.Attributes;
using Microsoft.Forge.TreeWalker;
using System.Reflection;

namespace Forge.TreeWalker.Microsoft.DependencyInjection
{
    public static class ForgeContainerExtensions
    {
        public static IServiceCollection RegisterForgeActionsFromAssembly(this IServiceCollection container, Assembly assembly)
        {
            // scan the aseembly for forge actions
            var forgeActionTypes = assembly.GetTypes().Where(t => t.GetCustomAttributes(typeof(ForgeActionAttribute), true).Length > 0);
            foreach (var t in forgeActionTypes)
            {
                container.AddTransient(t,t);
            }
            return container;
        }

        public static IServiceCollection RegisterForge(this IServiceCollection container)
        {

            // Register default SubroutineAction
            container.AddTransient<SubroutineAction>(); // Deafult registration

            //Register ForgeActionFactory
            container.AddTransient<IForgeActionFactory, MicrosoftDIForgeActionFactory>();

            //Register TreeWalkerSessionFactory
            container.AddTransient<ITreeWalkerSessionFactory, MicrosoftDITreeWalkerSessionFactory>();

            return container;
        }
    }
}
