using NUnit.Allure.Core;
using NUnit.Allure.Attributes;


namespace AllureJenkinsGit
{
   
    [TestFixture]
    [AllureSuite("Calculator Tests")]
    // Remove [AllureDisplayIgnored] from here
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