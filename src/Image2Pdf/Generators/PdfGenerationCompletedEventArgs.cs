// <copyright file="PdfGenerationCompletedEventArgs.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Generators
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The arguments of the PDF generation completed event.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class PdfGenerationCompletedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PdfGenerationCompletedEventArgs"/> class.
        /// </summary>
        /// <param name="pdfFilename">The PDF file name.</param>
        public PdfGenerationCompletedEventArgs(string pdfFilename)
        {
            this.PdfFilename = pdfFilename;
        }

        /// <summary>
        /// Gets the PDF file name.
        /// </summary>
        public string PdfFilename { get; init; }
    }
}
