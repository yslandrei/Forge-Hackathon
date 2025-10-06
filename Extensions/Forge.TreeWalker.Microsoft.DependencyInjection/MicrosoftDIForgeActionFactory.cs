using Microsoft.Extensions.DependencyInjection;
using Microsoft.Forge.TreeWalker;

namespace Forge.TreeWalker.Microsoft.DependencyInjection
{
    internal class MicrosoftDIForgeActionFactory : IForgeActionFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public MicrosoftDIForgeActionFactory(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public BaseAction CreateInstance(Type type)
        {
            return (BaseAction)_serviceProvider.GetRequiredService(type);
        }

        public BaseAction CreateInstance(Type type, TreeWalkerParameters parameters)
        {
            return (BaseAction)ActivatorUtilities.CreateInstance(_serviceProvider, type, parameters);
        }
    }
}
