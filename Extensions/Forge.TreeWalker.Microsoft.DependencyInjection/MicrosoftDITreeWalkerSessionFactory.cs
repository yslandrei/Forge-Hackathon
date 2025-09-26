using Microsoft.Extensions.DependencyInjection;
using Microsoft.Forge.TreeWalker;

namespace Forge.TreeWalker.Microsoft.DependencyInjection;

public class MicrosoftDITreeWalkerSessionFactory : ITreeWalkerSessionFactory
{
    private readonly IServiceProvider _serviceProvider;
    public MicrosoftDITreeWalkerSessionFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public TreeWalkerSession CreateInstance(TreeWalkerParameters parameters)
    {
        return new TreeWalkerSession(parameters, _serviceProvider.GetRequiredService<IForgeActionFactory>());
    }
}
