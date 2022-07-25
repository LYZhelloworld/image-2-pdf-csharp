// <copyright file="AreaBreakFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System.Diagnostics.CodeAnalysis;
    using iText.Layout.Element;
    using iText.Layout.Properties;

    /// <summary>
    /// Implementation of <see cref="IAreaBreakFactory"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class AreaBreakFactory : IAreaBreakFactory
    {
        /// <inheritdoc/>
        public IAreaBreak FromAreaBreakType(AreaBreakType areaBreakType)
        {
            return new AreaBreakWrapper(new AreaBreak(areaBreakType));
        }
    }
}