// <copyright file="IPdfWriterFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers
{
    /// <summary>
    /// The factory class of <see cref="IPdfWriter"/>.
    /// </summary>
    public interface IPdfWriterFactory
    {
        /// <summary>
        /// The wrapper method of <see cref="iText.Kernel.Pdf.PdfWriter.PdfWriter(string)"/>.
        /// </summary>
        /// <param name="filename">The filename of the PDF.</param>
        /// <returns>The <see cref="IPdfWriter"/> instance.</returns>
        IPdfWriter FromFilename(string filename);
    }
}