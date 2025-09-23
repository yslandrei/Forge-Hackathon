//-----------------------------------------------------------------------
// <copyright file="TreeWalkerSessionFactoryTests.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//     Tests the TreeWalkerSessionFactory class.
// </summary>
//-----------------------------------------------------------------------

using Forge.TreeWalker.Microsoft.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Forge.TreeWalker;
using System.Reflection;

namespace Forge.TreeWalker.Microosft.DI.UnitTests
{
    [TestClass]
    public class TreeWalkerSessionFactoryTests
    {
        [TestMethod]
        public void ShouldResolveTreeWalkerSessionFactory()
        {
            // Arrange
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.RegisterForgeActionsFromAssembly(Assembly.GetExecutingAssembly());
            serviceCollection.RegisterForge();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            // Act
            var factory = serviceProvider.GetService<ITreeWalkerSessionFactory>();

            // Assert
            Assert.IsNotNull(factory);
        }
    }
}
