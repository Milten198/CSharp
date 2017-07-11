using System.Linq;
using SeleniumFrameworkCsharp.Utilities;
using SeleniumFrameworkCsharp.Pages.Locators;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumFrameworkCsharp.Pages.Executors
{
    class Task4Window : AbstractPage
    {
        private Task4WindowLocators locators;

        public Task4Window(SeleniumExecutor executor)
            : base(executor)
        {
            InitTask4WindowElement();
        }

        public void InitTask4WindowElement()
        {
            locators = new Task4WindowLocators();
            PageFactory.InitElements(SeleniumExecutor.GetDriver(), locators);
        }

        public bool IsFormWindowOpened()
        {
            SwitchToWindow();
            SwitchToFrame();
            return locators.saveButton.Displayed;
        }

        public void SetName(string name)
        {
            locators.nameInput.SendKeys(name);
        }

        public void SetEmail(string email)
        {
            locators.emailInput.SendKeys(email);
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            locators.phoneInput.SendKeys(phoneNumber);
        }

        public void SaveForm()
        {
            locators.saveButton.Click();
        }

        public string GetConfirmationMessage()
        {
            return locators.confirmationMessage.Text;
        }

        private void SwitchToFrame()
        {
            SeleniumExecutor.GetDriver().SwitchTo()
                .Frame(locators.frame);
        }

        private void SwitchToWindow()
        {
            SeleniumExecutor.GetDriver().SwitchTo()
                .Window(SeleniumExecutor.GetDriver()
                .WindowHandles.Last());
        }
    }
}