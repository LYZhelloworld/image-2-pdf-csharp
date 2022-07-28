// <copyright file="PdfAdapterFactoryTest.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2PdfTest.Adapters
{
    using System.Diagnostics.CodeAnalysis;
    using FluentAssertions;
    using Image2Pdf.Adapters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests <see cref="PdfAdapterFactory"/>.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class PdfAdapterFactoryTest
    {
        /// <summary>
        /// Tests <see cref="PdfAdapterFactory.CreateAdapter"/>.
        /// </summary>
        [TestMethod]
        public void TestCreateAdapter()
        {
            PdfAdapterFactory factory = new();
            IPdfAdapter adapter = factory.CreateAdapter();
            adapter.Should().NotBeNull();
        }
    }
}