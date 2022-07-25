// <copyright file="IMainWindowModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Models
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Image2Pdf.Generators;

    /// <summary>
    /// The model of <see cref="MainWindow"/>.
    /// </summary>
    public interface IMainWindowModel
    {
        /// <summary>
        /// The event that a file has been processed.
        /// </summary>
        event EventHandler<FileProcessedEventArgs>? FileProcessedEvent;

        /// <summary>
        /// The event that the PDF has been generated.
        /// </summary>
        event EventHandler<PdfGenerationCompletedEventArgs>? PdfGenerationCompletedEvent;

        /// <summary>
        /// Gets the item source.
        /// </summary>
        IEnumerable<string> ItemSource { get; }

        /// <summary>
        /// Adds image files to the list.
        /// </summary>
        /// <param name="files">The filenames to add.</param>
        void AddFiles(params string[] files);

        /// <summary>
        /// Removes all files.
        /// </summary>
        void Clear();

        /// <summary>
        /// The command to move up an item.
        /// </summary>
        /// <param name="index">The index of the selected item.</param>
        void MoveUp(int index);

        /// <summary>
        /// Indicates whether <see cref="MoveUp(int)"/> can be executed.
        /// </summary>
        /// <param name="index">The index of the selected item.</param>
        /// <returns>Whether <see cref="MoveUp(int)"/> can be executed.</returns>
        bool CanMoveUp(int index);

        /// <summary>
        /// The command to move down an item.
        /// </summary>
        /// <param name="index">The index of the selected item.</param>
        void MoveDown(int index);

        /// <summary>
        /// Indicates whether <see cref="MoveDown(int)"/> can be executed.
        /// </summary>
        /// <param name="index">The index of the selected item.</param>
        /// <returns>Whether <see cref="MoveDown(int)"/> can be executed.</returns>
        bool CanMoveDown(int index);

        /// <summary>
        /// The command to remove an item.
        /// </summary>
        /// <param name="index">The index of the selected item.</param>
        void Remove(int index);

        /// <summary>
        /// Indicates whether <see cref="Remove(int)"/> can be executed.
        /// </summary>
        /// <param name="index">The index of the selected item.</param>
        /// <returns>Whether <see cref="Remove(int)"/> can be executed.</returns>
        bool CanRemove(int index);

        /// <summary>
        /// The command to remove an item.
        /// </summary>
        /// <param name="pdfFilename">The PDF filename.</param>
        /// <returns>A <see cref="Task"/> that does PDF generation.</returns>
        Task Generate(string pdfFilename);

        /// <summary>
        /// Indicates whether <see cref="Generate"/> can be executed.
        /// </summary>
        /// <returns>Whether <see cref="Generate"/> can be executed.</returns>
        bool CanGenerate();
    }
}
