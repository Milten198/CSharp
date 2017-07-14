using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFrameworkCsharp.Pages.Locators
{
    class Task7Locators
    {
        [FindsBy(How = How.CssSelector, Using = ".col-md-12.place-to-drop.ui-droppable")]
        public IWebElement dropPlace;

        [FindsBy(How = How.CssSelector, Using = ".row-in-basket")]
        public IList<IWebElement> productsInBasket;

        public By product(string productName)
        {
            return By.XPath($"//div[2][h4='{productName}']/div/input");
        }

        public By logo(string productLogo)
        {
            return By.XPath($"//div[img][following-sibling::div/h4[text() = '{productLogo}']]");
        }
    }
}
