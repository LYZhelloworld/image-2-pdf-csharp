// <copyright file="FileProcessedEventArgs.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Generators
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The arguments of the file processed event.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class FileProcessedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileProcessedEventArgs"/> class.
        /// </summary>
        /// <param name="filename">The file processed.</param>
        /// <param name="progress">The number of files processed.</param>
        public FileProcessedEventArgs(string filename, int progress)
        {
            this.Filename = filename;
            this.Progress = progress;
        }

        /// <summary>
        /// Gets the file processed.
        /// </summary>
        public string Filename { get; init; }

        /// <summary>
        /// Gets the number of files processed.
        /// </summary>
        public int Progress { get; init; }
    }
}
