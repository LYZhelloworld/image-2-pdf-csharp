// <copyright file="IPdfWriterFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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