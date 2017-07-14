using SeleniumFrameworkCsharp.Pages.Executors;
using SeleniumFrameworkCsharp.Utilities;
using SeleniumFrameworkCsharp.Utilities.Enums;
using NUnit.Framework;
using TechTalk.SpecFlow;
using SeleniumFrameworkCsharp.Utilities.Objects;
using SeleniumFrameworkCsharp.Utilities.Helpers;
using System.Threading;

namespace SeleniumFrameworkCsharp.Tests.Steps
{
    [Binding]
    public class Task1Steps 
    {
        SeleniumExecutor executor;
        Task1Page task1Page;

        public Task1Steps()
        {
            this.executor = SeleniumExecutor.GetExecutor();
        }

        [BeforeScenario]
        public void BeforeLoginPage()
        {
            task1Page = new Task1Page(executor);
        }

        [When(@"I add product ""(.*)"" with quantity of ""(.*)""")]
        public void WhenIAddProductWithQuantityOf(string productName, string productQuantity)
        {
            task1Page.AddProductToBasket(productName, productQuantity);
        }

        [Then(@"I can see total quantity ""(.*)""")]
        public void ThenICanSeeTotalQuantity(string totalQuantity)
        {
            Assert.AreEqual(totalQuantity, task1Page.GetTotalQuantity());
        }

        [Then(@"I can see total price to pay ""(.*)""")]
        public void ThenICanSeeTotalPriceToPay(string totalPrice)
        {
            Assert.AreEqual(totalPrice, task1Page.GetTotalPriceToPay());
        }

        [Then(@"I can see ""(.*)"" products in basket")]
        public void ThenICanSeeProductsInBasket(int productsInBustket)
        {
            Assert.AreEqual(productsInBustket, task1Page.GetNumberOfProductsFromBasket());
        }

        [Then(@"I remove product ""(.*)"" from basket")]
        public void ThenIRemoveProductFromBasket(string productToRemove)
        {
            task1Page.RemoveProductFromBasket(productToRemove);           
        }
    }
}