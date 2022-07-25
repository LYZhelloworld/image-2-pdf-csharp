// <copyright file="SystemDrawingImageWrapper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;

    /// <summary>
    /// Implementation of <see cref="ISystemDrawingImage"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class SystemDrawingImageWrapper : Wrapper<Image>, ISystemDrawingImage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemDrawingImageWrapper"/> class.
        /// </summary>
        /// <param name="image">The wrapped object.</param>
        internal SystemDrawingImageWrapper(Image image)
            : base(image)
        {
        }

        /// <inheritdoc/>
        public int Width { get => this.Unwrap().Width; }

        /// <inheritdoc/>
        public int Height { get => this.Unwrap().Height; }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Unwrap().Dispose();
        }
    }
}
