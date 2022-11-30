// <copyright file="AreaBreakWrapper.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers.IText
{
    using Image2Pdf.Wrappers;
    using iText.Layout.Element;

    /// <inheritdoc cref="AreaBreak"/>
    internal class AreaBreakWrapper : Wrapper<AreaBreak>, IAreaBreak
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AreaBreakWrapper"/> class.
        /// </summary>
        /// <param name="areaBreak">The wrapped object.</param>
        internal AreaBreakWrapper(AreaBreak areaBreak)
            : base(areaBreak)
        {
        }
    }
}
