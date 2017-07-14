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

        [FindsBy(How = How.CssSelector, Using = ".summary-quantity")]
        public IWebElement totalQuantity;

        [FindsBy(How = How.CssSelector, Using = ".summary-price")]
        public IWebElement totalPrice;

        [FindsBy(How = How.CssSelector, Using = ".col-md-12.basket-list")]
        public IList<IWebElement> removeButtons;

        public IWebElement GetAddButtonForProduct(IWebElement product)
        {
            return product.FindElement(By.TagName("button"));
        }

        public IWebElement GetRemoveButtonForProduct(IWebElement product)
        {
            return product.FindElement(By.CssSelector(".btn.btn-sm"));
        }

        public IWebElement GetQuantityInputForProduct(IWebElement product)
        {
            return product.FindElement(By.TagName("input"));
        }

    }
}
