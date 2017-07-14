using OpenQA.Selenium.Support.PageObjects;
using SeleniumFrameworkCsharp.Pages.Locators;
using SeleniumFrameworkCsharp.Utilities;
using SeleniumFrameworkCsharp.Utilities.Helpers;

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

        public string GetMessageFromAlert()
        {
            SeleniumExecutor.GetDriver().WaitForNoAjaxRequestsPending();
            return SeleniumExecutor.GetDriver().SwitchTo().Alert().Text;
        }
    }
}