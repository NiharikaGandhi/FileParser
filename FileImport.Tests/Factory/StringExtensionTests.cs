using FakeItEasy;
using FileImporter.Factory;
using FluentAssertions;
using NUnit.Framework;

namespace FileImport.Tests.Factory
{
    [TestFixture]
    public class StringExtensionTests
    {
        [UnderTest] public StringExtentionMethods _sut;
       
        [SetUp]
        public void SetUp()
        {
            Fake.InitializeFixture(this);
        }

        [TestCase("abcasdfsd sadfsadf asfdaasdf", 0,5, "abcas")]
        [TestCase("abcasdfsd sadfsadf asfdaasdf", 10, 25, "sadfsadf asfdaa")]
        [TestCase("abcasdfsd sadfsadf asfdaasdf", -1, 5, "abcas")]
        [TestCase("abcasdfsd sadfsadf asfdaasdf", 25, 50,"sdf")]
        [TestCase("abcasdfsd sadfsadf asfdaasdf", 45, 50, "")]
        public void GivenContentAndStardAndEndPositin_WhenGetString_ThenReturnsSubString(string str, int startPos, int endPos, string expectedResult)
        {
            var response = _sut.GetString(str, startPos, endPos);

            response.Should().Be(expectedResult);
        }

    }
}
