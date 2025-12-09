using NUnit.Allure.Core;
using NUnit.Allure.Attributes;


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
        [AllureSubSuite("Addition")]
        [AllureOwner("Ana")]
        public void AddTest()
        {
            int result = Add(2, 3);
            Assert.AreEqual(5, result);
        }

       
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}