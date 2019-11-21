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
    public static class TextBoxHelper
    {
        private static IWebElement element;

        public static void TypeInTextBox(this IWebElement element, string text)
        {

            if (text != string.Empty)
            {
                SeleniumGetElement.GetElement(element);
                element.Clear();
                element.SendKeys(text);
            }


            Reporter.InfoTest(Utilitarios.GetCurrentMethod() + " => " + "Elemento encontrado: " + SeleniumGetElement.GetElementAttibutte(element) + " - Valor preenchido: " + text);
        }

        public static void ClearTextBox(this IWebElement element)
        {
            //SeleniumGetElement.GetElement(element);
            element.Clear();

            Reporter.InfoTest(Utilitarios.GetCurrentMethod() + " => " + "Valor do campo apagado: " + SeleniumGetElement.GetElementAttibutte(element));
        }

        public static void TypeInTextBoxWithMask(this IWebElement element, string text)
        {


            if (text != string.Empty)
            {
                SeleniumGetElement.GetElement(element);
                int aux = 0;
                text = text.Trim();
                while (element.GetAttribute("value") != text)
                {
                    element.Clear();
                    element.SendKeys(text);
                    element.SendKeys(Keys.Tab);
                    aux++;

                    if (aux > 5)
                    {
                        break;
                    }
                }
            }

            Reporter.InfoTest(Utilitarios.GetCurrentMethod() + " => " + "Elemento encontrado: " + SeleniumGetElement.GetElementAttibutte(element) + " - Valor preenchido: " + text);
        }
    }
}
