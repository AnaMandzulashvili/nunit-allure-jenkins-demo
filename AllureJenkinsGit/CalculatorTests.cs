using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using System.Text;

namespace AllureJenkinsGit
{
    [TestFixture]
    [AllureParentSuite("Mobile Application Testing")]
    [AllureSuite("Calculator Tests")]
    [AllureEpic("Mathematical Operations")]
    public class CalculatorTests
    {
        private int _first;
        private int _second;
        private int _result;

        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("Setup: Initializing test");
        }

        [Test]
        [AllureId(1)]
        [AllureName("Verify addition of two positive numbers")]
        [Description("<b>Test Purpose:</b> Verify calculator can add two positive integers correctly<br/><i>Expected:</i> 2 + 3 = 5")]
        [AllureTag("smoke", "regression", "calculator")]
        [AllureSubSuite("Addition Operations")]
        [AllureFeature("Calculator Operations")]
        [AllureStory("User performs addition")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Ana")]
        [AllureTms("TMS-123")]
        [AllureIssue("BUG-456")]
        [AllureLink("https://docs.company.com/calculator-requirements")]
        public void AddTestViaNunit()
        {
            AllureApi.Step("Set first number to 2", () =>
            {
                _first = 2;
                Console.WriteLine($"First number set: {_first}");

                AllureApi.AddAttachment(
                    "First Number Input",
                    "text/plain",
                    Encoding.UTF8.GetBytes($"Input value: {_first}"),
                    ".txt"
                );
            });

            AllureApi.Step("Set second number to 3", () =>
            {
                _second = 3;
                Console.WriteLine($"Second number set: {_second}");

                AllureApi.AddAttachment(
                    "Second Number Input",
                    "text/plain",
                    Encoding.UTF8.GetBytes($"Input value: {_second}"),
                    ".txt"
                );
            });

            AllureApi.Step("Perform addition operation", () =>
            {
                _result = _first + _second;
                Console.WriteLine($"Calculation: {_first} + {_second} = {_result}");
            });

            AllureApi.Step("Verify result equals 5", () =>
            {
                Assert.That(_result, Is.EqualTo(5),
                    $"Addition failed: Expected 5 but got {_result}");

                AllureApi.AddAttachment(
                    "Calculation Result",
                    "text/plain",
                    Encoding.UTF8.GetBytes($@"
═══════════════════════════════
     CALCULATION SUMMARY
═══════════════════════════════
First Number:    {_first}
Second Number:   {_second}
Operation:       Addition (+)
Result:          {_result}
Status:          ✅ PASSED
Timestamp:       {DateTime.Now:yyyy-MM-dd HH:mm:ss}
═══════════════════════════════
                    "),
                    ".txt"
                );

                // Attach screenshot if exists
                AttachScreenshotIfExists();
            });
        }

        [Test]
        [AllureId(2)]
        [AllureName("Verify addition with negative numbers")]
        [Description("Test calculator behavior with negative integers")]
        [AllureTag("regression", "negative-testing")]
        [AllureSubSuite("Addition Operations")]
        [AllureFeature("Calculator Operations")]
        [AllureStory("User performs addition with negatives")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureOwner("Ana ")]
        public void AddNegativeNumbersTest()
        {
            AllureApi.Step("Set first number to -2", () =>
            {
                _first = -2;
            });

            AllureApi.Step("Set second number to -3", () =>
            {
                _second = -3;
            });

            AllureApi.Step("Perform addition", () =>
            {
                _result = _first + _second;
            });

            AllureApi.Step("Verify result equals -5", () =>
            {
                Assert.That(_result, Is.EqualTo(-5));

                AllureApi.AddAttachment(
                    "Negative Numbers Result",
                    "application/json",
                    Encoding.UTF8.GetBytes($@"{{
  ""firstNumber"": {_first},
  ""secondNumber"": {_second},
  ""operation"": ""addition"",
  ""result"": {_result},
  ""expected"": -5,
  ""status"": ""passed""
}}"),
                    ".json"
                );
            });
        }

        [Test]
        [AllureId(3)]
        [AllureName("Verify addition with zero")]
        [Description("Test calculator with zero values")]
        [AllureTag("smoke", "edge-case")]
        [AllureSubSuite("Addition Operations")]
        [AllureFeature("Calculator Operations")]
        [AllureStory("User performs addition with zero")]
        [AllureSeverity(SeverityLevel.minor)]
        [AllureOwner("Ana ")]
        public void AddWithZeroTest()
        {
            AllureApi.Step("Set first number to 0", () =>
            {
                _first = 0;
            });

            AllureApi.Step("Set second number to 0", () =>
            {
                _second = 0;
            });

            AllureApi.Step("Perform addition", () =>
            {
                _result = _first + _second;
            });

            AllureApi.Step("Verify result equals 0", () =>
            {
                Assert.That(_result, Is.EqualTo(0));
            });
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Teardown: Cleaning up");
        }

        private void AttachScreenshotIfExists()
        {
            string screenshotPath = "screenshot.png";
            if (File.Exists(screenshotPath))
            {
                AllureApi.AddAttachment(
                    "Calculator Screenshot",
                    "image/png",
                    File.ReadAllBytes(screenshotPath),
                    ".png"
                );
            }
        }
    }
}