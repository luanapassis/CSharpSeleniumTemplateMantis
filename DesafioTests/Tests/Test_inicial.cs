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
using DesafioSelenium.DataDriven;
using DesafioSelenium.Steps;

namespace DesafioTests.Tests
{
    class Test_inicial : TestBase
    {
        [PageObject]
        Step_Inicial stepInicial;
        [PageObject]
        Step_home stepHome;

        [Test]
        public void Test_fazLoginSucesso()
        {
            string usuario = "administrator";
            string senha = "administrator";
            stepInicial.fazLogin(usuario, senha);
            string usuLogado = stepHome.retornaUsuLogado();
            Assert.IsTrue(usuLogado == usuario, "Usuário não logado.");
        }
        [Test]
        public void Test_fazLoginUsandoJavaScriptSucesso()
        {
            string usuario = "administrator";
            string senha = "administrator";
            JavaScriptExecutorHelper.ExecuteJavaScript("document.querySelector('#username').setRangeText('"+ usuario + "')");
            JavaScriptExecutorHelper.ExecuteJavaScript("document.querySelector('#login-form > fieldset > input.width-40.pull-right.btn.btn-success.btn-inverse.bigger-110').click()");
            JavaScriptExecutorHelper.ExecuteJavaScript("document.querySelector('#password').setRangeText('"+ senha + "')");
            JavaScriptExecutorHelper.ExecuteJavaScript("document.querySelector('#login-form > fieldset > input.width-40.pull-right.btn.btn-success.btn-inverse.bigger-110').click()");
            string usuLogado = stepHome.retornaUsuLogado();
            Assert.IsTrue(usuLogado == usuario, "Usuário não logado.");
        }
        [Test]
        public void Test_testeDataDrivenSucesso()
        {
            string testCase = "LoginSucesso";            
            stepInicial.fazLoginDataDriven(testCase);
        }
    }
}
