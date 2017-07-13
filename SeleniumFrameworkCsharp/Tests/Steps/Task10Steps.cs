using SeleniumFrameworkCsharp.Pages.Executors;
using SeleniumFrameworkCsharp.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SeleniumFrameworkCsharp.Tests.Steps
{
    [Binding]
    public class Task10Steps
    {
        private Task10Page task10Page;
        private SeleniumExecutor executor;

        public Task10Steps()
        {
            executor = new SeleniumExecutor();
        }

        [BeforeScenario]
        public void BeforePage()
        {
            task10Page = new Task10Page(executor);
        }

        [When(@"I scroll the page to the bottom")]
        public void WhenIScrollThePageToTheBottom()
        {
            task10Page.ScrollToFooter();
        }

        [Then(@"I can see footer")]
        public void ThenICanSeeFooter()
        {
            task10Page.IsFooterVisible();
        }

        [Then(@"Loaded fragments are equal to (.*)")]
        public void ThenLoadedFragmentsAreEqualTo(int loadedFragmentNumber)
        {
            task10Page.CountLoadedFragment();
        }
    }
}