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
using DesafioUtils.Queries;
using System.Configuration;
using DesafioUtils.ExtentReport;

namespace DesafioTests.Tests
{
    class LoginTest : TestBase
    {
        [PageObject]
        LoginPage loginPage;
        [PageObject]
        HomeStep homeStep;

        [Test]
        [Description ("Realiza o login com suscesso")]
        public void Test_fazLoginSucesso()
        {            
            string usuario = "luana.assis";
            string senha = "123456";

            loginPage.abrirPagina();
            loginPage.preencheUsuario(usuario);
            loginPage.clicaBtnEntra();
            loginPage.preencheSenha(senha);
            loginPage.clicaBtnEntra();

            string usuLogado = homeStep.retornaUsuLogado();

            Assert.IsTrue(usuLogado == usuario, "Usuário não logado.");
        }

        [Test]
        [Description("Realiza o login com suscesso utilizando JavaScript")]
        public void Test_fazLoginUsandoJavaScriptSucesso()
        {
            string usuario = "luana.assis";
            string senha = "123456";

            loginPage.abrirPagina();
            JavaScriptExecutorHelper.ExecuteJavaScript("document.querySelector('#username').setRangeText('"+ usuario + "')");
            JavaScriptExecutorHelper.ExecuteJavaScript("document.querySelector('#login-form > fieldset > input.width-40.pull-right.btn.btn-success.btn-inverse.bigger-110').click()");
            JavaScriptExecutorHelper.ExecuteJavaScript("document.querySelector('#password').setRangeText('"+ senha + "')");
            JavaScriptExecutorHelper.ExecuteJavaScript("document.querySelector('#login-form > fieldset > input.width-40.pull-right.btn.btn-success.btn-inverse.bigger-110').click()");
            string usuLogado = homeStep.retornaUsuLogado();
            Assert.IsTrue(usuLogado == usuario, "Usuário não logado.");
        }
        
        [TestCaseSource(typeof(LoginSucessoDataDriven), "LoginSucessoTestCases")]
        public void Test_dataDrivenLoginSucesso(string usuario, string senha)
        {
            loginPage.abrirPagina();
            loginPage.preencheUsuario(usuario);
            loginPage.clicaBtnEntra();
            loginPage.preencheSenha(senha);
            loginPage.clicaBtnEntra();

            string usuLogado = homeStep.retornaUsuLogado();
            Assert.IsTrue(usuLogado == usuario, "Usuário não logado.");
        }

        [Test]
        [Description ("Realizar o login com usuario e senha incorretos")]
        public void Test_fazLoginUsuarioSenhaIncorretos()
        {
            string usuario = "errado";
            string senha = "123456";
            string msg = "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.";

            loginPage.abrirPagina();
            loginPage.preencheUsuario(usuario);
            loginPage.clicaBtnEntra();
            loginPage.preencheSenha(senha);
            loginPage.clicaBtnEntra();

            string msgErroLogin = loginPage.retornaMsgErroLogin();

            Assert.That(msg.Contains(msgErroLogin));
        }
        [Test]
        [Description("Realizar o login com senha incorreta")]
        public void Test_fazLoginSenhaIncorreta()
        {
            string usuario = "luana.assis";
            string senha = "1234567";
            string msg = "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.";

            loginPage.abrirPagina();
            loginPage.preencheUsuario(usuario);
            loginPage.clicaBtnEntra();
            loginPage.preencheSenha(senha);
            loginPage.clicaBtnEntra();

            string msgErroLogin = loginPage.retornaMsgErroLogin();
            Assert.That(msg.Contains(msgErroLogin));
        }

        [Test]
        public void Test_fazLoginUsuarioDesativado()
        {
            string usuario = "usu.inativo";
            string senha = "123456";
            string msg = "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.";

            loginPage.abrirPagina();
            loginPage.preencheUsuario(usuario);
            loginPage.clicaBtnEntra();
            loginPage.preencheSenha(senha);
            loginPage.clicaBtnEntra();

            string msgErroLogin = loginPage.retornaMsgErroLogin();
            Assert.That(msg.Contains(msgErroLogin));
        }

    }
}
