namespace Image2PdfTest.Adapter
{
    using FluentAssertions;
    using Image2Pdf.Adapter;
    using Image2Pdf.Interface;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests of <see cref="PdfAdapterFactory"/>.
    /// </summary>
    [TestClass]
    public class PdfAdapterFactoryTest
    {
        /// <summary>
        /// Tests <see cref="PdfAdapterFactory.PdfAdapterFactory"/>.
        /// </summary>
        [TestMethod]
        public void TestConstructor()
        {
            PdfAdapterFactory factory = new();
            factory.Should().NotBeNull();
        }

        /// <summary>
        /// Tests <see cref="PdfAdapterFactory.CreateAdapter"/>
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
