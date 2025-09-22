using Microsoft.Extensions.DependencyInjection;
using Microsoft.Forge.TreeWalker;

namespace Forge.TreeWalker.Microsoft.DependencyInjection;

public class NativeDITreeWalkerSessionFactory : ITreeWalkerSessionFactory
{
    private IServiceProvider _serviceProvider;
    public NativeDITreeWalkerSessionFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public TreeWalkerSession CreateInstance(TreeWalkerParameters parameters)
    {
        return new TreeWalkerSession(parameters, _serviceProvider.GetRequiredService<IForgeActionFactory>());
    }
}
