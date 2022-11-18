// <copyright file="IPdfAdapterFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
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
        /// <param name="pdfFileName">The PDF filename.</param>
        /// <returns>The adapter.</returns>
        IPdfAdapter CreateInstance(string pdfFileName);
    }
}
