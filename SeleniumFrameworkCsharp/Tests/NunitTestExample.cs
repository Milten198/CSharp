using NUnit.Framework;
using SeleniumFrameworkCsharp.Pages.Executors;
using SeleniumFrameworkCsharp.Utilities;
using SeleniumFrameworkCsharp.Utilities.Enums;
using SeleniumFrameworkCsharp.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFrameworkCsharp.Tests
{
    [TestFixture]
    public class NunitTestExample
    {
        public DashboardPage dashboard;
        public SeleniumExecutor executor;
        public Task1Page task1Page;
        public Task6Page task6Page;

        public NunitTestExample()
        {

        }


        [TestFixtureSetUp]
        public void SetUp()
        {
            //Before first test
;
        }

        [TearDown]
        public void TestTearDown()
        {
            // After each test
            executor.BaseTearDown();
            executor.ScreenshotReport();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            // Once after all tests
        }

        [SetUp]
        public void FirstSetUp()
        {
            // Before each test
            SeleniumExecutor.BaseSetUp();
            executor = SeleniumExecutor.GetExecutor();
            executor.OpenPage(SeleniumExecutor.pageDefaultUrl);
        }


        [Test]
        public void AddProductToBasketTest()
        {
            /*Arrange*/
            DashboardPage dashboard = new DashboardPage(executor);
            dashboard.GoToTask("1");

            /*Act*/
            task1Page = new Task1Page(executor);
            task1Page.AddProductToBasket("Okulary", "2");

            /*Assert*/
            Assert.True(task1Page.IsProductDisplayedInBasket("Okulary"), "Product was not displayed in basket summary");
        }

        [Test]
        public void LoginToDownloadPage()
        {
            DashboardPage dashboard = new DashboardPage(executor);
            dashboard.GoToTask("6/logged");

            task6Page = new Task6Page(executor);
            task6Page.TypeLogin("tester");
            task6Page.TypePassword("123-xyz");
            task6Page.ClickLoginButton();

            Assert.True(task6Page.IsLoggedPageOpen(), "Logged page is not opened");
        }

        [Test]
        public void Test8()
        {
            DashboardPage dashboard = new DashboardPage(executor);
            dashboard.GoToTask("8");

            Task8Page task8 = new Task8Page(executor);

            task8.SelectCardType("aec");
            RandomStringGenerator generator = new RandomStringGenerator();
            task8.EnterName(generator.GetRandomString(8));
            task8.EnterCardNumber("378734493671000");
            task8.EnterCVV("257");
            task8.SelectMonth(Month.February);
            task8.SelectYear("2017");
            task8.Pay();
        }

    }
}
