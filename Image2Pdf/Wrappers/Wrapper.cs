// <copyright file="Wrapper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2Pdf.Wrappers
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Implementation of <see cref="IWrapper{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the wrapped object.</typeparam>
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
