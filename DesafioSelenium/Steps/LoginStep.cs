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
       
    }
}
