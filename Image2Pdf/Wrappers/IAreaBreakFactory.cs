// <copyright file="IAreaBreakFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using iText.Layout.Element;
    using iText.Layout.Properties;

    /// <summary>
    /// The factory class of <see cref="IAreaBreak"/>.
    /// </summary>
    public interface IAreaBreakFactory
    {
        /// <inheritdoc cref="AreaBreak(AreaBreakType?)"/>
        IAreaBreak FromAreaBreakType(AreaBreakType? areaBreakType);
    }
}
