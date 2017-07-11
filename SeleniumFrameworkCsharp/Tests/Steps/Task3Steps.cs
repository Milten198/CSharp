using NUnit.Framework;
using SeleniumFrameworkCsharp.Pages.Executors;
using SeleniumFrameworkCsharp.Utilities;
using TechTalk.SpecFlow;

namespace SeleniumFrameworkCsharp.Tests.Steps
{
    [Binding]
    public class Task3Steps
    {
        private Task3Page task3page;
        private SeleniumExecutor executor;

        public Task3Steps()
        {
            executor = SeleniumExecutor.GetExecutor();
        }

        [BeforeScenario]
        public void BeforePage()
        {
            task3page = new Task3Page(executor);
        }

        [When(@"I start the editable mode")]
        public void WhenIStartTheEditableMode()
        {
            task3page.SetEditableMode();
        }

        [When(@"I fill all fields with correct data")]
        public void WhenIFillAllFieldsWithCorrectData()
        {
            task3page.ClearAllFields();
            task3page.FillInForm();
        }

        [When(@"I upload photo")]
        public void WhenIUploadPhoto()
        {
            task3page.UploadFile();
        }

        [When(@"I click save button")]
        public void WhenIClickSaveButton()
        {
            task3page.SaveForm();
        }

        [Then(@"Message ""(.*)"" should appears")]
        public void ThenMessageShouldAppears(string message)
        {
            Assert.AreEqual(message, task3page.GetConfirmationMessageWithWait());
        }

        [Then(@"All fields have correct data")]
        public void ThenAllFieldsHaveCorrectData()
        {
            Assert.AreEqual(task3page.Name, task3page.VerifyName());
            Assert.AreEqual(task3page.Surname, task3page.VerifySurname());
            Assert.AreEqual(task3page.Notes, task3page.VerifyNotes());
            Assert.AreEqual(task3page.Phone, task3page.VerifyPhone());
            Assert.True(task3page.VerifyPhotoSrc().Contains("data:image/jpeg;base64"));
        }
    }
}