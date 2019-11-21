using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using DesafioUtils.SeleniumUtilitarios;
using DesafioUtils.ExtentReport;
using System.Configuration;

namespace DesafioUtils.SeleniumHelpers
{
    public static class DynamicWaitHelper
    {
        private static IWebDriver driver;


        public static void WaitElementToBeClickable(this IWebElement element)
        {
            try
            {
                new WebDriverWait(DriverFactory.Instance, TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["DefaultImplicityWait"]))).Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (NoSuchElementException ex)
            {

                Reporter.InfoTestFail(ex.Message);
            }

        }

        public static void WaitElementToBeClickable(this By locator)
        {
            try
            {
                new WebDriverWait(DriverFactory.Instance, TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["DefaultImplicityWait"]))).Until(ExpectedConditions.ElementToBeClickable(locator));

            }
            catch (NoSuchElementException ex)
            {

                Reporter.InfoTestFail(ex.Message);
            }

        }

        public static void WaitElementSelected(this By locator)
        {
            try
            {
                new WebDriverWait(DriverFactory.Instance, TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["DefaultImplicityWait"]))).Until(ExpectedConditions.ElementToBeSelected(locator));

            }
            catch (NoSuchElementException ex)
            {

                Reporter.InfoTestFail(ex.Message);
            }

        }


        public static void WaitTextToBePresentInElement(this IWebElement element, string text)
        {
            try
            {
                new WebDriverWait(DriverFactory.Instance, TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["DefaultImplicityWait"]))).Until(ExpectedConditions.TextToBePresentInElementValue(element, text));
            }
            catch (NoSuchElementException ex)
            {

                Reporter.InfoTestFail(ex.Message);
            }

        }

        public static bool IsElementExists(IWebElement element)
        {
            bool elementExists;
            try
            {
                new WebDriverWait(DriverFactory.Instance, TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["DefaultImplicityWait"]))).Until(ExpectedConditions.ElementToBeClickable(element));
                elementExists = true;
            }
            catch (NoSuchElementException ex)
            {

                Console.WriteLine(ex.Message);
                elementExists = false;
            }
            return elementExists;
        }


        public static void DynamicWait(By locator, string par, string text)
        {
            WebDriverWait wait = new WebDriverWait(DriverFactory.Instance, TimeSpan.FromSeconds(30));
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));

            if (par == "waitSearchbox")
            {
                wait.Until(waitSearchbox(locator));
            }
            else if (par == "waitSearchbox")
            {
                wait.Until(waitForTitle(text));
            }

            else if (par == "waitForElement")
            {
                wait.Until(waitForElement(locator));
            }


        }

        public static void WaitForTextInElement(this IWebElement element, string text)
        {
            new WebDriverWait(DriverFactory.Instance, TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["DefaultImplicityWait"]))).Until(ExpectedConditions.TextToBePresentInElement(element, text));
        }

        public static void WaitForElementVisible(By locator)
        {
            new WebDriverWait(DriverFactory.Instance, TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["DefaultImplicityWait"]))).Until(ExpectedConditions.ElementIsVisible(locator));
        }


        private static Func<IWebDriver, bool> waitSearchbox(By locator)
        {
            return ((x) =>
            {
                return x.FindElements(locator).Count == 1;
            });
        }



        private static Func<IWebDriver, string> waitForTitle(string title)
        {
            return ((x) =>
            {
                if (x.Title.Contains(title))
                    return title;
                return null;

            });
        }

        private static Func<IWebDriver, IWebElement> waitForElement(By locator)
        {
            return ((x) =>
            {
                if (x.FindElements(locator).Count == 1)
                    return x.FindElement(locator);
                return null;

            });
        }

        public static bool IsElementPresent(By locator)
        {
            //Set the timeout to something low
            new WebDriverWait(DriverFactory.Instance, TimeSpan.FromSeconds(1));

            try
            {
                return DriverFactory.Instance.FindElement(locator).Displayed;
                //If element is found set the timeout back and return true
                //return true;
            }
            catch
            {
                //If element isn't found, set the timeout and return false
                return false;
            }
        }

    }
}
