using System;
using SeleniumFrameworkCsharp.Utilities;
using SeleniumFrameworkCsharp.Pages.Locators;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumFrameworkCsharp.Utilities.Helpers;

namespace SeleniumFrameworkCsharp.Pages.Executors
{
    class Task3Page : AbstractPage
    {
        private Task3PageLocators locators;
        private const string name = "Max";
        private const string surname = "Kolonko";
        private const string notes = "Mówię jak jest";
        private const string phone = "800900100";

        public Task3Page(SeleniumExecutor executor)
            : base(executor)
        {
            InitTask2PageElements();
        }

        public void InitTask2PageElements()
        {
            locators = new Task3PageLocators();
            PageFactory.InitElements(SeleniumExecutor.GetDriver(), locators);
        }

        public void SetEditableMode()
        {
            locators.menuToggle.PerformMouseover();
            locators.subMenuForm.PerformMouseover();
            locators.startEdit.Click();
        }

        public void ClearAllFields()
        {
            locators.nameInput.ClearWithWait();
            locators.surnameInput.ClearWithWait();
            locators.notesInput.ClearWithWait();
            locators.phoneInput.ClearWithWait();
        }

        public void FillInForm()
        {
            locators.nameInput.SendKeysWithWait(Name);
            locators.surnameInput.SendKeysWithWait(Surname);
            locators.notesInput.SendKeysWithWait(Notes);
            locators.phoneInput.SendKeysWithWait(Phone);
        }

        public void UploadFile()
        {
            string uuserPath = AppDomain.CurrentDomain.BaseDirectory + @"Files/bob.jpg";
            locators.fileInput.SendKeys(uuserPath);
        }

        public void SaveForm()
        {
            locators.saveButton.Click();
        }

        public string GetConfirmationMessageWithWait()
        {
            SeleniumExecutor.GetDriver().WaitForElementToBeDisplayed(locators.confirmationMessage);
            return locators.confirmationMessage.Text;
        }

        public string VerifyName()
        {
            return locators.nameInput.GetAttribute("value");
        }

        public string VerifySurname()
        {
            return locators.surnameInput.GetAttribute("value");
        }

        public string VerifyNotes()
        {
            return locators.notesInput.GetAttribute("value");
        }

        public string VerifyPhone()
        {
            return locators.phoneInput.GetAttribute("value");
        }

        public string VerifyPhotoSrc()
        {
            return locators.image.GetAttribute("src");
        }

        public bool IsFormEditable()
        {
            bool canNotEdit = false;
            try
            {
                locators.nameInput.SendKeysWithWait(Name);
            } catch (System.Exception ex)
            {
                if (ex.Message.Contains("Exception has been thrown by the target of an invocation."))
                {
                    canNotEdit = true;
                }
            }
            return canNotEdit;
        }

        public string Name { get; set; } = name;
        public string Surname { get; set; } = surname;
        public string Notes { get; set; } = notes;
        public string Phone { get; set; } = phone;
    }
}