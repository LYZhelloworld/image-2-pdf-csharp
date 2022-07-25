// <copyright file="IAreaBreakFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using iText.Layout.Element;
    using iText.Layout.Properties;

    /// <summary>
    /// A factory class of <see cref="IAreaBreak"/>.
    /// </summary>
    public interface IAreaBreakFactory
    {
        /// <summary>
        /// The wrapper method of <see cref="AreaBreak.AreaBreak"/>.
        /// </summary>
        /// <param name="areaBreakType">An area break type.</param>
        /// <returns>The <see cref="IAreaBreak"/> instance.</returns>
        IAreaBreak FromAreaBreakType(AreaBreakType areaBreakType);
    }
}