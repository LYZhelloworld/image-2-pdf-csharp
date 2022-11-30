// <copyright file="IPdfWriterFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers.IText
{
    using iText.Kernel.Pdf;

    /// <summary>
    /// The factory class of <see cref="IPdfWriter"/>.
    /// </summary>
    public interface IPdfWriterFactory
    {
        /// <inheritdoc cref="PdfWriter(string)"/>
        IPdfWriter FromFilename(string filename);
    }
}
