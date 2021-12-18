using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [TearDown]
        public void Teardown()
        {

        }
    }
}