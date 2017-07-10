using NUnit.Framework;
using SeleniumFrameworkCsharp.Pages.Executors;
using SeleniumFrameworkCsharp.Utilities;
using TechTalk.SpecFlow;

namespace SeleniumFrameworkCsharp.Tests.Steps
{
    [Binding]
    public class Task2Steps
    {
        private Task2Page task2Page;
        private SeleniumExecutor executor;

        public Task2Steps()
        {
            executor = SeleniumExecutor.GetExecutor();
        }

        [BeforeScenario]
        public void BeforePage()
        {
            task2Page = new Task2Page(executor);
        }

        [When(@"I expand dropdown list")]
        public void WhenIExpandDropdownList()
        {
            task2Page.ExpandDropDownList();
        }

        [When(@"I type fragment ""(.*)"" of category name")]
        public void WhenITypeFragmentOfCategoryName(string category)
        {
            task2Page.TypeTextInSearchBox(category);
        }

        [Then(@"I can see products only for this category ""(.*)""")]
        public void ThenICanSeeProductsOnlyForThisCategory(string category)
        {
            Assert.True(task2Page.VerifyCategoriesOfSelectedProducts(category));
        }
    }
}
