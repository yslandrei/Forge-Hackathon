//-----------------------------------------------------------------------
// <copyright file="ForgeActionFactoryTests.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//     Tests the ForgeActionFactory class.
// </summary>
//-----------------------------------------------------------------------

using Forge.TreeWalker.Microosft.DI.UnitTests.Mocks;
using Forge.TreeWalker.Microsoft.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Forge.TreeWalker;
using System.Reflection;

namespace Forge.TreeWalker.Microosft.DI.UnitTests
{
    [TestClass]
    public sealed class ForgeActionFactoryTests

    {
        [TestMethod]
        public void ShouldResolveForgeActionFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.RegisterForgeActionsFromAssembly(Assembly.GetExecutingAssembly());
            serviceCollection.RegisterForge();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var factory = serviceProvider.GetService<IForgeActionFactory>();

            Assert.IsNotNull(factory);
        }

        [TestMethod]
        public void FactoryShouldCreateActionInstance()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.RegisterForgeActionsFromAssembly(Assembly.GetExecutingAssembly());
            serviceCollection.RegisterForge();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var factory = serviceProvider.GetRequiredService<IForgeActionFactory>();
            var testAction = factory.CreateInstance(typeof(TestForgeAction));

            Assert.IsNotNull(testAction);
            Assert.IsInstanceOfType(testAction, typeof(TestForgeAction));
        }
    }
}
