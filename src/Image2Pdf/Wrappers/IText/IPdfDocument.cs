// <copyright file="IPdfDocument.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers.IText
{
    using System;
    using Image2Pdf.Wrappers;
    using iText.Kernel.Geom;
    using iText.Kernel.Pdf;

    /// <inheritdoc cref="PdfDocument"/>
    public interface IPdfDocument : IWrapper<PdfDocument>, IDisposable
    {
        /// <inheritdoc cref="PdfDocument.SetDefaultPageSize(PageSize)"/>
        void SetDefaultPageSize(IPageSize pageSize);

        /// <inheritdoc cref="PdfDocument.Close"/>
        void Close();
    }
}
