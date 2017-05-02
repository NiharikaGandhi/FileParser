using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Hosting;
using FakeItEasy;
using FileImporter.Controllers;
using FileImporter.Models;
using FileImporter.Reader;
using FileImporter.Service;
using FluentAssertions;
using NUnit.Framework;

namespace FileImport.Tests.Service
{
    [TestFixture]
    public class FileServiceTests
    {
        [UnderTest] public FileService _sut;
        [Fake] public IFileReader _FileReader;

        [SetUp]
        public void SetUp()
        {
            Fake.InitializeFixture(this);
        }

        [Test]
        public void GivenInValidFile_WhenParse_ReturnNotFound()
        {
            A.CallTo(() => _FileReader.GetFile("abc"))
                .Returns(new List<string>()
                );

            var response = _sut.Parse("abc");

            response.FirstOrDefault().Should().BeNull();
        }
    }
}
