// <copyright file="ISystemDrawingImageFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers.SystemDrawing
{
    using System.Drawing;
    using System.IO;

    /// <summary>
    /// The factory class of <see cref="ISystemDrawingImage"/>.
    /// </summary>
    public interface ISystemDrawingImageFactory
    {
        /// <inheritdoc cref="Image.FromStream(Stream, bool, bool)"/>
        ISystemDrawingImage CreateInstance(Stream stream, bool useEmbeddedColorManagement, bool validateImageData);
    }
}
