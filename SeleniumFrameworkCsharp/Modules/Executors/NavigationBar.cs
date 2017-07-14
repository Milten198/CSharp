using SeleniumFrameworkCsharp.Modules.Locators;
using SeleniumFrameworkCsharp.Pages;
using SeleniumFrameworkCsharp.Utilities;
using SeleniumFrameworkCsharp.Utilities.Helpers;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumFrameworkCsharp.Modules.Executors
{
    public class NavigationBar
    {
        public NavigationBarLocators locators;

        public NavigationBar(SeleniumExecutor executor)
        {
            InitPageHeaderElements();
        }

        public void InitPageHeaderElements()
        {
            locators = new NavigationBarLocators();
            PageFactory.InitElements(SeleniumExecutor.GetDriver(), locators);
        }

        public void GoToNextTask()
        {
            locators.nextTaskButton.ClickWithWait();
        }

        public void GoToPreviousTask()
        {
            locators.previousTaskButton.ClickWithWait();
        }

        public void GoToTaskList()
        {
            locators.taskListButton.ClickWithWait();
        }

    }
}
