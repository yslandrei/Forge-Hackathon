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
    internal class TestForgeAction : BaseAction
    {
        public override Task<ActionResponse> RunAction(ActionContext actionContext)
        {
            return Task.FromResult(new ActionResponse());
        }
    }

    internal class TestForgeActionInput { }
}
