using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioSelenium.Pages;
using DesafioUtils.ExtentReport;

namespace DesafioSelenium.Flows
{
    public class LoginStep
    {
        LoginPage loginPage;
        public LoginStep()
        {
            loginPage = new LoginPage();
        }

        public void abrirPagina()
        {
            loginPage.abrirPagina();
        }

        public void fazLogin(string usuario, string senha)
        {
            this.abrirPagina();
            loginPage.preencheUsuario(usuario);
            loginPage.clicaBtnEntra();
            loginPage.preencheSenha(senha);
            loginPage.clicaBtnEntra();

        }
        public void fazLoginDataDriven(string testName)
        {
            this.abrirPagina();
            loginPage.preencheUsuarioDataDriven(testName);
            loginPage.clicaBtnEntra();
            loginPage.preencheSenhaDataDriven(testName);
            loginPage.clicaBtnEntra();
        }
        public string retornaUsuarioDataDriven(string testName)
        {
            return loginPage.retornaUsuarioDataDriven(testName);
        }

        public string loginDataDriven2(int linha, string fileName)
        {
            this.abrirPagina();
            string userNameUtilizado = loginPage.loginDataDriven2(linha, fileName);
            return userNameUtilizado;
            
        }
        public string retornaErroLogin()
        {
            return loginPage.retornaMsgErroLogin();
        }
    }
}
