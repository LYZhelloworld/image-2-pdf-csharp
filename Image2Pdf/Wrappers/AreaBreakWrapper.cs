// <copyright file="AreaBreakWrapper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System.Diagnostics.CodeAnalysis;
    using iText.Layout.Element;

    /// <summary>
    /// Implementation of <see cref="IAreaBreak"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
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
