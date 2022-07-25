// <copyright file="PdfWriterFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System.Diagnostics.CodeAnalysis;
    using iText.Kernel.Pdf;

    /// <summary>
    /// Implementation of <see cref="IPdfWriterFactory"/>.
    /// </summary>
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