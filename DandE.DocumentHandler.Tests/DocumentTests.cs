namespace DandE.DocumentHandler.Tests
{
    using Xunit;
    using System.IO;
    using System.Diagnostics;

    public class DocumentTests
    {
        [Fact]
        public void OutputFileFunctionProducesFile()
        {
            Debug.WriteLine("Current directory is: " + Directory.GetCurrentDirectory());

            var filePath = @"/home/nt-user/workspace/DandErr/outputfile.txt";

            Assert.True(File.Exists(filePath), "$File does not exist at {filePath}");

            var result = File.ReadAllText(filePath);

            Assert.True(!string.IsNullOrEmpty(result), "File existed, but is empty");
        }
    }
}