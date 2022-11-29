// <copyright file="PdfWriterFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System.Diagnostics.CodeAnalysis;
    using iText.Kernel.Pdf;

    /// <inheritdoc cref="IPdfWriterFactory"/>
    [ExcludeFromCodeCoverage]
    internal class PdfWriterFactory : IPdfWriterFactory
    {
        /// <inheritdoc/>
        public IPdfWriter FromFilename(string filename)
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            return new PdfWriterWrapper(new PdfWriter(filename));
#pragma warning restore CA2000 // Dispose objects before losing scope
        }
    }
}
