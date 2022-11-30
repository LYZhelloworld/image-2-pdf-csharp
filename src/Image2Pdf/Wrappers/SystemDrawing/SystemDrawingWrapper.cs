// <copyright file="SystemDrawingWrapper.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers.SystemDrawing
{
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc cref="ISystemDrawingWrapper"/>
    [ExcludeFromCodeCoverage]
    public class SystemDrawingWrapper : ISystemDrawingWrapper
    {
        /// <inheritdoc/>
        public ISystemDrawingImageFactory Image { get; } = new SystemDrawingImageFactory();
    }
}
