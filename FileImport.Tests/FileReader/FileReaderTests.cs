using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace FileImport.Tests.FileReader
{
    [TestFixture]
    class FileReaderTests
    {
        [UnderTest] public FileImporter.Reader.FileReader _sut;
        
        [SetUp]
        public void SetUp()
        {
            Fake.InitializeFixture(this);
        }

        [Test]
        public void GivenInValidFilePath_WhenGetFile_ThenNoFileContents()
        {
            var response = _sut.GetFile("abc");

            response.Count().Should().Be(0);
        }

        [Test]
        public void GivenInValidFile_WhenGetFileContents_ThenNoFileContents()
        {
            var response = _sut.GetFileContents(new List<string>());

            response.Should().BeNull();
        }

        [Test]
        public void GivenValidFile_WhenGetFileContents_ThenNoFileContents()
        {
            var response = _sut.GetFileContents(new List<string>() {"A", "abc asdfsdf"});

            response.Should().BeEquivalentTo("abc asdfsdf");
        }

        [Test]
        public void GivenInValidFile_WhenGetFileFormat_ThenNoFileContents()
        {
            var response = _sut.GetFileFormat(new List<string>());

            response.Should().BeNull();
        }

        [Test]
        public void GivenValidFile_WhenGetFileFormat_ThenNoFileContents()
        {
            var response = _sut.GetFileFormat(new List<string>() {"A", "abc asdf asdf"});

            response.Should().Be("A");
        }
    }
}
