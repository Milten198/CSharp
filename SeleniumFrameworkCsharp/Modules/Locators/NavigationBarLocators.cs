using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace SeleniumFrameworkCsharp.Modules.Locators
{
    public class NavigationBarLocators
    {
        [FindsBy(How = How.CssSelector, Using = ".home")]
        public IWebElement taskListButton;

        [FindsBy(How = How.CssSelector, Using = "navbar-task")]
        public IWebElement taskInfo;

        [FindsBy(How = How.CssSelector, Using = "img[alt='Poprzednie']")]
        public IWebElement previousTaskButton;

        [FindsBy(How = How.CssSelector, Using = "img[alt='Następne']")]
        public IWebElement nextTaskButton;

    }
}
