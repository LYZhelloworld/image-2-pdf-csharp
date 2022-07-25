// <copyright file="IPdfWriter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System;
    using iText.Kernel.Pdf;

    /// <summary>
    /// The wrapper class of <see cref="PdfWriter"/>.
    /// </summary>
    public interface IPdfWriter : IWrapper<PdfWriter>, IDisposable
    {
    }
}