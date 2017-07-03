using OpenQA.Selenium.Support.PageObjects;
using SeleniumFrameworkCsharp.Pages.Locators;
using SeleniumFrameworkCsharp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFrameworkCsharp.Pages.Executors
{
    public class DashboardPage : AbstractPage
    {
        public DashboardPageLocators locators;

        public DashboardPage(SeleniumExecutor executor)
            : base(executor)
        {
            InitDashboardPageElements();
        }

        public void InitDashboardPageElements()
        {
            locators = new DashboardPageLocators();
            PageFactory.InitElements(SeleniumExecutor.GetDriver(), locators);
        }

        public void GoToTask(string taskNumber)
        {
            locators.GetTaskButton(taskNumber).Click();
        }

    }
}
