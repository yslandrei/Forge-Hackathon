using Autofac;
using System.Linq;
using System.Reflection;

namespace Microsoft.Forge.TreeWalker.Autofac
{
    public static class AutofacExtensions
    {
        public static ContainerBuilder RegisterForgeActionsFromAssembly(this ContainerBuilder builder, Assembly assembly)
        {
            var forgeActionTypes = assembly.GetTypes().Where(t => t.GetCustomAttributes(typeof(Attributes.ForgeActionAttribute), true).Length > 0);

            foreach (var t in forgeActionTypes)
            {
                builder.RegisterType(t)
                       .AsSelf()
                       .Keyed<BaseAction>(t)
                       .InstancePerDependency();
            }

            return builder;
        }

        public static ContainerBuilder RegisterForge(this ContainerBuilder builder)
        {
            builder.RegisterType<SubroutineAction>().AsSelf();

            builder.RegisterType<AutofacActionFactory>()
                   .As<IForgeActionFactory>()
                   .SingleInstance();

            builder.RegisterType<AutofacTreeWalkerSessionFactory>()
                   .As<ITreeWalkerSessionFactory>()
                   .SingleInstance();

            return builder;
        }
    }
}
