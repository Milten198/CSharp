using NUnit.Framework;
using SeleniumFrameworkCsharp.Pages.Executors;
using SeleniumFrameworkCsharp.Utilities;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SeleniumFrameworkCsharp.Tests.Steps
{
    [Binding]
    public class Task7Steps
    {
        private Task7Page task7Page;
        private SeleniumExecutor executor;

        public void Task7Page()
        {
            executor = SeleniumExecutor.GetExecutor();
        }

        [BeforeScenario]
        public void BeforeLoginPage()
        {
            task7Page = new Task7Page(executor);
        }

        [When(@"I set quantity ""(.*)"" of product ""(.*)""")]
        public void WhenISetQuantityOfProduct(string productQuantity, string productName)
        {
            task7Page.SetProductQuantity(productQuantity, productName);
        }

        [When(@"I drag and drop ""(.*)"" in basket")]
        public void WhenIDragAndDropItBasket(string productLogo)
        {
            task7Page.DragAndDropProduct(productLogo);
        }


        [Then(@"I can see this product ""(.*)"" in basket")]
        public void ThenICanSeeThisProductInBasket(string productName)
        {
            Assert.True(task7Page.IsProductInBasket(productName), "There is no such a product in basket");
        }
    }
}
