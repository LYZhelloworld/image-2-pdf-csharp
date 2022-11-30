// <copyright file="SystemDrawingImageFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers.SystemDrawing
{
    using System.Drawing;
    using System.IO;
    using System.Runtime.Versioning;

    /// <inheritdoc cref="ISystemDrawingImageFactory"/>
    internal class SystemDrawingImageFactory : ISystemDrawingImageFactory
    {
        /// <inheritdoc/>
        [SupportedOSPlatform("windows")]
        public ISystemDrawingImage CreateInstance(Stream stream, bool useEmbeddedColorManagement, bool validateImageData)
        {
            return new SystemDrawingImageWrapper(Image.FromStream(stream, useEmbeddedColorManagement, validateImageData));
        }
    }
}
