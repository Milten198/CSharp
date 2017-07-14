using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumFrameworkCsharp.Utilities;

using System.Collections.Generic;

namespace SeleniumFrameworkCsharp.Pages.Locators
{
    class Task5PageLocators
    {
        [FindsBy(How = How.CssSelector, Using = ".btn.btn-primary.btn-block.btn-file>input")]
        public IWebElement uploadInput;

        [FindsBy(How = How.XPath, Using = "//tbody/tr")]
        public IList<IWebElement> rows;

        public IList<IWebElement> GetRow(int rowNumber)
        {
            return SeleniumExecutor.GetDriver().FindElementsByXPath($"//tr[{rowNumber}]/td");
        }
    }
}