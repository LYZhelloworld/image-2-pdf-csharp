// <copyright file="ISystemDrawingWrapper.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers
{
    /// <summary>
    /// The wrapper class of <see cref="System.Drawing"/> operations.
    /// </summary>
    public interface ISystemDrawingWrapper
    {
        /// <inheritdoc cref="ISystemDrawingImageFactory"/>
        ISystemDrawingImageFactory Image { get; }
    }
}
