// <copyright file="PdfGeneratorFactoryTest.cs" company="Helloworld">
// Copyright (c) Helloworld. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Image2PdfTest.Generators
{
    using System.Diagnostics.CodeAnalysis;
    using FluentAssertions;
    using Image2Pdf.Generators;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests <see cref="PdfGeneratorFactory"/>.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class PdfGeneratorFactoryTest
    {
        /// <summary>
        /// Tests <see cref="PdfGeneratorFactory.AddFiles(IEnumerable{string})"/> and <see cref="PdfGeneratorFactory.Build"/>.
        /// </summary>
        [TestMethod]
        public void TestBuild()
        {
            PdfGeneratorFactory factory = new();
            factory.AddFiles(new List<string>());
            IPdfGenerator generator = factory.Build();
            generator.Should().NotBeNull();
        }
    }
}
