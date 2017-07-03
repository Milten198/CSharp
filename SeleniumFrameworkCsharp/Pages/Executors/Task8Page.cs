using OpenQA.Selenium.Support.PageObjects;
using SeleniumFrameworkCsharp.Pages.Locators;
using SeleniumFrameworkCsharp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumFrameworkCsharp.Utilities.Helpers;
using SeleniumFrameworkCsharp.Utilities.Enums;

namespace SeleniumFrameworkCsharp.Pages.Executors
{
    public class Task8Page : AbstractPage
    {
        public Task8PageLocators locators;

        public Task8Page(SeleniumExecutor executor)
            : base(executor)
        {
            locators = new Task8PageLocators();
            InitWebElements();
        }

        public void InitWebElements()
        {
            PageFactory.InitElements(SeleniumExecutor.GetDriver(), locators);
        }

        public void SelectCardType(string type)
        {
            locators.GetCardTypeSelect().SelectByValue(type);
        }

        public void EnterName(string name)
        {
            locators.nameInput.SendKeysWithWait(name);
        }

        public void EnterCardNumber(string number)
        {
            locators.cardNumberInput.SendKeysWithWait(number);
        }

        public void EnterCVV(string cvv)
        {
            locators.cardCVVInput.SendKeysWithWait(cvv);
        }

        public void SelectMonth(Month month)
        {
            locators.GetCardInfoMonthSelect().SelectByText(month.ToString());
        }

        public void SelectYear(string year)
        {
            locators.GetCardInfoYearSelect().SelectByValue(year);
        }

        public void Pay()
        {
            locators.payButton.ClickWithWait();
        }
    }
}
