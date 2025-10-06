//-----------------------------------------------------------------------
// <copyright file="IMockedTestService.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//     ForgeAction for testing purposes
// </summary>
//-----------------------------------------------------------------------

namespace Forge.TreeWalker.Microosft.DI.UnitTests.Mocks
{
    public interface IMockedTestService
    {
        public void Execute();
        public Task ExecuteAsync();
    }

    public class MockedTestService : IMockedTestService
    {
        public void Execute()
        {
        }

        public Task ExecuteAsync()
        {
            return Task.CompletedTask;
        }
    }
}
