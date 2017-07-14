using SeleniumFrameworkCsharp.Utilities;
using SeleniumFrameworkCsharp.Pages.Locators;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumFrameworkCsharp.Pages.Executors
{
    class Task4Page : AbstractPage
    {
        private Task4PageLocators locators;
        public Task4Page(SeleniumExecutor executor) 
            : base(executor)
        {
            InitTask4PageElement();
        }

        public void InitTask4PageElement()
        {
            locators = new Task4PageLocators();
            PageFactory.InitElements(SeleniumExecutor.GetDriver(), locators);
        }

        public void OpenWindowWithForm()
        {
            locators.applyButton.Click();
        }
    }
}