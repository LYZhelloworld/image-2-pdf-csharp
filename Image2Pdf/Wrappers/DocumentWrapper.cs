// <copyright file="DocumentWrapper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System.Diagnostics.CodeAnalysis;
    using iText.Layout;

    /// <summary>
    /// Implementation of <see cref="IDocument"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class DocumentWrapper : Wrapper<Document>, IDocument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentWrapper"/> class.
        /// </summary>
        /// <param name="document">The wrapped object.</param>
        internal DocumentWrapper(Document document)
            : base(document)
        {
        }

        /// <inheritdoc/>
        public void SetMargins(float topMargin, float rightMargin, float bottomMargin, float leftMargin)
        {
            this.Unwrap().SetMargins(topMargin, rightMargin, bottomMargin, leftMargin);
        }

        /// <inheritdoc/>
        public IDocument Add(IAreaBreak areaBreak)
        {
            this.Unwrap().Add(areaBreak.Unwrap());
            return this;
        }

        /// <inheritdoc/>
        public IDocument Add(IImage image)
        {
            this.Unwrap().Add(image.Unwrap());
            return this;
        }

        /// <inheritdoc/>
        public void Close()
        {
            this.Unwrap().Close();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Close();
        }
    }
}
