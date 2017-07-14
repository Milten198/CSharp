using SeleniumFrameworkCsharp.Utilities;
using SeleniumFrameworkCsharp.Pages.Locators;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using SeleniumFrameworkCsharp.Utilities.Helpers;

namespace SeleniumFrameworkCsharp.Pages.Executors
{
    class Task2Page : AbstractPage
    {
        public Task2PageLocators locators;

        public Task2Page(SeleniumExecutor executor)
            : base(executor)
        {
            InitTask2PageElements();
        }

        public void InitTask2PageElements()
        {
            locators = new Task2PageLocators();
            PageFactory.InitElements(SeleniumExecutor.GetDriver(), locators);
        }

        public void ExpandDropDownList()
        {
            locators.dropDownArrow.Click();
        }

        public void SelectCategory(string category)
        {
            var list = locators.listOfCategories;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Text.Equals(category))
                {
                    list[i].Click();
                    break;
                }
            }
        }

        public void TypeTextInSearchBox(string text)
        {
            locators.searchBox.SendKeysWithWait(text);
            locators.searchBox.SendKeys(Keys.Enter);
        }

        public bool VerifyCategoriesOfSelectedProducts(string category)
        {
            bool areProperCategories = true;
            var list = locators.categoriesOfProducts;
            for (int i = 0; i < list.Count; i++)
            {
                if (!list[i].Text.Equals(category)) {
                    areProperCategories = false;
                    break;
                }
            }
            return areProperCategories;
        }
    }
}
