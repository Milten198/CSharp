using NUnit.Framework;
using SeleniumFrameworkCsharp.Pages.Executors;
using SeleniumFrameworkCsharp.Utilities;
using System.Threading;
using TechTalk.SpecFlow;

namespace SeleniumFrameworkCsharp.Tests.Steps
{
    [Binding]
    public class ExpandingNodesSteps
    {
        private SeleniumExecutor executor;
        private Task9Page task9page;

        public ExpandingNodesSteps()
        {
            task9page = new Task9Page(executor);
        }

        [BeforeScenario]
        public void BeforePage()
        {
            executor = SeleniumExecutor.GetExecutor();
        }

        [When(@"I click root node name")]
        public void WhenIClickRootNodeName()
        {
            task9page.ClickRootNodeName();
        }

        [Then(@"I can see article with header ""(.*)""")]
        public void ThenICanSeeArticleWithHeader(string header)
        {
            Assert.AreEqual(header, task9page.GetArticleHeader());
        }

        [When(@"I click root node arrow")]
        public void WhenIClickRootNodeArrow()
        {
            task9page.ClickRootNodeArrow();
        }

        [Then(@"I can see ""(.*)"" child node name ""(.*)""")]
        public void ThenICanSeeChildNodeName(string childNumber, string childNodeName)
        {
            Assert.AreEqual(childNodeName, task9page.GetChildNodeName(childNumber));
        }

        [When(@"I double click root node arrow")]
        public void WhenIDoubleClickRootNodeArrow()
        {
            task9page.DoubleClickRootNodeName();
        }

        [When(@"I click right button on root node name")]
        public void WhenIClickRightButtonOnRootNodeName()
        {
            task9page.ContextClickOnRootNodeName();
        }

        [When(@"I click on change name button")]
        public void WhenIClickOnChangeNameButton()
        {
            task9page.ClickChangeName();
        }

        [When(@"I type new name ""(.*)""")]
        public void WhenITypeNewName(string newName)
        {
            task9page.SetNewName(newName);
        }

        [Then(@"I can see root node name ""(.*)""")]
        public void ThenICanSeeRootNodeName(string rootNodeName)
        {
            Assert.AreEqual(rootNodeName, task9page.GetRootNodeName());
        }

    }
}