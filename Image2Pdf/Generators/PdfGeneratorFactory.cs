// <copyright file="PdfGeneratorFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Generators
{
    using System.Collections.Generic;
    using System.Linq;
    using Image2Pdf.Adapters;

    /// <inheritdoc/>
    public class PdfGeneratorFactory : IPdfGeneratorFactory
    {
        /// <summary>
        /// The PDF adapter factory.
        /// </summary>
        private readonly IPdfAdapterFactory pdfAdapterFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="PdfGeneratorFactory"/> class.
        /// </summary>
        /// <param name="pdfAdapterFactory">The PDF adapter factory.</param>
        public PdfGeneratorFactory(IPdfAdapterFactory pdfAdapterFactory)
        {
            this.pdfAdapterFactory = pdfAdapterFactory;
        }

        /// <inheritdoc/>
        public IPdfGenerator CreateInstance(IEnumerable<string> files)
        {
            return new PdfGenerator(files, this.pdfAdapterFactory);
        }
    }
}
