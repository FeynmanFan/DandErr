namespace DandE.Web.Tests
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Hosting.Internal;
    using System.IO;
    using WebApplication1.Pages;
    using Xunit;

    public class ViewModelTests
    {
        [Fact]
        public void DocumentsCollectionHoldsASingleElement()
        {
            // arrange
            var env = new MockWebHostEnvironment();

            var indexPage = new IndexModel(null, env);

            // assert
            Assert.Single(indexPage.Documents);
        }
    }
}