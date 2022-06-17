namespace Image2PdfTest.Utility
{
    using FluentAssertions;
    using Image2Pdf.Utility;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests of <see cref="FileUtils"/>.
    /// </summary>
    [TestClass]
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
