using Allure.Net.Commons;
using Reqnroll;

namespace AllureJenkinsGit.Steps
{
    [Binding]
    public class CalculatorSteps
    {
        private List<int> _numbers = new List<int>();
        private int _result;

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int number)
        {
            _numbers.Add(number);
            Console.WriteLine($"Entered number: {number}");
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _result = _numbers.Sum();
            Console.WriteLine($"Calculation: {string.Join(" + ", _numbers)} = {_result}");
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int expectedResult)
        {
            // ✅ Fixed: Assert.That instead of Assert.AreEqual
            Assert.That(_result, Is.EqualTo(expectedResult));

            // ✅ Fixed: Check if file exists before reading
            string path = "screenshot.png";
            if (File.Exists(path))
            {
                AllureApi.AddAttachment(
                    "Result Screenshot",
                    "image/png",
                    File.ReadAllBytes(path),
                    ".png"
                );
            }
        }
    }
}