// <copyright file="IPdfDocument.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System;
    using iText.Kernel.Geom;
    using iText.Kernel.Pdf;

    /// <summary>
    /// The wrapper class of <see cref="PdfDocument"/>.
    /// </summary>
    public interface IPdfDocument : IWrapper<PdfDocument>, IDisposable
    {
        /// <summary>
        /// The wrapper method of <see cref="PdfDocument.SetDefaultPageSize(PageSize)"/>.
        /// </summary>
        /// <param name="pageSize">The page size.</param>
        void SetDefaultPageSize(IPageSize pageSize);

        /// <summary>
        /// The wrapper method of <see cref="PdfDocument.Close"/>.
        /// </summary>
        void Close();
    }
}