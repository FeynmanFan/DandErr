namespace DandE.DocumentHandler.Tests
{
    using Microsoft.Extensions.Logging;
    using Xunit;

    public class DocumentTests
    {
        [Fact]
        public void Doc1Properties()
        {
            // arrange
            var expectedText = "From “I Am So Proud”To sit in solemn silence in a dull, dark, dock, In a pestilential prison, with a life-long lock,Awaiting the sensation of a short, sharp, shock, From a cheap and chippy chopper on a big black block";
            var expectedTitle = "Test Document #1";

            var logger = new LoggerFactory().CreateLogger("Doc1Properties Test");

            // act
            var docCard = new WordDocumentCard(TestFiles.Test_Document, logger);

            // assert
            Assert.Equal(expectedText, docCard.Text);
            Assert.Equal(expectedTitle, docCard.Title);
        }
    }
}