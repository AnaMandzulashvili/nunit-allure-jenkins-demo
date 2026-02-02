using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;

namespace AllureJenkinsGit
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Calculator Tests")]
    [AllureFeature("Arithmetic Operations")]  // ✅ Add this
    [AllureStory("Addition Calculations")]     // ✅ Add this
    public class CalculatorTests
    {
        private int _first;
        private int _second;
        private int _result;
        private string _resultsDir;

        [SetUp]
        public void SetUp()
        {
            _resultsDir = Path.Combine(
                Directory.GetCurrentDirectory(),
                "allure-results"
            );
            if (!Directory.Exists(_resultsDir))
                Directory.CreateDirectory(_resultsDir);
        }

        [Test]
        [AllureTag("Regression")]
        [AllureTag("Smoke")]              // ✅ Add multiple tags
        [AllureSeverity(SeverityLevel.critical)]  // ✅ Add severity
        [AllureSubSuite("Addition")]
        [AllureOwner("Ana")]
        [AllureEpic("Calculator Module")]  // ✅ Add epic
        [AllureFeature("Basic Operations")] // ✅ Add feature
        [AllureStory("Add two numbers")]   // ✅ Add story
        [Description("Test to verify addition of two numbers")]
        public void AddTestViaNunit()
        {
            AllureApi.Step("Set first number to 2", () =>
            {
                _first = 2;
            });

            AllureApi.Step("Set second number to 3", () =>
            {
                _second = 3;
            });

            AllureApi.Step("Perform addition", () =>
            {
                _result = _first + _second;
            });

            AllureApi.Step("Verify result is 5", () =>
            {
                Assert.That(_result, Is.EqualTo(5));
                AllureApi.AddAttachment(
                    "Calculation Result",
                    "text/plain",
                    System.Text.Encoding.UTF8.GetBytes(
                        $"{_first} + {_second} = {_result}"),
                    ".txt"
                );
            });
        }
    }
}