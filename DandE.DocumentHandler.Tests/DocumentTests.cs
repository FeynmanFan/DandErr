namespace DandE.DocumentHandler.Tests
{
    using Xunit;

    public class DocumentTests
    {
        [Fact]
        public void Doc1Text()
        {
            // arrange
            var expected = "Test Document #1To sit in solemn silence in a dull, dark, dock, In a pestilential prison, with a life-long lock,Awaiting the sensation of a short, sharp, shock, From a cheap and chippy chopper on a big black block";

            // act
            var docCard = new WordDocumentCard(TestFiles.Test_Document);

            // assert
            Assert.Equal(expected, docCard.Text);
        }
    }
}