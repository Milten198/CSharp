using SeleniumFrameworkCsharp.Pages;
using SeleniumFrameworkCsharp.Pages.Locators;
using SeleniumFrameworkCsharp.Utilities;
using SeleniumFrameworkCsharp.Utilities.Enums;
using SeleniumFrameworkCsharp.Utilities.Helpers;
using SeleniumFrameworkCsharp.Utilities.Objects;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace SeleniumFrameworkCsharp.Modules.Executors
{
    public class PageHeader
    {
        public PageHeaderLocators locators;

        public PageHeader(SeleniumExecutor executor)
        {
            InitPageHeaderElements();
        }

        public void InitPageHeaderElements()
        {
            locators = new PageHeaderLocators();
            PageFactory.InitElements(SeleniumExecutor.GetDriver(), locators);
        }

        public bool IsAstaLogoDisplayed()
        {
            try
            {
                return locators.astaLogo.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

    }
}
