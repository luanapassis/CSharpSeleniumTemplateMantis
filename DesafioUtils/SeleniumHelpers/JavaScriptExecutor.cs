using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using DesafioUtils.SeleniumUtilitarios;


namespace DesafioUtils.SeleniumHelpers
{
    class JavaScriptExecutor
    {
        public static void ExecuteJavaScript(string script)
        {
            IJavaScriptExecutor executor = ((IJavaScriptExecutor)DriverFactory.Instance);

            executor.ExecuteScript(script);
        }
    }
}
