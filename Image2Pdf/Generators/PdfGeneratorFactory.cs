// <copyright file="PdfGeneratorFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Generators
{
    using System.Collections.Generic;

    /// <inheritdoc/>
    public class PdfGeneratorFactory : IPdfGeneratorFactory
    {
        /// <summary>
        /// The image filenames.
        /// </summary>
        private readonly List<string> files;

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfGeneratorFactory"/> class.
        /// </summary>
        public PdfGeneratorFactory()
        {
            this.files = new List<string>();
        }

        /// <inheritdoc/>
        public IPdfGeneratorFactory AddFiles(IEnumerable<string> files)
        {
            this.files.AddRange(files);
            return this;
        }

        /// <inheritdoc/>
        public IPdfGenerator Build()
        {
            return new PdfGenerator(this.files);
        }
    }
}
