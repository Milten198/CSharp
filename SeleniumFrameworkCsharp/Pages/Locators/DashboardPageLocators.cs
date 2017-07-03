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
    public class DashboardPageLocators
    {

        public IWebElement GetTaskButton(string taskNumber)
        {
            return SeleniumExecutor.GetDriver().FindElement(By.CssSelector("a[href='/task_" + taskNumber + "']"));
        }

    }
}
