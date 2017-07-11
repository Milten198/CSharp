using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumFrameworkCsharp.Pages.Locators
{
    class Task3PageLocators
    {
        [FindsBy(How = How.CssSelector, Using = ".dropdown-toggle.menu-border")]
        public IWebElement menuToggle;

        [FindsBy(How = How.CssSelector, Using = "#menu1>li>a")]
        public IWebElement subMenuForm;

        [FindsBy(How = How.CssSelector, Using = "#start-edit")]
        public IWebElement startEdit;

        [FindsBy(How = How.Id, Using = "in-name")]
        public IWebElement nameInput;

        [FindsBy(How = How.Id, Using = "in-surname")]
        public IWebElement surnameInput;

        [FindsBy(How = How.Id, Using = "in-notes")]
        public IWebElement notesInput;

        [FindsBy(How = How.Id, Using = "in-phone")]
        public IWebElement phoneInput;

        [FindsBy(How = How.Id, Using = "in-file")]
        public IWebElement fileInput;

        [FindsBy(How = How.Id, Using = "save-btn")]
        public IWebElement saveButton;

        [FindsBy(How = How.CssSelector, Using = ".notifyjs-bootstrap-base.notifyjs-bootstrap-success>span")]
        public IWebElement confirmationMessage;

        [FindsBy(How = How.CssSelector, Using = ".preview-photo")]
        public IWebElement image;
    }
}