using NUnit.Framework;
using SeleniumFrameworkCsharp.Pages.Executors;
using SeleniumFrameworkCsharp.Utilities;
using TechTalk.SpecFlow;

namespace SeleniumFrameworkCsharp.Tests.Steps
{
    [Binding]
    public class Task5Steps
    {
        private SeleniumExecutor executor;
        private Task5Page task5Page;

        public Task5Steps()
        {
            executor = SeleniumExecutor.GetExecutor();
        }

        [BeforeScenario]
        public void BeforePage()
        {
            task5Page = new Task5Page(executor);
        }

        [When(@"I upload file ""(.*)""")]
        public void WhenIUploadFile(string fileName)
        {
            task5Page.UploadFile(fileName);
        }

        [Then(@"Data from file are shown in table")]
        public void ThenDataFromFileAreShownInTable()
        {
            Assert.True(task5Page.CompareTwoLists());
        }     
    }
}