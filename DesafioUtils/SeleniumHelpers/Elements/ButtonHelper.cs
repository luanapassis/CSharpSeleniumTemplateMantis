using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DesafioUtils.SeleniumHelpers;
using DesafioUtils.ExtentReport;
using OpenQA.Selenium;
using DesafioUtils.ProjectsUtilitarios;

namespace DesafioUtils.ButtonHelpers
{
    public static class ButtonHelper
    {
        public static void ClickButton(this IWebElement element)
        {


            try
            {
                if (DynamicWaitHelper.IsElementExists(element))
                {
                    Reporter.InfoTest(Utilitarios.GetCurrentMethod() + " => " + "Elemento encontrado: " + SeleniumGetElement.GetElementAttibutte(element));
                    element.Click();
                }


            }
            catch (NoSuchElementException ex)
            {
                Reporter.InfoTest(Utilitarios.GetCurrentMethod() + " => " + "Elemento encontrado. " + "<pre>" + ex.Message + "<pre>");
            }

        }

        public static bool IsButtonEnabled(IWebElement element)
        {
            SeleniumGetElement.GetElement(element);
            return element.Enabled;
        }

        public static string GetButtonText(IWebElement element)
        {
            SeleniumGetElement.GetElement(element);

            if (element.GetAttribute("value") == null)
                return string.Empty;
            return element.GetAttribute("value");
        }
    }
}
