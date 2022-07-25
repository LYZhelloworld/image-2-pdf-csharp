// <copyright file="PdfGeneratorFactoryTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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
            PdfGeneratorFactory factory = new ();
            factory.AddFiles(new List<string>());
            IPdfGenerator generator = factory.Build();
            generator.Should().NotBeNull();
        }
    }
}