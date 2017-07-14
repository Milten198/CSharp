using NUnit.Framework;
using SeleniumFrameworkCsharp.Pages.Executors;
using SeleniumFrameworkCsharp.Utilities;
using TechTalk.SpecFlow;

namespace SeleniumFrameworkCsharp.Tests.Steps
{

    [Binding]
    public class Task4Steps
    {
        private Task4Page task4page;
        private Task4Window task4window;
        private SeleniumExecutor executor;

        public Task4Steps()
        {
            executor = SeleniumExecutor.GetExecutor();
        }

        [BeforeScenario]
        public void BeforePage()
        {
            task4page = new Task4Page(executor);
            task4window = new Task4Window(executor);
        }

        [Given(@"I click on apply button")]
        public void GivenIClickOnApplyButton()
        {
            task4page.OpenWindowWithForm();
        }

        [Given(@"Form in new window opens")]
        public void GivenFormInNewWindowOpens()
        {
            Assert.True(task4window.IsFormWindowOpened());
        }

        [When(@"I fill name field with ""(.*)""")]
        public void WhenIFillNameFieldWith(string name)
        {
            task4window.SetName(name); 
        }

        [When(@"I fill email field with ""(.*)""")]
        public void WhenIFillEmailFieldWith(string email)
        {
            task4window.SetEmail(email);
        }

        [When(@"I fill phone field with ""(.*)""")]
        public void WhenIFillPhoneFieldWith(string phoneNumber)
        {
            task4window.SetPhoneNumber(phoneNumber);
        }

        [When(@"I save this form")]
        public void WhenISaveThisForm()
        {
            task4window.SaveForm();
        }

        [Then(@"I can see message ""(.*)""")]
        public void ThenICanSeeMessage(string message)
        {
            Assert.AreEqual(message, task4window.GetConfirmationMessage());
        }

        [Then(@"I can see error message ""(.*)"" for email")]
        public void ThenICanSeeErrorMessageForEmail(string message)
        {
            Assert.AreEqual(message, task4window.GetErrorMessage("1"));
        }

        [Then(@"I can see error message ""(.*)"" for phone number")]
        public void ThenICanSeeErrorMessageForPhoneNumber(string message)
        {
            Assert.AreEqual(message, task4window.GetErrorMessage("2"));
        }

    }
}