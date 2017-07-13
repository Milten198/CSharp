using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFrameworkCsharp.Pages.Locators
{
    class Task10PageLocators
    {
        [FindsBy(How = How.XPath, Using = "//div[@class='jscroll-added']")]
        public IList<IWebElement> loadedFragments;

        [FindsBy(How = How.XPath, Using = "//h3[text() = 'Koniec']")]
        public IWebElement footer;
    }
}