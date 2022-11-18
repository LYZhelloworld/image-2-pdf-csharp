// <copyright file="IPdfGeneratorFactory.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Generators
{
    using System.Collections.Generic;

    /// <summary>
    /// The factory class of <see cref="IPdfGenerator"/>.
    /// </summary>
    public interface IPdfGeneratorFactory
    {
        /// <summary>
        /// Builds an instance of <see cref="IPdfGenerator"/>.
        /// </summary>
        /// <param name="files">The image filenames.</param>
        /// <returns>The <see cref="IPdfGenerator"/> instance.</returns>
        IPdfGenerator CreateInstance(IEnumerable<string> files);
    }
}
