// <copyright file="IPdfWriter.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers.IText
{
    using System;
    using Image2Pdf.Wrappers;
    using iText.Kernel.Pdf;

    /// <inheritdoc cref="PdfWriter"/>
    public interface IPdfWriter : IWrapper<PdfWriter>, IDisposable
    {
    }
}
