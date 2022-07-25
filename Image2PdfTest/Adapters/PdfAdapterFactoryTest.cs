// <copyright file="PdfAdapterFactoryTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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
            PdfAdapterFactory factory = new ();
            IPdfAdapter adapter = factory.CreateAdapter();
            adapter.Should().NotBeNull();
        }
    }
}