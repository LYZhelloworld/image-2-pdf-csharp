// <copyright file="PdfAdapterFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Adapters
{
    /// <summary>
    /// The factory class of <see cref="IPdfAdapter"/>.
    /// </summary>
    public class PdfAdapterFactory : IPdfAdapterFactory
    {
        /// <inheritdoc/>
        public IPdfAdapter CreateAdapter()
        {
            return new PdfAdapter();
        }
    }
}