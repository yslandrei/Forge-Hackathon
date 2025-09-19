//-----------------------------------------------------------------------
// <copyright file="ITreeWalkerSessionFactory.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//     The ITreeWalkerSessionFactory interface.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.Forge.TreeWalker
{
    /// <summary>
    /// The ITreeWalkerSessionFactory interface defines the methods for creating instances of TreeWalkerSessions.
    /// This interface can be implemented to instantiate dependency injected TreeWalkerSessions via extensions to support different DI libraries.
    /// </summary>
    public interface ITreeWalkerSessionFactory
    {
        /// <summary>
        /// Creates an instance of TreeWalkerSession with the required parameters.
        /// </summary>
        /// <param name="parameters">The parameters object contains the required and optional properties used by the TreeWalkerSession.</param>
        /// <returns>The TreeWalkerSession instance.</returns>
        TreeWalkerSession CreateInstance(TreeWalkerParameters parameters);
    }
}
