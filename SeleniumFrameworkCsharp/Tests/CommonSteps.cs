using SeleniumFrameworkCsharp.Utilities;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SeleniumFrameworkCsharp.Utilities.Helpers;
using System;
using SeleniumFrameworkCsharp.Pages.Executors;
using SeleniumFrameworkCsharp.Utilities.Objects;
using NUnit.Framework;

namespace SeleniumFrameworkCsharp.Tests
{
    [Binding]
    public class CommonSteps
    {
        static SeleniumExecutor executor;

        [BeforeScenario]
        public static void BeforeEachScenario()
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
            executor.BaseTearDown();
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

        [Then(@"I can see alert with message ""(.*)""")]
        public void ThenICanSeeAlertWithMessage(string message)
        {
            DashboardPage dashboard = new DashboardPage(executor);
            Assert.AreEqual(message, dashboard.GetMessageFromAlert());
        }
    }
}