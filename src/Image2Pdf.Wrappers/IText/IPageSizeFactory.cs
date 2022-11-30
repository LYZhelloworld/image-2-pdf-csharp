// <copyright file="IPageSizeFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers.IText
{
    using iText.Kernel.Geom;

    /// <summary>
    /// The factory class of <see cref="IPageSize"/>.
    /// </summary>
    public interface IPageSizeFactory
    {
        /// <inheritdoc cref="PageSize(float, float)"/>
        IPageSize FromWidthAndHeight(float width, float height);
    }
}
