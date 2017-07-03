using SeleniumFrameworkCsharp.Utilities;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SeleniumFrameworkCsharp.Utilities.Helpers;
using System;
using SeleniumFrameworkCsharp.Pages.Executors;
using SeleniumFrameworkCsharp.Utilities.Objects;

namespace SeleniumFrameworkCsharp.Tests
{
    [Binding]
    public class CommonSteps
    {
        static SeleniumExecutor executor;

        [BeforeFeature]
        public static void BeforeTestRunCommon()
        {
            SeleniumExecutor.BaseSetUp();
            executor = SeleniumExecutor.GetExecutor();
            executor.OpenPage(SeleniumExecutor.pageDefaultUrl);

        
        }


        [AfterScenario]
        public static void TakeScreenshot()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                executor.ScreenshotReport();
            }
        }

        [AfterFeature]
        public static void TearDown()
        {
            executor.BaseTearDown();
        }

        [Given(@"I open task (.*) page")]
        public void GivenIOpenTaskPage(String taskNumber)
        {
            DashboardPage dashboard = new DashboardPage(executor);
            dashboard.GoToTask(taskNumber);
        }

    }
}
