using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Hosting;
using FakeItEasy;
using FileImporter.Controllers;
using FileImporter.Models;
using FileImporter.Service;
using FluentAssertions;
using NUnit.Framework;

namespace FileImport.Tests
{
    [TestFixture]
    public class FileControllerTests
    {
        [UnderTest] public FileController _sut;
        [Fake] public IFileService _fileService;

        [SetUp]
        public void SetUp()
        {
            Fake.InitializeFixture(this);
            _sut.Request = new HttpRequestMessage();
            _sut.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
        }

        [Test]
        public void GivenValidFile_WhenParse_ReturnOk()
        {
            A.CallTo(() => _fileService.Parse("abc"))
                .Returns(new List<Book>()
                {
                    new Book()
                    {
                        Author = "Abc",
                        ISBN = "abc",
                        Name = "abc"
                    }
                });

            var response = _sut.FileImport("abc");

            response.ExecuteAsync(new CancellationToken()).Result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void GivenInValidFile_WhenParse_ReturnOk()
        {
            A.CallTo(() => _fileService.Parse("abc")).Returns(null);

            var response = _sut.FileImport("abc");

            response.ExecuteAsync(new CancellationToken()).Result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
