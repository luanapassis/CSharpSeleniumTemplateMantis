﻿using DesafioSelenium.Flows;
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
    class Test_inicial : TestBase
    {
        [PageObject]
        Step_Inicial stepInicial;
        [PageObject]
        Step_home stepHome;

        [Test]
        [Description ("Realiza o login com suscesso")]
        public void Test_fazLoginSucesso()
        {            
            string usuario = "administrator";
            string senha = "administrator";
            stepInicial.fazLogin(usuario, senha);
            string usuLogado = stepHome.retornaUsuLogado();
            Assert.IsTrue(usuLogado == usuario, "Usuário não logado.");
        }

        [Test]
        [Description("Realiza o login com suscesso utilizando JavaScript")]
        public void Test_fazLoginUsandoJavaScriptSucesso()
        {
            string usuario = "administrator";
            string senha = "administrator";
            stepInicial.abrirPagina();
            JavaScriptExecutorHelper.ExecuteJavaScript("document.querySelector('#username').setRangeText('"+ usuario + "')");
            JavaScriptExecutorHelper.ExecuteJavaScript("document.querySelector('#login-form > fieldset > input.width-40.pull-right.btn.btn-success.btn-inverse.bigger-110').click()");
            JavaScriptExecutorHelper.ExecuteJavaScript("document.querySelector('#password').setRangeText('"+ senha + "')");
            JavaScriptExecutorHelper.ExecuteJavaScript("document.querySelector('#login-form > fieldset > input.width-40.pull-right.btn.btn-success.btn-inverse.bigger-110').click()");
            string usuLogado = stepHome.retornaUsuLogado();
            Assert.IsTrue(usuLogado == usuario, "Usuário não logado.");
        }

        [Test]
        [Ignore ("Data Driven com conection string não funciona no Jenkins =(")]
        public void Test_dataDrivenLoginSucesso_old()
        {
            string testCase = "LoginSucesso";
            stepInicial.fazLoginDataDriven(testCase);
        }

        [Test]
        [Description("Realiza o login com suscesso utilizando dataDriven com 4 registro.")]
        public void Test_dataDrivenLoginSucesso()
        {
            String fileName = ConfigurationManager.AppSettings["TestDataSheetPath2"];
            int rowNumber = 1;

            for (; rowNumber <= 4; rowNumber++)
            {
                string usuario = stepInicial.loginDataDriven2(rowNumber, fileName);
                string usuLogado = stepHome.retornaUsuLogado();
                Reporter.JustAddScreenshot();
                Assert.IsTrue(usuLogado == usuario.ToLower(), "Usuário não logado.");

            }
        }
        [Test]
        [Description ("Realizar o login com usuario e senha incorretos")]
        public void Test_fazLoginUsuarioSenhaIncorretos()
        {
            string usuario = "errado";
            string senha = "123456";
            string msg = "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.";
            
            stepInicial.fazLogin(usuario, senha);
            string msgErroLogin = stepInicial.retornaErroLogin();
            Assert.That(msg.Contains(msgErroLogin));
        }
        [Test]
        [Description("Realizar o login com senha incorreta")]
        public void Test_fazLoginSenhaIncorreta()
        {
            string usuario = "administrator";
            string senha = "123456";
            string msg = "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.";

            stepInicial.fazLogin(usuario, senha);
            string msgErroLogin = stepInicial.retornaErroLogin();
            Assert.That(msg.Contains(msgErroLogin));
        }

        
        [Test]
        public void Test_banco()
        {
            DataBaseSteps db = new DataBaseSteps();
            db.cargaTabelaUsuario();

        }
          

    }
}
