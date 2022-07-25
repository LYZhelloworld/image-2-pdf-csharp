// <copyright file="SystemDrawingImageFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.IO;

    /// <summary>
    /// Implementation of <see cref="ISystemDrawingImageFactory"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class SystemDrawingImageFactory : ISystemDrawingImageFactory
    {
        /// <inheritdoc/>
        public ISystemDrawingImage FromStream(Stream stream, bool useEmbeddedColorManagement, bool validateImageData)
        {
            return new SystemDrawingImageWrapper(Image.FromStream(stream, useEmbeddedColorManagement, validateImageData));
        }
    }
}