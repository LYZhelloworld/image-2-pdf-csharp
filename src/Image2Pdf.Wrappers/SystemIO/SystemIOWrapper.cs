// <copyright file="SystemIOWrapper.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers.SystemIO
{
    /// <inheritdoc cref="ISystemIOWrapper"/>
    public class SystemIOWrapper : ISystemIOWrapper
    {
        /// <inheritdoc/>
        public IFileStreamFactory FileStream { get; } = new FileStreamFactory();
    }
}
