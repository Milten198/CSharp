using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace SeleniumFrameworkCsharp.Pages.Locators
{
    class Task2PageLocators
    {
        [FindsBy(How = How.CssSelector, Using = ".select2-selection__arrow")]
        public IWebElement dropDownArrow;

        [FindsBy(How = How.CssSelector, Using = ".select2-search__field")]
        public IWebElement searchBox;

        [FindsBy(How = How.CssSelector, Using = ".caption>p>strong")]
        public IList<IWebElement> categoriesOfProducts;

        [FindsBy(How = How.XPath, Using = "//span/ul/li")]
        public IList<IWebElement> listOfCategories;
    }
}