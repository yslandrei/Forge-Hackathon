using Autofac;
using System.Reflection;

namespace Microsoft.Forge.TreeWalker.Autofac
{
    public static class AutofacExtensions
    {
        public static ContainerBuilder RegisterForgeActionsFromAssembly(this ContainerBuilder builder, Assembly assembly)
        {
            builder.RegisterAssemblyTypes(assembly)
                   .Where(t => t.GetCustomAttributes(typeof(Attributes.ForgeActionAttribute), true).Length > 0)
                   .AsSelf()
                   .InstancePerDependency();

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
