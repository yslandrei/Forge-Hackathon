//-----------------------------------------------------------------------
// <copyright file="ForgeDIExecutionTests.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//     ForgeAction for testing purposes
// </summary>
//-----------------------------------------------------------------------

using Forge.TreeWalker.Microosft.DI.UnitTests.Mocks;
using Forge.TreeWalker.Microsoft.DependencyInjection;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Forge.DataContracts;
using Microsoft.Forge.TreeWalker;
using Moq;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Reflection;

namespace Forge.TreeWalker.Microosft.DI.UnitTests.IntegrationTests
{
    /// <summary>
    /// Tests setting up Forge DI and executing a tree walk for integration testing purposes.
    /// </summary>
    [TestClass]
    public class ForgeDIExecutionTests
    {
        [TestMethod]
        public async Task ShouldExecuteTreeWalkWithDI()
        {
            // Arrange
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.RegisterForgeActionsFromAssembly(Assembly.GetExecutingAssembly());
            serviceCollection.RegisterForge();
            // Register custom services
            // Mock implementation of IMockedTestService
            var mockTestService = new Mock<IMockedTestService>();
            serviceCollection.AddTransient((_) => mockTestService.Object);


            var serviceProvider = serviceCollection.BuildServiceProvider();
            var factory = serviceProvider.GetService<ITreeWalkerSessionFactory>();
            Assert.IsNotNull(factory);
            string jsonSchema = File.ReadAllText("json1.json");

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


            var treeWalkerSession = factory.CreateInstance(parameters);
            // Act
            await treeWalkerSession.WalkTree("Root");
            
            // Assert
            mockTestService.Verify(service => service.Execute(), Times.AtLeastOnce);

            // If no exceptions are thrown, the test passes.
        }

    }
}
