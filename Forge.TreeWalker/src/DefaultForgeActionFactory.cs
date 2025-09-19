//-----------------------------------------------------------------------
// <copyright file="DefaultForgeActionFactory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//     The DefaultForgeActionFactory class.
// </summary>
//-----------------------------------------------------------------------

using System;

namespace Microsoft.Forge.TreeWalker
{
    /// <summary>
    /// The default implementation of the IForgeActionFactory interface featuring direct instantiation via simple Activator.CreateInstance calls.
    /// </summary>
    public class DefaultForgeActionFactory : IForgeActionFactory
    {
        public BaseAction CreateInstance(Type type)
        {
            return Activator.CreateInstance(type) as BaseAction;
        }

        public BaseAction CreateInstance(Type type, TreeWalkerParameters parameters)
        {
            return Activator.CreateInstance(type, parameters) as BaseAction;
        }
    }
}