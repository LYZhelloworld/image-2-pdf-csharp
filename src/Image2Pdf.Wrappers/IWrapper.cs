// <copyright file="IWrapper.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers
{
    /// <summary>
    /// The base wrapper class.
    /// </summary>
    /// <typeparam name="T">The type of the wrapped object.</typeparam>
    public interface IWrapper<T>
    {
        /// <summary>
        /// Gets the wrapped object.
        /// </summary>
        /// <returns>The wrapped object.</returns>
        T Unwrap();
    }
}
