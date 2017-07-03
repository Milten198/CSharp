using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;


namespace SeleniumFrameworkCsharp.Pages.Locators
{
    public class Task1PageLocators
    {
        [FindsBy(How = How.CssSelector, Using = ".thumbnail")]
        public IList<IWebElement> productsThumbnails;

        [FindsBy(How = How.CssSelector, Using = ".row-in-basket")]
        public IList<IWebElement> productsInBasket;

        public IWebElement GetAddButtonForProduct(IWebElement product)
        {
            return product.FindElement(By.TagName("button"));
        }

        public IWebElement GetQuantityInputForProduct(IWebElement product)
        {
            return product.FindElement(By.TagName("input"));
        }

    }
}
