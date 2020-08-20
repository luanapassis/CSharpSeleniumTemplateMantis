using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using DesafioUtils.SeleniumUtilitarios;
using DesafioUtils.SeleniumHelpers;
using DesafioUtils.SeleniumHelpers.Elements;
using DesafioUtils.JavaScriptHelpres;
using DesafioSelenium.DataDriven;
using System.Configuration;
using DesafioUtils.ButtonHelpers;
using DesafioUtils.SeleniumHelpers.ElementsHelpers;

namespace DesafioSelenium.Pages
{
    public class LoginPage : PageBase
    {
        By campoUsuario = (By.Id("username"));
        By btnEntrar =(By.XPath("//input[@value= 'Entrar']"));
        By campoSenha =(By.Id("password"));
        //By btnEntrar2 =(By.XPath("/html/body/div[1]/div/div/div/div/div[4]/div/div/div/form/fieldset/input[3]"));
        By msgErroLogin =(By.XPath("/html/body/div[1]/div/div/div/div/div[4]/p"));


        public void abrirPagina()
        {
            DriverFactory.Instance.Manage().Cookies.DeleteAllCookies();
            NavigationHelper.NavigateToUrl(DriverFactory.BaseUrl);           
        }

        public void preencheUsuario(string usuario)
        {
            SendKeys(campoUsuario, usuario);
        }
        public void clicaBtnEntra()
        {
            Click(btnEntrar);
        }
        public void preencheSenha(string senha)
        {
            SendKeys(campoSenha, senha);
        }

        #region lendo de planilha excel modelo 1
        public void preencheUsuarioDataDriven(string testName)
        {
            var userData = ExcelDataAccess.GetTestData(testName);
            SendKeys(campoUsuario, userData.Username);
        }
        public void preencheSenhaDataDriven(string testName)
        {
            var userData = ExcelDataAccess.GetTestData(testName);
            SendKeys(campoSenha, userData.Password);
        }
        public string retornaUsuarioDataDriven(string testName)
        {
            var userData = ExcelDataAccess.GetTestData(testName);
            return (userData.Username);
        }
        #endregion

        #region lendo de planilha execel modelo 2
        public string loginDataDriven2(int linha, string fileName)
        {
           
            ExcelUtil util = new ExcelUtil();

            util.PopulateInCollection(fileName);

            String userName = util.ReadData(linha, "Column0");//Login
            String password = util.ReadData(linha, "Column1");//senha 01

            SendKeys(campoUsuario, userName);
            clicaBtnEntra();
            SendKeys(campoSenha, password);
            clicaBtnEntra();

            return userName;
        }
        public string retornaMsgErroLogin()
        {
            return GetText(msgErroLogin);
        }
        #endregion


    }


}



