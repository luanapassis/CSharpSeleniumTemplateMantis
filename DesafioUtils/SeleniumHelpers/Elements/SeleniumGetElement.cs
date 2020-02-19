using DesafioUtils.ExtentReport;
using DesafioUtils.ProjectsUtilitarios;
using DesafioUtils.SeleniumUtilitarios;
using NUnit.Framework;
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
    public static class SeleniumGetElement
    {
        //public static bool GetElement(IWebElement element)
        //{
        //    bool elementExists;
        //    try
        //    {
        //        DynamicWaitHelper.WaitElementToBeClickable(element);

        //        return true;
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        Reporter.FailTest(Utilitarios.GetCurrentMethod() + " => " + "ERRO! Elemento não encontrado: " + "<pre>" + ex.Message + "</pre>");
        //        Console.WriteLine(ex.Message);
        //        Assert.IsTrue(false);
        //        elementExists = false;
        //    }
        //    return elementExists;

        //}

        //public static bool GetTextToElement(IWebElement element, string text)
        //{
        //    bool elementExists;
        //    try
        //    {
        //        //DynamicWaitHelper.WaitTextToBePresentInElement(element,text);
        //        new WebDriverWait(DriverFactory.Instance, TimeSpan.FromSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["DefaultImplicityWait"]))).Until(ExpectedConditions.TextToBePresentInElement(element, text));
        //        //if (element.Displayed || element.Enabled)
        //        //{
        //        //    elementExists = true;
        //        //}
        //        return true;
        //    }
        //    catch (NoSuchElementException ex)
        //    {
        //        Reporter.FailTest(Utilitarios.GetCurrentMethod() + " => " + "ERRO! Elemento não encontrado: " + "<pre>" + ex.Message + "</pre>");
        //        Console.WriteLine(ex.Message);
        //        Assert.IsTrue(false);
        //        elementExists = false;
        //    }
        //    return elementExists;

        //}

        //public static String GetElementAttibutte(IWebElement element)
        //{
        //    String elementAttribute = String.Empty;
        //    try
        //    {
        //        if (element.GetAttribute("id") != null)
        //        {
        //            elementAttribute = element.GetAttribute("id");
        //        }
        //        else if (element.GetAttribute("name") != null)
        //        {
        //            elementAttribute = element.GetAttribute("name");
        //        }
        //        else if (element.Text != null)
        //        {
        //            elementAttribute = element.Text;
        //        }

        //        return elementAttribute;

        //    }
        //    catch
        //    {

        //        return elementAttribute;
        //    }
        //}

    }
}
