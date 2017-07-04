using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumFrameworkCsharp.Pages.Locators;
using SeleniumFrameworkCsharp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFrameworkCsharp.Pages.Executors
{
    class Task7Page : AbstractPage
    {
        private Task7Locators locators;

        public Task7Page(SeleniumExecutor executor)
            : base(executor)
        {
            InitTask7PageElements();
        }

        public void InitTask7PageElements()
        {
            locators = new Task7Locators();
            PageFactory.InitElements(SeleniumExecutor.GetDriver(), locators);
        }

        public void SetProductQuantity(string productQuantity, string productName)
        {
            IWebElement product = SeleniumExecutor.GetDriver().FindElement(locators.product(productName));
            product.Clear();
            product.SendKeys(productQuantity);
        }

        public void DragAndDropProduct(string productLogo)
        {
            IWebElement logo = SeleniumExecutor.GetDriver().FindElement(locators.logo(productLogo));
            Actions action = new Actions(SeleniumExecutor.GetDriver());
            action.DragAndDrop(logo, locators.dropPlace);
            action.Perform();
        }

        public bool IsProductInBasket(string productName)
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
    }
}