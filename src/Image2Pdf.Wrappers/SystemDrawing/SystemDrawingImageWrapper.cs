// <copyright file="SystemDrawingImageWrapper.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers.SystemDrawing
{
    using System.Drawing;
    using System.Runtime.Versioning;
    using Image2Pdf.Wrappers;

    /// <inheritdoc cref="ISystemDrawingImage"/>
    internal class SystemDrawingImageWrapper : Wrapper<Image>, ISystemDrawingImage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemDrawingImageWrapper"/> class.
        /// </summary>
        /// <param name="image">The wrapped object.</param>
        [SupportedOSPlatform("windows")]
        internal SystemDrawingImageWrapper(Image image)
            : base(image)
        {
        }

        /// <inheritdoc/>
        [SupportedOSPlatform("windows")]
        public int Width { get => this.Unwrap().Width; }

        /// <inheritdoc/>
        [SupportedOSPlatform("windows")]
        public int Height { get => this.Unwrap().Height; }

        /// <inheritdoc/>
        [SupportedOSPlatform("windows")]
        public void Dispose()
        {
            this.Unwrap().Dispose();
        }
    }
}
