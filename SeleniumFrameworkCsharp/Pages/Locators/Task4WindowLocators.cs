using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumFrameworkCsharp.Utilities;
using SeleniumFrameworkCsharp.Utilities.Enums;

namespace SeleniumFrameworkCsharp.Pages.Locators
{
    class Task4WindowLocators
    {
        [FindsBy(How = How.XPath, Using = "//iframe")]
        public IWebElement frame;

        [FindsBy(How = How.Id, Using = "save-btn")]
        public IWebElement saveButton;

        [FindsBy(How = How.XPath, Using = "//input[@name='name']")]
        public IWebElement nameInput;

        [FindsBy(How = How.XPath, Using = "//input[@name='email']")]
        public IWebElement emailInput;

        [FindsBy(How = How.XPath, Using = "//input[@name='phone']")]
        public IWebElement phoneInput;

        [FindsBy(How = How.CssSelector, Using = ".container>h1")]
        public IWebElement confirmationMessage;

        public IWebElement errorFields(string error)
        {
            return SeleniumExecutor.GetDriver().FindElement(By.XPath($"(//span[@class='error'])[{error}]"));
        }
    }
}