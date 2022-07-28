// <copyright file="IPageSizeFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using iText.Kernel.Geom;

    /// <summary>
    /// The factory class of <see cref="IPageSize"/>.
    /// </summary>
    public interface IPageSizeFactory
    {
        /// <summary>
        /// The wrapper method of <see cref="PageSize(float, float)"/>.
        /// </summary>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns>The <see cref="IPageSize"/> instance.</returns>
        IPageSize FromWidthAndHeight(float width, float height);
    }
}