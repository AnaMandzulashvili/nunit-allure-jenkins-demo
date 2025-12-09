using NUnit.Framework;
using Allure.Net.Commons;
using Allure.NUnit.Attributes;

namespace AllureJenkinsGit
{
    [TestFixture]
    [AllureSuite("Calculator Tests")]
    public class CalculatorTests
    {
        [Test]
        [AllureTag("Regression")]
        [AllureSubSuite("Addition")]
        [AllureOwner("Ana")]
        [Description("Test to verify addition of two numbers")]
        public void AddTest()
        {
            int firstNumber = SetFirstNumber(2);
            int secondNumber = SetSecondNumber(3);
            int result = PerformAddition(firstNumber, secondNumber);
            VerifyResult(result, 5);
        }

        [AllureStep("Set first number to {number}")]
        private int SetFirstNumber(int number)
        {
            return number;
        }

        [AllureStep("Set second number to {number}")]
        private int SetSecondNumber(int number)
        {
            return number;
        }

        [AllureStep("Add {a} and {b}")]
        private int PerformAddition(int a, int b)
        {
            return Add(a, b);
        }

        [AllureStep("Verify result is {expected}")]
        private void VerifyResult(int actual, int expected)
        {
            Assert.AreEqual(expected, actual);
        }

        private int Add(int a, int b)
        {
            return a + b;
        }
    }
}