using NUnit.Framework;

namespace AllureJenkinsGit.Tests
{
    public class CalculatorTests
    {
        [SetUp]
        public void Setup()
        {
            // Runs before each test
        }

        [Test]
        public void Add_TwoNumbers_ReturnsCorrectSum()
        {
            int a = 5;
            int b = 3;
            int result = a + b;

            Assert.That(result, Is.EqualTo(8));
        }
    }
}
