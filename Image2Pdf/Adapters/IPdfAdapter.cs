// <copyright file="IPdfAdapter.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Adapters
{
    using System;

    /// <summary>
    /// The adapter of PDF generator.
    /// </summary>
    public interface IPdfAdapter : IDisposable
    {
        /// <summary>
        /// Adds a page with image as background.
        /// </summary>
        /// <param name="imageFilename">The filename of the image.</param>
        void AddPageWithImage(string imageFilename);

        /// <summary>
        /// Saves and closes PDF document.
        /// </summary>
        void Close();
    }
}
