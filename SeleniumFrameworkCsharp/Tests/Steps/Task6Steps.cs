using NUnit.Framework;
using SeleniumFrameworkCsharp.Pages.Executors;
using SeleniumFrameworkCsharp.Utilities;
using System;
using TechTalk.SpecFlow;

namespace SeleniumFrameworkCsharp.Tests.Steps
{
    [Binding]
    public class Task6Steps
    {
        private Task6Page task6Page;
        private SeleniumExecutor executor;

        public Task6Steps()
        {
            executor = SeleniumExecutor.GetExecutor();
        }

        [BeforeScenario] 
        public void BeforeLoginPage()
        {
            task6Page = new Task6Page(executor);
        }

        [When(@"I am on login page")]
        public void WhenIAmOnLoginPage()
        {
            Assert.True(task6Page.IsLoginPageOpened(), "Login page is not opened");
        }

        [When(@"I type user name ""(.*)""")]
        public void WhenITypeUserName(string login)
        {
            task6Page.TypeLogin(login);
        }

        [When(@"I type password ""(.*)""")]
        public void WhenITypePassword(string password)
        {
            task6Page.TypePassword(password);
        }

        [When(@"I press login button")]
        public void WhenIPressLoginButton()
        {
            task6Page.ClickLoginButton();
        }
        
        [Then(@"I am on logged page with file to download")]
        public void ThenIAmOnLoggedPageWithFileToDownload()
        {
            task6Page.IsLoggedPageOpen();
        }
    }
}
