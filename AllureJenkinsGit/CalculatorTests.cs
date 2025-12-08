using NUnit.Allure.Core;
using NUnit.Allure.Attributes;
using Allure.Net.Commons;

namespace AllureJenkinsGit
{
    [AllureNUnit]
    [TestFixture]
    [AllureSuite("Calculator Tests")]
    [AllureDisplayIgnored]
    public class CalculatorTests
    {
        [Test]
        [AllureTag("Regression")]
        [AllureOwner("Ana")]
        [AllureSubSuite("Addition")]
        public void AddTest()
        {
            int result = Add(2, 3);
            Assert.AreEqual(5, result);
        }

        [AllureStep("Adding {0} and {1}")]
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}