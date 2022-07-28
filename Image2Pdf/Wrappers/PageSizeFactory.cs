// <copyright file="PageSizeFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
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