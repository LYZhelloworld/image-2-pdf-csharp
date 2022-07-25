// <copyright file="IPdfAdapterFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Adapters
{
    /// <summary>
    /// The factory class of <see cref="IPdfAdapter"/>.
    /// </summary>
    public interface IPdfAdapterFactory
    {
        /// <summary>
        /// Creates default PDF adapter.
        /// </summary>
        /// <returns>The adapter.</returns>
        IPdfAdapter CreateAdapter();
    }
}