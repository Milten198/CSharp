using SeleniumFrameworkCsharp.Utilities.Configurations;
using SeleniumFrameworkCsharp.Utilities.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;

namespace SeleniumFrameworkCsharp.Utilities.Helpers
{
    public static class SeleniumScroll
    {
        public static IWebElement ScrollToElement(this IWebElement element)
        {
            IWebDriver driver = SeleniumExecutor.GetDriver();
            String position = element.Location.Y.ToString();
            String script = String.Format("$('#main-container').scrollTop({0})", position);
            ((IJavaScriptExecutor)driver).ExecuteScript(script);

            return element;
        }

        // onther working method
        //public static void ScrollToElement(this IWebElement we)
        //{
        //    RemoteWebElement element = (RemoteWebElement)we;
        //    var focusOnElement = element.LocationOnScreenOnceScrolledIntoView;
        //}
    }

    public static class SeleniumClick
    {
        public static void ClickWithWait(this IWebElement e)
        {
            IWebDriver driver = SeleniumExecutor.GetDriver();
            driver.WaitForNoAjaxRequestsPending();
            e.ScrollToElement();
            driver.WaitForElementToBeDisplayed(e);
            e.Click();
            driver.WaitUntilSpinnerIsNotDisplayed();
        }

        public static void ClickElementNumberFromElementList(this IList<IWebElement> webElement, int item)
        {
            webElement[item].Click();
        }

        public static void ClickElementWithTextFromElementList(this IList<IWebElement> links, String item)
        {
            try
            {
                links.First(element => element.Text == item).Click();
            }
            catch (Exception)
            {
                try
                {
                    links.First(element => element.Text.Contains(item)).Click();
                }
                catch (Exception)
                {
                    links.First(element => element.GetElementAttribute(AttributeType.value).Contains(item)).Click();
                }
            }
        }

        public static void ClickElementRandomFromElementList(this IList<IWebElement> webElements, int howMany)
        {
            for (int i = 0; i <= howMany; i++)
            {
                webElements.GetElementWithTextFromElementList("any").Click();
            }
        }

        public static void DoubleClick(this IWebElement objectName)
        {
            Actions actionProvider = new Actions(SeleniumExecutor.GetDriver());
            actionProvider.DoubleClick(objectName)
                .Build().Perform();
        }

        public static void ContextClick(this IWebElement objectName)
        {
            Actions actionProvider = new Actions(SeleniumExecutor.GetDriver());
            actionProvider.ContextClick(objectName)
                .Build().Perform();
        }
    }

    public static class SeleniumSendKeys
    {
        public static void SendKeysWithWait(this IWebElement e, String text)
        {
            IWebDriver driver = SeleniumExecutor.GetDriver();
            driver.WaitForNoAjaxRequestsPending();
            driver.WaitForElementToBeDisplayed(e);
            e.SendKeys(text);
        }
    }

    public static class SeleniumClear
    {
        public static void ClearWithWait(this IWebElement e)
        {
            IWebDriver driver = SeleniumExecutor.GetDriver();
            driver.WaitForNoAjaxRequestsPending();
            driver.WaitForElementToBeDisplayed(e);
            e.Clear();
        }
    }

    public static class SeleniumGetText
    {
        public static List<String> GetTextListFromElementList(this IList<IWebElement> list)
        {
            List<String> finalList = new List<String>();

            foreach (IWebElement element in list)
            {
                String text = element.Text;
                finalList.Add(text);
            }
            return finalList;
        }

        public static String GetTextFromElementList(this IList<IWebElement> list)
        {
            return list.GetTextFromElementList("any");
        }

        public static String GetTextFromElementList(this IList<IWebElement> list, String caption)
        {
            if (caption.Equals("any"))
            {
                Random r = new Random();
                int m = r.Next(list.Count);
                caption = list[m].Text;
            }
            return caption;
        }
    }

    public static class SeleniumFind
    {
        public static IWebElement FindElementWithWait(this IWebElement e, By by)
        {
            IWebDriver driver = SeleniumExecutor.GetDriver();
            driver.WaitForNoAjaxRequestsPending();
            IWebElement element = e.FindElement(by);
            element.ScrollToElement();
            return element;
        }

        public static IList<IWebElement> FindElementsWithWait(this IWebElement e, By by)
        {
            IWebDriver driver = SeleniumExecutor.GetDriver();
            driver.WaitForNoAjaxRequestsPending();
            return e.FindElements(by);
        }
    }

    public static class SeleniumGetElement
    {
        public static IWebElement GetElementRandomFromElementList(this IList<IWebElement> list)
        {
            return list.GetElementWithTextFromElementList("any");
        }

        public static IWebElement GetElementWithTextFromElementList(this IList<IWebElement> list, String caption)
        {
            if (caption.Equals("any"))
            {
                Random r = new Random();
                caption = list[r.Next(list.Count)].Text;
            }
            return list.First(x => x.Text.Contains(caption));
        }
    }

    public static class SeleniumGetAttribute
    {
        public static String GetElementAttribute(this IWebElement webElement, AttributeType attribute)
        {
            return webElement.GetAttribute(attribute.ToString());
        }

        public static String GetAttributeWithWait(this IWebElement e, String attribute)
        {
            IWebDriver driver = SeleniumExecutor.GetDriver();
            driver.WaitForNoAjaxRequestsPending();
            return e.GetAttribute(attribute);
        }
    }

    public static class SeleniumWait
    {
        public static void WaitForNoAjaxRequestsPending(this IWebDriver driver)
        {
            WebDriverWait waitDriver = SeleniumExecutor.GetWaitDriver();

            try
            {
                waitDriver.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript(@"return document.readyState").ToString().Equals("complete", StringComparison.InvariantCultureIgnoreCase));
                waitDriver.Until(d => (bool)(d as IJavaScriptExecutor).ExecuteScript(@"return jQuery.active == 0"));
            }
            catch (Exception e)
            {
                return;
            }

        }

        public static void WaitForElementToBeDisplayed(this IWebDriver driver, IWebElement e)
        {
            WebDriverWait waitDriver = SeleniumExecutor.GetWaitDriver();
            waitDriver.Until(d => (bool)e.Displayed == true);

        }

        public static void WaitForElementToBeEnabled(this IWebDriver driver, IWebElement e)
        {
            WebDriverWait waitDriver = SeleniumExecutor.GetWaitDriver();
            waitDriver.Until(d => (bool)e.Enabled == true);
        }

        public static void WaitForElementToBeNotDisplayed(this IWebDriver driver, By by)
        {
            WebDriverWait waitDriver = SeleniumExecutor.GetWaitDriver();
            try
            {
                waitDriver.Until(d => d.FindElement(by).Displayed == false);
            }
            catch (Exception)
            {
                waitDriver.Until(d => d.FindElements(by).Count == 0);
            }
        }

        public static void WaitUntilSpinnerIsNotDisplayed(this IWebDriver driver)
        {
            IList<IWebElement> list = new List<IWebElement>();

            do
            {
                list = driver.FindElements(By.Id("global-progress-indicator")); //ID of element which is a ProgressBar
            } while (list.Count != 0);

        }
    }

    public static class SeleniumIsDisplayed
    {
        public static bool IsElementDisplayed(this IWebDriver driver, By by)
        {
            IList<IWebElement> list = driver.FindElements(by);

            if (list.Count == 0)
            {
                return false;
            }
            else
            {
                return list[0].Displayed;
            }
        }
    }

    public static class SeleniumIsPresent
    {

        public static bool IsElementPresent(this IWebElement webElement)
        {
            try
            {
                bool isPresent = webElement.Displayed;
                return isPresent;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }

    public static class SeleniumAlertHandle
    {
        public static void AlertHandle(this IWebDriver driver, bool accept)
        {
            //This method helps to handle confirm popup window
            switch (accept)
            {
                case false:
                    driver.SwitchTo().Alert().Dismiss();
                    break;
                case true:
                    driver.SwitchTo().Alert().Accept();
                    break;
            }
        }
    }

    public static class SeleniumFrame
    {
        public static void SendKeysToFrameAny(this IWebDriver driver, String message)
        {
            driver.SendKeysToFrameNumber(message, 0);
        }

        public static void SendKeysToFrameNumber(this IWebDriver driver, String message, int frameNumber)
        {
            driver.SwitchTo().Frame(driver.FindElements(By.XPath("//iframe"))[frameNumber]);

            IWebElement textInput = driver.FindElement(By.Id("tinymce"));
            textInput.Clear();
            textInput.Click();
            textInput.SendKeys(message);

            driver.SwitchTo().Window(driver.CurrentWindowHandle);
        }

        public static List<String> GetTextListFromFrame(this IWebDriver driver)
        {
            List<String> text = new List<String>();

            IList<IWebElement> elements = driver.FindElements(By.XPath("//iframe"));

            foreach (IWebElement element in elements)
            {
                try
                {
                    if (!text.Any() || text.All(x => string.IsNullOrEmpty(x)))
                    {
                        driver.SwitchTo().Frame(element);
                        IList<IWebElement> textInputs = driver.FindElements(By.TagName("div"));

                        text = textInputs.Select(we => we.Text).ToList();

                        driver.SwitchTo().Window(driver.CurrentWindowHandle);
                    }
                }
                catch (Exception e) { driver.SwitchTo().Window(driver.CurrentWindowHandle); }
            }

            return text;
        }
    }

    public static class SeleniumSwitchWindow
    {
        public static IWebDriver SwitchToWindow(this IWebDriver driver, String windowHandle)
        {
            IWebDriver tmp = driver.SwitchTo().Window(windowHandle);
            try
            {
                Thread.Sleep(500);
            }
            catch (Exception)
            {
            }
            return tmp;
        }

        public static void SwitchToParentWindow(this IWebDriver driver)
        {
            driver.SwitchToWindow(SeleniumExecutor.GetParentWindowHandle());
        }

        public static bool SwitchToAnyNotParentWindow(this IWebDriver driver)
        {
            SeleniumExecutor.SetWindowIterator();
            IEnumerator<String> windowIterator = SeleniumExecutor.GetWindowIterator();
            String parentWindowHandle = SeleniumExecutor.GetParentWindowHandle();

            while (windowIterator.MoveNext())
            {
                String windowHandle = windowIterator.Current;

                if (!windowHandle.Equals(parentWindowHandle))
                {
                    driver.SwitchToWindow(windowHandle);
                    return true;
                }
            }

            driver.SwitchToParentWindow();
            return false;
        }

        public static bool SwitchToWindowWithUrl(this IWebDriver driver, String url)
        {
            if (SeleniumExecutor.GetUrl().Contains(url))
                return true;

            IWebDriver popup = null;
            SeleniumExecutor.SetWindowIterator();
            IEnumerator<String> windowIterator = SeleniumExecutor.GetWindowIterator();

            while (windowIterator.MoveNext())
            {
                String windowHandle = windowIterator.Current;

                popup = driver.SwitchToWindow(windowHandle);
                if (popup.Url.Contains(url))
                {
                    return true;
                }
            }

            driver.SwitchToParentWindow();
            return false;
        }

        public static bool SwitchToWindowWithTitle(this IWebDriver driver, String title)
        {
            if (SeleniumExecutor.GetTitle().Contains(title))
                return true;

            IWebDriver popup = null;
            SeleniumExecutor.SetWindowIterator();
            IEnumerator<String> windowIterator = SeleniumExecutor.GetWindowIterator();

            while (windowIterator.MoveNext())
            {
                String windowHandle = windowIterator.Current;

                popup = driver.SwitchToWindow(windowHandle);
                if (popup.Title.Contains(title))
                {
                    return true;
                }
            }

            driver.SwitchToParentWindow();
            return false;
        }
    }

    public static class SeleniumCloseWindow
    {
        public static void CloseWindow(this IWebDriver driver)
        {
            driver.Close();
            driver.Navigate().GoToUrl("");
        }

        public static void CloseAnyNotParentWindow(this IWebDriver driver)
        {
            while (driver.SwitchToAnyNotParentWindow())
            {
                SeleniumExecutor.GetDriver().Close();
                try
                {
                    Thread.Sleep(500);
                }
                catch (Exception)
                {
                }
            }
            driver.SwitchToParentWindow();
        }
    }

    public static class SeleniumIsWindow
    {
        public static bool IsWindowWithTitlePresent(this IWebDriver driver, String title)
        {
            bool isPresent = false;
            String recentWindow;
            String parentWindowHandle = SeleniumExecutor.GetParentWindowHandle();

            try
            {
                recentWindow = driver.CurrentWindowHandle;
            }
            catch (NoSuchWindowException)
            {
                recentWindow = parentWindowHandle;
            }

            driver.SwitchToWindow(recentWindow);

            if (SeleniumExecutor.GetTitle().Contains(title))
            {
                isPresent = true;
            }
            else
            {
                IWebDriver popup = null;
                SeleniumExecutor.SetWindowIterator();
                IEnumerator<String> windowIterator = SeleniumExecutor.GetWindowIterator();

                while (windowIterator.MoveNext())
                {
                    String windowHandle = windowIterator.Current;

                    popup = driver.SwitchToWindow(windowHandle);
                    if (popup.Title.Contains(title))
                    {
                        isPresent = true;
                        break;
                    }
                }
            }

            driver.SwitchToWindow(recentWindow);
            return isPresent;
        }

        public static bool IsWindowWithUrlPresent(this IWebDriver driver, String url)
        {
            bool isPresent = false;
            String recentWindow;
            String parentWindowHandle = SeleniumExecutor.GetParentWindowHandle();

            try
            {
                recentWindow = driver.CurrentWindowHandle;
            }
            catch (NoSuchWindowException)
            {
                recentWindow = parentWindowHandle;
            }

            driver.SwitchToWindow(recentWindow);

            if (SeleniumExecutor.GetUrl().Contains(url))
            {
                isPresent = true;
            }
            else
            {
                IWebDriver popup = null;
                SeleniumExecutor.SetWindowIterator();
                IEnumerator<String> windowIterator = SeleniumExecutor.GetWindowIterator();

                while (windowIterator.MoveNext())
                {
                    String windowHandle = windowIterator.Current;

                    popup = driver.SwitchToWindow(windowHandle);
                    if (popup.Url.Contains(url))
                    {
                        isPresent = true;
                        break;
                    }
                }
            }

            driver.SwitchToWindow(recentWindow);
            return isPresent;
        }
    }

    public static class SeleniumReporter
    {
        public static void TakeScreenshot(this IWebDriver driver, String testName)
        {
            try
            {
                ITakesScreenshot tsdriver = driver as ITakesScreenshot;
                Screenshot image = tsdriver.GetScreenshot();
                string path = GetScreenshotFullPath(testName);
                DeleteScreenshotIfExist(path);
                image.SaveAsFile(path, ImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void DeleteScreenshotIfExist(String pathWithFileName)
        {
            try
            {
                if (File.Exists(pathWithFileName))
                {
                    File.Delete(pathWithFileName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static string GetScreenshotFullPath(string name)
        {
            return Path.Combine(TestConfiguration.ScreenshotDirectory, String.Format("{0}.png", name));
        }

    }

    public static class SeleniumPerform
    {
        public static void PerformMouseover(this IWebElement we)
        {
            IWebDriver driver = SeleniumExecutor.GetDriver();
            Actions action = new Actions(driver);

            action.MoveToElement(we).Perform();
        }

        public static void PerformClick(this IWebElement we)
        {
            IWebDriver driver = SeleniumExecutor.GetDriver();
            Actions action = new Actions(driver);

            action.MoveToElement(we).Click().Perform();
        }
    }
}