// <copyright file="IPdfGenerator.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Generators
{
    using System;

    /// <summary>
    /// The PDF file generator.
    /// </summary>
    /// <typeparam name="TFileProcessedEventArgs">The type of the arguments of <see cref="FileProcessedEvent"/>.</typeparam>
    /// <typeparam name="TPdfGenerationCompletedEventArgs">The type of the arguments of <see cref="PdfGenerationCompletedEvent"/>.</typeparam>
    public interface IPdfGenerator<TFileProcessedEventArgs, TPdfGenerationCompletedEventArgs>
        where TFileProcessedEventArgs : EventArgs
        where TPdfGenerationCompletedEventArgs : EventArgs
    {
        /// <summary>
        /// The event that a file has been processed.
        /// </summary>
        public event EventHandler<TFileProcessedEventArgs>? FileProcessedEvent;

        /// <summary>
        /// The event that the PDF has been generated.
        /// </summary>
        public event EventHandler<TPdfGenerationCompletedEventArgs>? PdfGenerationCompletedEvent;

        /// <summary>
        /// Generates PDF file.
        /// </summary>
        /// <param name="target">The PDF file location.</param>
        public void Generate(string target);
    }

    /// <summary>
    /// The PDF file generator.
    /// </summary>
    public interface IPdfGenerator : IPdfGenerator<FileProcessedEventArgs, PdfGenerationCompletedEventArgs>
    {
    }
}
