// <copyright file="IPdfWriter.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
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
