// <copyright file="IAreaBreakFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
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