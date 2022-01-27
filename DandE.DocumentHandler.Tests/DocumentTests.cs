namespace DandE.DocumentHandler.Tests
{
    using Xunit;
    using System.IO;
    using System.Diagnostics;

    public class DocumentTests
    {
        [Fact]
        public void Doc1Properties()
        {
            // arrange
            var expectedText = "Test Document #1To sit in solemn silence in a dull, dark, dock, In a pestilential prison, with a life-long lock,Awaiting the sensation of a short, sharp, shock, From a cheap and chippy chopper on a big black block";
            var expectedTitle = "Test Document #1";

            // act
            var docCard = new WordDocumentCard(TestFiles.Test_Document);

            // assert
            Assert.Equal(expectedText, docCard.Text);
            Assert.Equal(expectedTitle, docCard.Title);
        }
    }
}