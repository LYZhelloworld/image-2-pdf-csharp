// <copyright file="PageSizeWrapper.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers.IText
{
    using System.Diagnostics.CodeAnalysis;
    using Image2Pdf.Wrappers;
    using iText.Kernel.Geom;

    /// <inheritdoc cref="IPageSize"/>
    [ExcludeFromCodeCoverage]
    internal class PageSizeWrapper : Wrapper<PageSize>, IPageSize
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageSizeWrapper"/> class.
        /// </summary>
        /// <param name="pageSize">The wrapped object.</param>
        internal PageSizeWrapper(PageSize pageSize)
            : base(pageSize)
        {
        }
    }
}
