using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace SeleniumFrameworkCsharp.Pages.Locators
{
    public class PageHeaderLocators
    {
        [FindsBy(How = How.CssSelector, Using = "img[alt='ASTA']")]
        public IWebElement astaLogo;

        [FindsBy(How = How.CssSelector, Using = "img[alt='PGS Software']")]
        public IWebElement pgsLogo;

    }
}
