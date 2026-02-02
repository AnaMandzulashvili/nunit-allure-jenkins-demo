using Allure.Net.Commons;
using Reqnroll;
using System.Text;

namespace AllureJenkinsGit
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║    TEST RUN STARTED                ║");
            Console.WriteLine($"║    Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss}    ║");
            Console.WriteLine("╚════════════════════════════════════╝");
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Console.WriteLine($"\n▶️  Starting scenario: {_scenarioContext.ScenarioInfo.Title}");

            // Print tags to console (Allure.Reqnroll handles tags automatically)
            foreach (var tag in _scenarioContext.ScenarioInfo.Tags)
            {
                Console.WriteLine($"   🏷️  Tag: {tag}");
            }

            AllureApi.AddAttachment(
                "📋 Scenario Info",
                "text/plain",
                Encoding.UTF8.GetBytes($@"
Scenario: {_scenarioContext.ScenarioInfo.Title}
Tags:     {string.Join(", ", _scenarioContext.ScenarioInfo.Tags)}
Started:  {DateTime.Now:yyyy-MM-dd HH:mm:ss}
                "),
                ".txt"
            );
        }

        [AfterStep]
        public void AfterStep()
        {
            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType;
            var stepText = _scenarioContext.StepContext.StepInfo.Text;
            Console.WriteLine($"   ✓ {stepType} {stepText}");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_scenarioContext.TestError != null)
            {
                Console.WriteLine($"❌ Scenario failed: {_scenarioContext.TestError.Message}");

                AllureApi.AddAttachment(
                    "❌ Error Details",
                    "text/plain",
                    Encoding.UTF8.GetBytes($@"
╔════════════════════════════════════╗
║          ERROR DETAILS             ║
╚════════════════════════════════════╝

Scenario: {_scenarioContext.ScenarioInfo.Title}
Error:    {_scenarioContext.TestError.Message}

Stack Trace:
{_scenarioContext.TestError.StackTrace}

Failed at: {DateTime.Now:yyyy-MM-dd HH:mm:ss}
                    "),
                    ".txt"
                );
            }
            else
            {
                Console.WriteLine($"✅ Scenario passed: {_scenarioContext.ScenarioInfo.Title}");

                AllureApi.AddAttachment(
                    "✅ Success Summary",
                    "text/plain",
                    Encoding.UTF8.GetBytes($@"
Scenario: {_scenarioContext.ScenarioInfo.Title}
Status:   PASSED ✅
Finished: {DateTime.Now:yyyy-MM-dd HH:mm:ss}
                    "),
                    ".txt"
                );
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("\n╔════════════════════════════════════╗");
            Console.WriteLine("║    TEST RUN FINISHED               ║");
            Console.WriteLine($"║    Time: {DateTime.Now:yyyy-MM-dd HH:mm:ss}    ║");
            Console.WriteLine("╚════════════════════════════════════╝");
        }
    }
}