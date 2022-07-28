// <copyright file="MainWindowModel.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Image2Pdf.Generators;
    using Image2Pdf.Utilities;

    /// <summary>
    /// Implementation of <see cref="IMainWindowModel"/>.
    /// </summary>
    public class MainWindowModel : IMainWindowModel
    {
        /// <summary>
        /// The factory class of PDF generator.
        /// </summary>
        private readonly IPdfGeneratorFactory pdfGeneratorFactory;

        /// <summary>
        /// The filenames of images.
        /// </summary>
        private readonly List<string> filenames = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowModel"/> class.
        /// </summary>
        public MainWindowModel()
            : this(new PdfGeneratorFactory())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowModel"/> class.
        /// </summary>
        /// <param name="pdfGeneratorFactory">The factory class of PDF generator.</param>
        public MainWindowModel(IPdfGeneratorFactory pdfGeneratorFactory)
        {
            this.pdfGeneratorFactory = pdfGeneratorFactory;
        }

        /// <inheritdoc/>
        public event EventHandler<FileProcessedEventArgs>? FileProcessedEvent;

        /// <inheritdoc/>
        public event EventHandler<PdfGenerationCompletedEventArgs>? PdfGenerationCompletedEvent;

        /// <inheritdoc/>
        public IEnumerable<string> ItemSource => this.filenames;

        /// <inheritdoc/>
        public void AddFiles(params string[] files)
        {
            // Add valid image files only. Ignore others.
            this.filenames.AddRange(files.Where(FileUtils.IsValidImageFile));
        }

        /// <summary>
        /// Removes all files.
        /// </summary>
        public void Clear()
        {
            this.filenames.Clear();
        }

        /// <inheritdoc/>
        public void MoveUp(int index)
        {
            (this.filenames[index], this.filenames[index - 1]) = (this.filenames[index - 1], this.filenames[index]);
        }

        /// <inheritdoc/>
        public bool CanMoveUp(int index)
        {
            return index > 0 && index < this.filenames.Count;
        }

        /// <inheritdoc/>
        public void MoveDown(int index)
        {
            (this.filenames[index], this.filenames[index + 1]) = (this.filenames[index + 1], this.filenames[index]);
        }

        /// <inheritdoc/>
        public bool CanMoveDown(int index)
        {
            return index >= 0 && index < this.filenames.Count - 1;
        }

        /// <inheritdoc/>
        public void Remove(int index)
        {
            this.filenames.RemoveAt(index);
        }

        /// <inheritdoc/>
        public bool CanRemove(int index)
        {
            return index >= 0 && index < this.filenames.Count;
        }

        /// <inheritdoc/>
        public Task Generate(string pdfFilename)
        {
            // create PDF generator
            IPdfGenerator pdfGenerator = this.pdfGeneratorFactory.AddFiles(this.filenames).Build();

            pdfGenerator.FileProcessedEvent += (sender, e) => this.FileProcessedEvent?.Invoke(sender, e);
            pdfGenerator.PdfGenerationCompletedEvent += (sender, e) => this.PdfGenerationCompletedEvent?.Invoke(sender, e);
            return Task.Run(() => pdfGenerator.Generate(pdfFilename));
        }

        /// <inheritdoc/>
        public bool CanGenerate()
        {
            return this.filenames.Count > 0;
        }
    }
}
