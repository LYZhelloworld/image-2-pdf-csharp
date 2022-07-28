// <copyright file="ISystemDrawingImageFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System.IO;

    /// <summary>
    /// The factory class of <see cref="ISystemDrawingImage"/>.
    /// </summary>
    public interface ISystemDrawingImageFactory
    {
        /// <summary>
        /// The wrapper method of <see cref="System.Drawing.Image.FromStream(Stream, bool, bool)"/>.
        /// </summary>
        /// <param name="fileStream">The file stream.</param>
        /// <param name="useEmbeddedColorManagement">Whether to use embedded color management.</param>
        /// <param name="validateImageData">Whether to validate image data.</param>
        /// <returns>The wrapper class of <see cref="System.Drawing.Image"/>.</returns>
        ISystemDrawingImage FromStream(Stream fileStream, bool useEmbeddedColorManagement, bool validateImageData);
    }
}
