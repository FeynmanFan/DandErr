namespace DandE.Web.Tests
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.FileProviders;
    using System;
    using System.IO;

    internal class MockWebHostEnvironment : IWebHostEnvironment
    {
        public string WebRootPath
        {
            get
            {
                // a bit of a kludge
                return Path.GetFullPath("..\\..\\..\\..\\DandE.Web\\wwwroot", Directory.GetCurrentDirectory());
            }
            set 
            {
                throw new NotImplementedException();
            }
        } 

        public IFileProvider WebRootFileProvider { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IFileProvider ContentRootFileProvider { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ContentRootPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string EnvironmentName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
