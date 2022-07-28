// <copyright file="AreaBreakWrapper.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
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
