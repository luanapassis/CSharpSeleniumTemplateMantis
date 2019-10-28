using DesafioSelenium.Flows;
using DesafioSelenium.Pages;
using DesafioTests.BaseClasses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioUtils.JavaScriptHelpres;

namespace DesafioTests.Tests
{
    class Test_inicial : TestBase
    {
        [PageObject]
        Step_Inicial stepInicial;

        [Test]
        public void Test_fazLoginSucesso()
        {
            stepInicial.fazLogin("Administrator", "administrator");  
        }
        [Test]
        public void Test_fazLoginUsandoJavaScriptSucesso()
        {
            JavaScriptExecutorHelper.ExecuteJavaScript("document.querySelector('#username').setRangeText('Administrator')");
            JavaScriptExecutorHelper.ExecuteJavaScript("document.querySelector('#login-form > fieldset > input.width-40.pull-right.btn.btn-success.btn-inverse.bigger-110').click()");
            JavaScriptExecutorHelper.ExecuteJavaScript("document.querySelector('#password').setRangeText('administrator')");
            JavaScriptExecutorHelper.ExecuteJavaScript("document.querySelector('#login-form > fieldset > input.width-40.pull-right.btn.btn-success.btn-inverse.bigger-110').click()");
        }
    }
}
