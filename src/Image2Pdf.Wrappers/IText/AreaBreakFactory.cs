﻿// <copyright file="AreaBreakFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers.IText
{
    using iText.Layout.Element;
    using iText.Layout.Properties;

    /// <inheritdoc cref="IAreaBreakFactory"/>
    internal class AreaBreakFactory : IAreaBreakFactory
    {
        /// <inheritdoc/>
        public IAreaBreak CreateInstance(AreaBreakType? areaBreakType)
        {
            return new AreaBreakWrapper(new AreaBreak(areaBreakType));
        }
    }
}
