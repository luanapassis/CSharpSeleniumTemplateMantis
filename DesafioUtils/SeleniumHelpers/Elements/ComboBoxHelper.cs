using DesafioUtils.ExtentReport;
using DesafioUtils.ProjectsUtilitarios;
using DesafioUtils.SeleniumUtilitarios;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioUtils.SeleniumHelpers.Elements
{
    public static class ComboBoxHelper
    {

        //private static SelectElement select;

        //public static void SelectElement(this IWebElement element, int index)
        //{
        //    select = new SelectElement(element);
        //    select.SelectByIndex(index);

        //}

        //public static IList<string> GetAllItem(IWebElement element)
        //{
        //    select = new SelectElement(element);
        //    return select.Options.Select((x) => x.Text).ToList();

        //}

        //public static void SelectElement(this IWebElement element, string visibleText)
        //{
        //    //DynamicWaitHelper.WaitForTextInElement(element, visibleText);
        //    if (visibleText != string.Empty)
        //    {
        //        new WebDriverWait(DriverFactory.Instance, TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["DefaultImplicityWait"]))).Until(ExpectedConditions.TextToBePresentInElement(element, visibleText));

        //        select = new SelectElement(element);
        //        select.SelectByText(visibleText);
        //        Reporter.InfoTest(Utilitarios.GetCurrentMethod() + " => " + "Valor selecionado: " + visibleText);
        //    }


        //}
    }
}
