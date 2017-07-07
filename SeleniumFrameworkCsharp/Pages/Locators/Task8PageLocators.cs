using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumFrameworkCsharp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFrameworkCsharp.Pages.Locators
{
    public class Task8PageLocators
    {
        [FindsBy(How = How.Id, Using = "task8_form_name")]
        public IWebElement nameInput;

        public SelectElement GetCardTypeSelect()
        {
            return new SelectElement(SeleniumExecutor.GetDriver().FindElement(By.Id("task8_form_cardType")));
        }

        [FindsBy(How = How.Id, Using = "task8_form_cardNumber")]
        public IWebElement cardNumberInput;

        [FindsBy(How = How.Id, Using = "task8_form_cardCvv")]
        public IWebElement cardCVVInput;

        public SelectElement GetCardInfoMonthSelect()
        {
            return new SelectElement(SeleniumExecutor.GetDriver().FindElement(By.Id("task8_form_cardInfo_month")));
        }

        public SelectElement GetCardInfoYearSelect()
        {
            return new SelectElement(SeleniumExecutor.GetDriver().FindElement(By.Id("task8_form_cardInfo_year")));
        }

        [FindsBy(How = How.Name, Using = "task8_form[save]")]
        public IWebElement payButton;

        [FindsBy(How = How.CssSelector, Using = ".list-unstyled>li")]
        public IWebElement paymentMessage;
    }
}
