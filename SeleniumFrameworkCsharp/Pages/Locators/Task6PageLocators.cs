using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFrameworkCsharp.Pages.Locators
{
    public class Task6PageLocators
    {
        [FindsBy(How = How.Id, Using = "LoginForm__username")]
        public IWebElement loginInput;

        [FindsBy(How = How.Id, Using = "LoginForm__password")]
        public IWebElement passwordInput;

        [FindsBy(How = How.Id, Using = "LoginForm_save")]
        public IWebElement loginButton;

        [FindsBy(How = How.Id, Using = "logout")]
        public IWebElement logoutButton;

        [FindsBy(How = How.CssSelector, Using = ".list-unstyled")]
        public IWebElement loginError;
    }
}
