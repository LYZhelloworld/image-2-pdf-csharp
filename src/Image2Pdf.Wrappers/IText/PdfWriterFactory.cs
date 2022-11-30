// <copyright file="PdfWriterFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers.IText
{
    using iText.Kernel.Pdf;

    /// <inheritdoc cref="IPdfWriterFactory"/>
    internal class PdfWriterFactory : IPdfWriterFactory
    {
        /// <inheritdoc/>
        public IPdfWriter CreateInstance(string filename)
        {
            return new PdfWriterWrapper(new PdfWriter(filename));
        }
    }
}
