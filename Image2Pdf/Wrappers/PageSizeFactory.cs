// <copyright file="PageSizeFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System.Diagnostics.CodeAnalysis;
    using iText.Kernel.Geom;

    /// <summary>
    /// Implementation of <see cref="IPageSizeFactory"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class PageSizeFactory : IPageSizeFactory
    {
        /// <inheritdoc/>
        public IPageSize FromWidthAndHeight(float width, float height)
        {
            return new PageSizeWrapper(new PageSize(width, height));
        }
    }
}