// <copyright file="SystemDrawingWrapper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Implementation of <see cref="ISystemDrawingWrapper"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class SystemDrawingWrapper : ISystemDrawingWrapper
    {
        /// <inheritdoc/>
        public ISystemDrawingImageFactory Image { get; } = new SystemDrawingImageFactory();
    }
}