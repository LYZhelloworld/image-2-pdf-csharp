using FluentAssertions;
using Image2Pdf.Adapter;
using Image2Pdf.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Image2PdfTest.Adapter;

/// <summary>
/// Tests <see cref="PdfAdapterFactory"/>.
/// </summary>
[TestClass]
public class PdfAdapterFactoryTest
{
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
