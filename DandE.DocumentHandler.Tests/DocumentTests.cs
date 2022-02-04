namespace DandE.DocumentHandler.Tests
{
    using System.IO;
    using Xunit;

    public class DocumentTests
    {
        [Fact]
        public void VerifyMissingDocument()
        {
            Assert.Throws<FileNotFoundException>(() => new WordDocumentCard("Nonexistent file path"));
        }
    }
}