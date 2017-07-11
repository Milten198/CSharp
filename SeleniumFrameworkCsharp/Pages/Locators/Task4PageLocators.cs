using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFrameworkCsharp.Pages.Locators
{
    class Task4PageLocators
    {
        [FindsBy(How = How.CssSelector, Using = ".btn.btn-primary.btn-block.js-open-window")]
        public IWebElement applyButton;
    }
}
