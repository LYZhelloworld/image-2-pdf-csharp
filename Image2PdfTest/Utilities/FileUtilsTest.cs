﻿// <copyright file="FileUtilsTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Image2PdfTest.Utilities
{
    using System.Diagnostics.CodeAnalysis;
    using FluentAssertions;
    using Image2Pdf.Utilities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests <see cref="FileUtils"/>.
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class FileUtilsTest
    {
        /// <summary>
        /// Tests of <see cref="FileUtils.IsValidImageFile(string)"/>.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <param name="expected">The expected result.</param>
        [DataTestMethod]
        [DataRow("test.jpg", true)]
        [DataRow("test.png", true)]
        [DataRow("test.txt", false)]
        public void TestIsValidImageFile(string filename, bool expected)
        {
            FileUtils.IsValidImageFile(filename).Should().Be(expected);
        }
    }
}