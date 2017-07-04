using OpenQA.Selenium;
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
    public class Task6Page : AbstractPage
    {
        public Task6PageLocators locators;

        public Task6Page(SeleniumExecutor executor)
            : base(executor)
        {
            InitTask6PageElements();
        }

        public void InitTask6PageElements()
        {
            locators = new Task6PageLocators();
            PageFactory.InitElements(SeleniumExecutor.GetDriver(), locators);
        }

        public bool IsLoginPageOpened()
        {
            return locators.loginButton.Displayed;
        }

        public void TypeLogin(string login)
        {
            locators.loginInput.SendKeys(login);
        }

        public void TypePassword(string password)
        {
            locators.passwordInput.SendKeys(password);
        }

        public void ClickLoginButton()
        {
            locators.loginButton.Click();
        }

        public bool IsLoggedPageOpen()
        {
            return locators.logoutButton.Displayed;
        }

    }
}
