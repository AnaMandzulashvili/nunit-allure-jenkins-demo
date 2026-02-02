using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using Reqnroll;
using System.Text;

namespace AllureJenkinsGit.Steps
{
    [Binding]
    public class CalculatorSteps
    {
        private List<int> _numbers = new List<int>();
        private int _result;

        [Given(@"I have entered (.*) into the calculator")]
        [AllureStep("Enter {number} into calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int number)
        {
            _numbers.Add(number);
            Console.WriteLine($"📝 Entered number: {number}");

            AllureApi.AddAttachment(
                $"Input Number #{_numbers.Count}",
                "text/plain",
                Encoding.UTF8.GetBytes($@"
Input #{_numbers.Count}
━━━━━━━━━━━━━━━━━
Value:     {number}
Timestamp: {DateTime.Now:HH:mm:ss}
                "),
                ".txt"
            );
        }

        [When(@"I press add")]
        [AllureStep("Press ADD button")]
        public void WhenIPressAdd()
        {
            _result = _numbers.Sum();
            string calculation = string.Join(" + ", _numbers);
            Console.WriteLine($"🔢 Calculation: {calculation} = {_result}");

            AllureApi.AddAttachment(
                "Calculation Details",
                "text/html",
                Encoding.UTF8.GetBytes($@"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {{ font-family: Arial; padding: 20px; }}
        .calculation {{ 
            background: #f0f0f0; 
            padding: 15px; 
            border-radius: 5px;
            font-size: 18px;
        }}
        .numbers {{ color: #0066cc; font-weight: bold; }}
        .result {{ color: #009900; font-weight: bold; }}
    </style>
</head>
<body>
    <h2>Addition Operation</h2>
    <div class='calculation'>
        <p><span class='numbers'>{calculation}</span> = <span class='result'>{_result}</span></p>
    </div>
    <p><small>Executed at: {DateTime.Now:yyyy-MM-dd HH:mm:ss}</small></p>
</body>
</html>
                "),
                ".html"
            );
        }

        [Then(@"the result should be (.*) on the screen")]
        [AllureStep("Verify result equals {expectedResult}")]
        public void ThenTheResultShouldBeOnTheScreen(int expectedResult)
        {
            Console.WriteLine($"✓ Verifying: Expected={expectedResult}, Actual={_result}");

            try
            {
                Assert.That(_result, Is.EqualTo(expectedResult));

                AllureApi.AddAttachment(
                    "✅ Verification Success",
                    "text/plain",
                    Encoding.UTF8.GetBytes($@"
╔══════════════════════════════════╗
║     VERIFICATION SUCCESSFUL      ║
╚══════════════════════════════════╝

Numbers:   {string.Join(", ", _numbers)}
Expected:  {expectedResult}
Actual:    {_result}
Status:    ✅ PASSED

Test completed at: {DateTime.Now:yyyy-MM-dd HH:mm:ss}
                    "),
                    ".txt"
                );

                AttachScreenshot();
            }
            catch (Exception ex)
            {
                AllureApi.AddAttachment(
                    "❌ Verification Failed",
                    "text/plain",
                    Encoding.UTF8.GetBytes($@"
╔══════════════════════════════════╗
║      VERIFICATION FAILED         ║
╚══════════════════════════════════╝

Numbers:   {string.Join(", ", _numbers)}
Expected:  {expectedResult}
Actual:    {_result}
Status:    ❌ FAILED

Error:     {ex.Message}

Test failed at: {DateTime.Now:yyyy-MM-dd HH:mm:ss}
                    "),
                    ".txt"
                );

                AttachScreenshot();
                throw;
            }
        }

        private void AttachScreenshot()
        {
            string path = "screenshot.png";
            if (File.Exists(path))
            {
                AllureApi.AddAttachment(
                    "📸 Result Screenshot",
                    "image/png",
                    File.ReadAllBytes(path),
                    ".png"
                );
            }
        }
    }
}