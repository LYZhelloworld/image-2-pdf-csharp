// <copyright file="PdfAdapterFactoryTest.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2PdfTest.Adapters
{
    using FluentAssertions;
    using Image2Pdf.Adapters;
    using Image2Pdf.Wrappers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Tests <see cref="PdfAdapterFactory"/>.
    /// </summary>
    [TestClass]
    public class PdfAdapterFactoryTest
    {
        /// <summary>
        /// Tests <see cref="PdfAdapterFactory.CreateInstance"/>.
        /// </summary>
        [TestMethod]
        public void TestCreateAdapter()
        {
            PdfAdapterFactory factory = new PdfAdapterFactory(Mock.Of<IPdfWrapper>(), Mock.Of<ISystemIOWrapper>(), Mock.Of<ISystemDrawingWrapper>());
            IPdfAdapter adapter = factory.CreateInstance();
            adapter.Should().NotBeNull();
        }
    }
}
