using SeleniumFrameworkCsharp.Pages.Executors;
using SeleniumFrameworkCsharp.Utilities;
using SeleniumFrameworkCsharp.Utilities.Enums;
using NUnit.Framework;
using TechTalk.SpecFlow;
using SeleniumFrameworkCsharp.Utilities.Objects;
using SeleniumFrameworkCsharp.Utilities.Helpers;

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

        [When(@"I add ""(.*)"" product to basket in quantity ""(.*)""")]
        public void WhenIAddProductToBasketInQuantity(string productName, int quantity)
        {
            task1Page.AddProductToBasket(productName, quantity.ToString());
            ScenarioContext.Current.Add("productName", productName);
        }

        [Then(@"this product is shown in basket summary")]
        public void ThenThisProductIsShownInBasketSummary()
        {
            string productName = ScenarioContext.Current.Get<string>("productName");
            Assert.True(task1Page.IsProductDisplayedInBasket(productName), "Product was not displayed in basket summary");
        }

        [Then(@"this product is not shown in basket summary")]
        public void ThenThisProductIsNotShownInBasketSummary()
        {
            string productName = ScenarioContext.Current.Get<string>("productName");
            Assert.False(task1Page.IsProductDisplayedInBasket(productName), "Product was displayed in basket summary");
        }

        /*Example how to compare two objects*/
        [Then(@"objects are equal")]
        public void ObjectAreEqual()
        {
            Users user1 = new Users("aaa", "bb");
            Users user2 = new Users("aaaa", "bb");

            Assert.AreEqual(SerializeObjectToJson.SerializeToJson(user1), SerializeObjectToJson.SerializeToJson(user2), "Objects were not equal");
        }
    }
}
