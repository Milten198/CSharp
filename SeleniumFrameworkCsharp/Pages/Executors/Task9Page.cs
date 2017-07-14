using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumFrameworkCsharp.Pages.Locators;
using SeleniumFrameworkCsharp.Utilities;
using SeleniumFrameworkCsharp.Utilities.Helpers;

namespace SeleniumFrameworkCsharp.Pages.Executors
{

    class Task9Page : AbstractPage
    {
        private Task9PageLocators locators;

        public Task9Page(SeleniumExecutor executor) : base(executor)
        {
            InitTask9PageElements();
        }

        private void InitTask9PageElements()
        {
            locators = new Task9PageLocators();
            PageFactory.InitElements(SeleniumExecutor.GetDriver(), locators);
        }

        public void ClickRootNodeName()
        {
            locators.nodeRootName.Click();
        }

        public void ClickRootNodeArrow()
        {
            locators.nodeRootArrow.Click();
        }

        public void DoubleClickRootNodeName()
        {
            locators.nodeRootName.DoubleClick();
        }

        public string GetArticleHeader()
        {
            return locators.articleHeader.Text;
        }

        public string GetChildNodeName(string childNodeNumber)
        {
            return locators.ChildNodeName(childNodeNumber).Text;
        }

        public void ContextClickOnRootNodeName()
        {
            locators.nodeRootName.ContextClick();
        }

        public void ClickChangeName()
        {
            locators.newName.Click();
        }

        public void SetNewName(string newName)
        {
            locators.newNameInput.SendKeys(newName);
            locators.newNameInput.SendKeys(Keys.Enter);
        }

        public string GetRootNodeName()
        {
            return locators.nodeRootName.Text;
        }
       
    }
}