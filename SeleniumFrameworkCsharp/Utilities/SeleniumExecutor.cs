using SeleniumFrameworkCsharp.Utilities.Configurations;
using SeleniumFrameworkCsharp.Utilities.Enums;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Remote;
using SeleniumFrameworkCsharp.Utilities.Helpers;
using NUnit.Framework.Interfaces;

namespace SeleniumFrameworkCsharp.Utilities
{
    public class SeleniumExecutor
    {
        private static readonly int Timeout = 10; //seconds

        public static SeleniumExecutor executor;
        private static RemoteWebDriver driver;
        private static WebDriverWait waitDriver;

        private static String parentWindowHandle;
        private static IEnumerator<String> windowIterator;

        public static String pageDefaultUrl;

        public SeleniumExecutor()
        {

        }

        public static void BaseSetUp()
        {
            executor = null;
            driver = null;

            driver = CreateDriver();
            parentWindowHandle = driver.CurrentWindowHandle;
            pageDefaultUrl = TestConfiguration.PageDefaultUrl;
        }

        public void ScreenshotReport()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                SeleniumReporter.TakeScreenshot(driver, TestContext.CurrentContext.Test.Name);
            }
            else
            {
                SeleniumReporter.DeleteScreenshotIfExist(TestContext.CurrentContext.Test.Name);
            }
        }

        public void BaseTearDown()
        {
            driver.Close();
            driver.Quit();
        }

        private static void Init()
        {
            if (executor == null)
                executor = new SeleniumExecutor();
        }

        public static SeleniumExecutor GetExecutor()
        {
            Init();
            return executor;
        }

        public static RemoteWebDriver GetDriver()
        {
            return driver;
        }

        public static WebDriverWait GetWaitDriver()
        {
            return waitDriver;
        }

        public static String GetParentWindowHandle()
        {
            return parentWindowHandle;
        }

        public static IEnumerator<String> GetWindowIterator()
        {
            return windowIterator;
        }

        public static void SetWindowIterator()
        {
            windowIterator = driver.WindowHandles.GetEnumerator();
        }

        public static RemoteWebDriver CreateDriver()
        {
            BrowserType browserParameter = TestConfiguration.BrowserParameter;

            if (driver == null)
            {
                switch (browserParameter)
                {
                    case BrowserType.chrome:
                        driver = new ChromeDriver();
                        break;

                    case BrowserType.firefox:
                        //FirefoxProfile profile = new FirefoxProfile();
                        //profile.SetEnableNativeEvents(true);
                        //profile.EnableNativeEvents = true;
                        driver = new FirefoxDriver();
                        break;

                    case BrowserType.ie:
                        driver = new InternetExplorerDriver();
                        break;
                }

                driver.Manage().Window.Maximize();

                waitDriver = new WebDriverWait(driver, TimeSpan.FromSeconds(Timeout));
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(Timeout));

            }

            return driver;
        }

        public static String GetTitle()
        {
            return driver.Title;
        }

        public static String GetUrl()
        {
            return driver.Url;
        }

        public void DeleteCookies()
        {
            driver.Manage().Cookies.DeleteAllCookies();
        }

        public void OpenPage(String url)
        {
            driver.Navigate().GoToUrl(url);
            driver.WaitForNoAjaxRequestsPending();
        }
     
    }
}
