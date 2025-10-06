using Forge.Examples.MicrosoftDI;
using Forge.TreeWalker.Microsoft.DependencyInjection;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Forge.DataContracts;
using Microsoft.Forge.TreeWalker;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Reflection;

IServiceCollection services = new ServiceCollection();
services.AddTransient<INodeService, NodeService>(); // Register mock service dependency in the example action
services.RegisterForge(); // Register core Forge services
services.RegisterForgeActionsFromAssembly(Assembly.GetExecutingAssembly()); // Register all forge actions in the current assembly
ServiceProvider serviceProvider = services.BuildServiceProvider();



void HandleRequest()
{


    // Initialize a TreeWalkerSession, walk the provided ForgeTree schema starting at the "Root" node, and print the results.
    Console.WriteLine("OnBeforeWalkTree - TreeNodeKey: Root");
    //read json file
    string schema = File.ReadAllText("json1.json");

    // Walkt the tree.
    TreeWalkerSession session = InitializeSession(jsonSchema: schema);

    // Walk the tree starting at the "Root" node.
    var resultTask = session.WalkTree("Root");
    var resultTaskAwaiter = resultTask.GetAwaiter();
    resultTask.Wait();
    resultTaskAwaiter.OnCompleted(() => OnAfterWalkTree(session, resultTaskAwaiter.GetResult()));

    // After walking the tree, user should observe the execution of injected service code.
}
void OnAfterWalkTree(TreeWalkerSession session, string result)
{
    Console.WriteLine($"OnAfterWalkTree - TreeNodeKey: {session.GetCurrentTreeNode().Result}, TreeWalkerStatus: {result}");
}


TreeWalkerSession InitializeSession(string jsonSchema)
{
    // Initialize required properties.
    Guid sessionId = Guid.NewGuid();
    ForgeTree forgeTree = JsonConvert.DeserializeObject<ForgeTree>(jsonSchema);
    IForgeDictionary forgeState = new ForgeDictionary(new Dictionary<string, object>(), sessionId, sessionId);
    ITreeWalkerCallbacksV2 callbacks = new TreeWalkerCallbacks();
    CancellationToken token = new CancellationTokenSource().Token;

    // Initialize optional properties
    ForgeUserContext userContext = new ForgeUserContext("Container");

    TreeWalkerParameters parameters = new TreeWalkerParameters(
        sessionId,
        forgeTree,
        forgeState,
        callbacks,
        token)
    {
        UserContext = userContext,
        ForgeActionsAssembly = Assembly.GetExecutingAssembly(),
        ScriptCache = new ConcurrentDictionary<string, Script<object>>()
    };

    // Get the factory for creating TreeWalkerSession instances from the service provider and create an instance.
    var treeWalkerSessionFactory = serviceProvider.GetRequiredService<ITreeWalkerSessionFactory>();

    // Create parameterized instance from the parameters object.
    return treeWalkerSessionFactory.CreateInstance(parameters);
}

// Simulate handling a request.
HandleRequest();