// <copyright file="SystemIOWrapper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Implementation of <see cref="ISystemIOWrapper"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SystemIOWrapper : ISystemIOWrapper
    {
        /// <inheritdoc/>
        public IFileStreamFactory FileStream { get; } = new FileStreamFactory();
    }
}