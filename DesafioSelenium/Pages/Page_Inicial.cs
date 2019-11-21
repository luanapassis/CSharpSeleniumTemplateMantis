using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using DesafioUtils.SeleniumUtilitarios;
using DesafioUtils.SeleniumHelpers;
using DesafioUtils.JavaScriptHelpres;
using DesafioSelenium.DataDriven;
using System.Configuration;

namespace DesafioSelenium.Pages
{
    public class Page_Inicial
    {
        WebDriverWait wait = null;
        IWebDriver driver = null;

        public Page_Inicial()
        {
            //PageFactory.InitElements(DriverFactory.Instance, this);
            //teste wait = new WebDriverWait(DriverFactory.Instance, new TimeSpan(0, 0, 5));
            //teste driver = DriverFactory.Instance;
        }

        public IWebElement campoUsuario => DriverFactory.Instance.FindElement(By.Id("username"));

        public IWebElement btnEntrar => DriverFactory.Instance.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[4]/div/div/div[1]/form/fieldset/input[2]"));

        public IWebElement campoSenha => DriverFactory.Instance.FindElement(By.Id("password"));
        public IWebElement btnEntrar2 => DriverFactory.Instance.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[4]/div/div/div/form/fieldset/input[3]"));
        public IWebElement msgErroLogin => DriverFactory.Instance.FindElement(By.XPath("/html/body/div[1]/div/div/div/div/div[4]/p"));


        public void abrirPagina()
        {
            DriverFactory.Instance.Manage().Cookies.DeleteAllCookies();
            NavigationHelper.NavigateToUrl(DriverFactory.BaseUrl);           
        }

        public void preencheUsuario(string usuario)
        {            
            campoUsuario.SendKeys(usuario);
        }
        public void clicaBtnEntra()
        {
            btnEntrar.Click();          
        }
        public void preencheSenha(string senha)
        {
            campoSenha.SendKeys(senha);
        }
        public void clicaBtnEntra2()
        {
            btnEntrar2.Click();
        }
        #region dataDriven modelo 1
        public void preencheUsuarioDataDriven(string testName)
        {
            var userData = ExcelDataAccess.GetTestData(testName);
            campoUsuario.SendKeys(userData.Username);
        }
        public void preencheSenhaDataDriven(string testName)
        {
            var userData = ExcelDataAccess.GetTestData(testName);
            campoSenha.SendKeys(userData.Password);
        }
        public string retornaUsuarioDataDriven(string testName)
        {
            var userData = ExcelDataAccess.GetTestData(testName);
            return (userData.Username);
        }
        #endregion

        #region dataDriven modelo 2
        public string loginDataDriven2(int linha, string fileName)
        {
           
            ExcelUtil util = new ExcelUtil();

            util.PopulateInCollection(fileName);

            String userName = util.ReadData(linha, "Column0");//Login
            String password = util.ReadData(linha, "Column1");//senha 01

            campoUsuario.SendKeys(userName);
            clicaBtnEntra();
            campoSenha.SendKeys(password);
            clicaBtnEntra2();

            return userName;
        }    
        public string retornaMsgErroLogin()
        {
            return msgErroLogin.Text;
        }

        #endregion


    }


}



