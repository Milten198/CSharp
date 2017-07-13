using SeleniumFrameworkCsharp.Pages.Locators;
using SeleniumFrameworkCsharp.Utilities;
using SeleniumFrameworkCsharp.Utilities.Enums;
using SeleniumFrameworkCsharp.Utilities.Helpers;
using SeleniumFrameworkCsharp.Utilities.Objects;
using OpenQA.Selenium.Support.PageObjects;
using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumFrameworkCsharp.Pages.Executors
{
    public class Task1Page : AbstractPage
    {
        public Task1PageLocators locators;

        public Task1Page(SeleniumExecutor executor)
            : base(executor)
        {
            InitTask1PageElements();
        }

        public void InitTask1PageElements()
        {
            locators = new Task1PageLocators();
            PageFactory.InitElements(SeleniumExecutor.GetDriver(), locators);
        }

        public void AddProductToBasket(string productName, string quantity)
        {
            InitTask1PageElements();
            IWebElement product = GetProductByName(productName);
            locators.GetQuantityInputForProduct(product).ClearWithWait();
            locators.GetQuantityInputForProduct(product).SendKeysWithWait(quantity);
            locators.GetAddButtonForProduct(product).Click();
        }

        public bool IsProductDisplayedInBasket(string productName)
        {
            if (locators.productsInBasket.Count == 0)
            {
                return false;
            }
            else
            {
                return locators.productsInBasket.Where(x => x.Text.Contains(productName)).ToList().Count != 0;
            }
        }

        public string GetTotalPriceToPay()
        {
            return locators.totalPrice.Text;
        }

        public string GetTotalQuantity()
        {
            return locators.totalQuantity.Text;
        }

        public int GetNumberOfProductsFromBasket()
        {
            return locators.productsInBasket.Count;
        }

        public void RemoveProductFromBasket(string productName)
        {
            IWebElement product = GetRemoveButtonByName(productName);
            locators.GetRemoveButtonForProduct(product).Click();
        }

        private IWebElement GetProductByName(string productName)
        {
            return locators.productsThumbnails.First(x => x.Text.Contains(productName));
        }

        private IWebElement GetRemoveButtonByName(string name)
        {
            return locators.removeButtons.First(x => x.Text.Contains(name));
        }

    }
}