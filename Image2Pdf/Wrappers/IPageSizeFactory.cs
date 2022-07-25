// <copyright file="IPageSizeFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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