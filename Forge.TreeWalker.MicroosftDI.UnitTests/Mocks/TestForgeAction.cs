//-----------------------------------------------------------------------
// <copyright file="TestForgeAction.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//     ForgeAction for testing purposes
// </summary>
//-----------------------------------------------------------------------

using Microsoft.Forge.Attributes;
using Microsoft.Forge.TreeWalker;

namespace Forge.TreeWalker.Microosft.DI.UnitTests.Mocks
{

    [ForgeAction(typeof(TestForgeActionInput))]
    public class TestForgeAction : BaseAction
    {
        private readonly IMockedTestService _testService;

        public TestForgeAction(IMockedTestService testService)
        {
            _testService = testService;
        }
        public override Task<ActionResponse> RunAction(ActionContext actionContext)
        {
            _testService.Execute();
            return Task.FromResult(new ActionResponse());
        }
    }

    public class TestForgeActionInput { }

}
