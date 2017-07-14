using NUnit.Framework;
using SeleniumFrameworkCsharp.Pages.Executors;
using SeleniumFrameworkCsharp.Utilities;
using SeleniumFrameworkCsharp.Utilities.Enums;
using System;
using TechTalk.SpecFlow;

namespace SeleniumFrameworkCsharp.Tests.Steps
{
    [Binding]
    public class Task8Steps
    {
        private Task8Page task8Page;
        private SeleniumExecutor executor;

        public Task8Steps()
        {
            executor = SeleniumExecutor.GetExecutor();
            task8Page = new Task8Page(executor);
        }

        [When(@"I select credit card type ""(.*)""")]
        public void WhenISelectCreditCardType(string cardName)
        {
            task8Page.SelectCardType(cardName);
        }

        [When(@"I type name ""(.*)""")]
        public void WhenITypeName(string name)
        {
            task8Page.EnterName(name);
        }

        [When(@"I type credit card number ""(.*)""")]
        public void WhenITypeCreditCardNumber(string cardNumber)
        {
            task8Page.EnterCardNumber(cardNumber);
        }

        [When(@"I type CVV code ""(.*)""")]
        public void WhenITypeCVVCode(string cvvCode)
        {
            task8Page.EnterCVV(cvvCode);
        }

        [When(@"I select expiration date ""(.*)"", ""(.*)""")]
        public void WhenISelectExpirationDate(string month, string year)
        {
            task8Page.SelectMonth(month);
            task8Page.SelectYear(year);
        }

        [When(@"I click pay button")]
        public void WhenIClickPayButton()
        {
            task8Page.Pay();
        }
        [Then(@"Payment message ""(.*)"" is displayed")]
        public void ThenPaymentMessageIsDisplayed(string message)
        {
            Assert.AreEqual(message, task8Page.GetPaymentMessage(), "Incorrect error message");
        }
    }
}
