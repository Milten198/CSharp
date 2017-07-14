using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumFrameworkCsharp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFrameworkCsharp.Pages.Locators
{
    class Task9PageLocators
    {
        [FindsBy(How = How.CssSelector, Using = ".col-md-9.content-container>h1")]
        public IWebElement articleHeader;

        [FindsBy(How = How.XPath, Using = "//i[following-sibling::a[text() = 'Root node']]")]
        public IWebElement nodeRootArrow;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Root')]")]
        public IWebElement nodeRootName;

        [FindsBy(How = How.XPath, Using = "//a[text() = 'Zmień nazwę']")]
        public IWebElement newName;

        [FindsBy(How = How.XPath, Using = "html/body/div[1]/div/div[2]/div[1]/div/ul/li/span/input")]
        public IWebElement newNameInput;

        public IWebElement ChildNodeName(string childNumber)
        {
            return SeleniumExecutor.GetDriver().FindElementByXPath($"//a[text() = 'Child node {childNumber}']");
        }
    }
}