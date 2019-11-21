using DesafioUtils.ExtentReport;
using DesafioUtils.ProjectsUtilitarios;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioUtils.SeleniumHelpers.Elements
{
    public static class CheckBoxHelper
    {
        private static IWebElement element;

        public static void CheckedCheckBox(this IWebElement element)
        {
            //SeleniumGetElement.GetElement(element);
            Reporter.InfoTest(Utilitarios.GetCurrentMethod() + " => " + "Elemento encontrado: " + SeleniumGetElement.GetElementAttibutte(element));

            while (!element.Selected)
            {
                element.Click();
            }

        }

        public static bool IsCheckBoxChecked(this IWebElement element)
        {
            SeleniumGetElement.GetElement(element);
            string flag = element.GetAttribute("checked");

            if (flag == null)
                return false;
            else
                return flag.Equals("true") || flag.Equals("checked");
        }
    }
}
