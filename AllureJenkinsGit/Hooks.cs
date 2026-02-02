using Reqnroll;

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
            Console.WriteLine("Test run started");
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Console.WriteLine($"Starting scenario: {_scenarioContext.ScenarioInfo.Title}");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (_scenarioContext.TestError != null)
            {
                Console.WriteLine($"Scenario failed: {_scenarioContext.TestError.Message}");
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Console.WriteLine("Test run finished");
        }
    }
}