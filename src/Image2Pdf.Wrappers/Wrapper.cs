// <copyright file="Wrapper.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc cref="IWrapper{T}"/>
    [ExcludeFromCodeCoverage]
    internal class Wrapper<T> : IWrapper<T>
    {
        /// <summary>
        /// The wrapped object.
        /// </summary>
        private readonly T wrapped;

        /// <summary>
        /// Initializes a new instance of the <see cref="Wrapper{T}"/> class.
        /// </summary>
        /// <param name="wrapped">The wrapped object.</param>
        public Wrapper(T wrapped)
        {
            this.wrapped = wrapped;
        }

        /// <inheritdoc/>
        public T Unwrap()
        {
            return this.wrapped;
        }
    }
}
