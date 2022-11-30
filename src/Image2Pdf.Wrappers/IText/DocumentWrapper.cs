// <copyright file="DocumentWrapper.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers.IText
{
    using Image2Pdf.Wrappers;
    using iText.Layout;

    /// <inheritdoc cref="Document"/>
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
        public IDocument Add(IImage element)
        {
            this.Unwrap().Add(element.Unwrap());
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
