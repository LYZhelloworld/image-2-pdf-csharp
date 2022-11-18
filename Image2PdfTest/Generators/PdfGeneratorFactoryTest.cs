// <copyright file="PdfGeneratorFactoryTest.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2PdfTest.Generators
{
    using FluentAssertions;
    using Image2Pdf.Adapters;
    using Image2Pdf.Generators;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Tests <see cref="PdfGeneratorFactory"/>.
    /// </summary>
    [TestClass]
    public class PdfGeneratorFactoryTest
    {
        /// <summary>
        /// Tests <see cref="PdfGeneratorFactory.CreateInstance"/>.
        /// </summary>
        [TestMethod]
        public void TestCreateInstance()
        {
            PdfGeneratorFactory factory = new(Mock.Of<IPdfAdapterFactory>());
            IPdfGenerator generator = factory.CreateInstance(Enumerable.Empty<string>());
            generator.Should().NotBeNull();
        }
    }
}
