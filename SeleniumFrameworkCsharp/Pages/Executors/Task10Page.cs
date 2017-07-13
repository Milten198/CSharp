using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumFrameworkCsharp.Utilities;
using SeleniumFrameworkCsharp.Pages.Locators;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumFrameworkCsharp.Tests.Steps;
using SeleniumFrameworkCsharp.Utilities.Helpers;

namespace SeleniumFrameworkCsharp.Pages.Executors
{
    class Task10Page : AbstractPage
    {
        private Task10PageLocators locators;

        public Task10Page(SeleniumExecutor executor)
            : base(executor)
        {
            InitTask10PageElements();
        }

        public void InitTask10PageElements()
        {
            locators = new Task10PageLocators();
            PageFactory.InitElements(SeleniumExecutor.GetDriver(), locators);
        }

        public void ScrollToFooter()
        {
            while (!locators.footer.Displayed)
                SeleniumScroll.ScrollPageDown();
        }

        public bool IsFooterVisible()
        {
            return locators.footer.Displayed;
        }

        public int CountLoadedFragment()
        {
            return locators.loadedFragments.Count;
        }
    }
}