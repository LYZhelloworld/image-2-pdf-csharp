// <copyright file="SystemDrawingImageFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
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