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
using DesafioUtils.DataBaseHelpres;
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
        public void Test_testeDataDrivenLoginSucesso()
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
        [Description ("")]
        public void Test_fazLoginInsucesso()
        {
            string usuario = "errado";
            string senha = "123456";

            stepInicial.abrirPagina();
            stepInicial.fazLogin(usuario, senha);
            string msgErroLogin = stepInicial.retornaErroLogin();
            //fazer assert
        }

        /*
        [Test]
        public void Test_banco()
        {
            /*
            DataBaseInteractions db = new DataBaseInteractions();
            db.DBRunQuery("SELECT * from mantis_user_table WHERE id = 1");

            INSERT INTO mantis_user_table ( username, realname, email, PASSWORD, enabled, protected, access_level, login_count, lost_password_request_count, failed_login_count, cookie_string, last_visit, date_created)
            VALUES('usuario2', 'Teste','luana.assis2@gmail.com.br', 'e10adc3949ba59abbe56e057f20f883e', 1, 0, 90, 1, 0, 0, 'JCIfQbZ9Wdq0eONcOMkSOR17wMSjowjc6L', 1574199190, 1574199190)
         }
          */

    }
}
