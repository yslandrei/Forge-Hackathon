//-----------------------------------------------------------------------
// <copyright file="IForgeActionFactory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//     The IForgeActionFactory interface.
// </summary>
//-----------------------------------------------------------------------

using System;

namespace Microsoft.Forge.TreeWalker
{
    /// <summary>
    /// The IForgeActionFactory interface defines the methods for creating instances of actions.
    /// This interface can be implemented to instantiate dependency injected actions via extensions to support different DI libraries.
    /// </summary>
    public interface IForgeActionFactory
    {
        /// <summary>
        /// Creates an instance of the given action type.
        /// </summary>
        /// <param name="type">The given action type.</param>
        /// <returns>The created action instance.</returns>
        BaseAction CreateInstance(Type type);

        /// <summary>
        /// Creates an instance of the given action type with the required parameters.
        /// Used exclusively for SubroutineAction types that require TreeWalkerParameters for initialization.
        /// </summary>
        /// <param name="type">The given action type.</param>
        /// <param name="parameters">The tree walker parameters of the parent tree walker session.</param>
        /// <returns>The created action instance.</returns>
        BaseAction CreateInstance(Type type, TreeWalkerParameters parameters);
    }
}