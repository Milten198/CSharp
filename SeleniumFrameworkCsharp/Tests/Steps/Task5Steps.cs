using System;
using TechTalk.SpecFlow;

namespace SeleniumFrameworkCsharp.Tests.Steps
{
    [Binding]
    public class Task5Steps
    {
        [When(@"I upload file ""(.*)""")]
        public void WhenIUploadFile(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Data from file are shown in table")]
        public void ThenDataFromFileAreShownInTable()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
