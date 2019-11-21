using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioSelenium.Pages;
using DesafioUtils.ExtentReport;

namespace DesafioSelenium.Flows
{
    public class Step_Inicial
    {
        Page_Inicial pageInicial;
        public Step_Inicial()
        {
            pageInicial = new Page_Inicial();
        }

        public void abrirPagina()
        {
            pageInicial.abrirPagina();
        }

        public void fazLogin(string usuario, string senha)
        {
            this.abrirPagina();
            pageInicial.preencheUsuario(usuario);
            pageInicial.clicaBtnEntra();
            pageInicial.preencheSenha(senha);
            pageInicial.clicaBtnEntra2();

        }
        public void fazLoginDataDriven(string testName)
        {
            this.abrirPagina();
            pageInicial.preencheUsuarioDataDriven(testName);
            pageInicial.clicaBtnEntra();
            pageInicial.preencheSenhaDataDriven(testName);
            pageInicial.clicaBtnEntra2();
        }
        public string retornaUsuarioDataDriven(string testName)
        {
            return pageInicial.retornaUsuarioDataDriven(testName);
        }

        public string loginDataDriven2(int linha, string fileName)
        {
            this.abrirPagina();
            string userNameUtilizado = pageInicial.loginDataDriven2(linha, fileName);
            return userNameUtilizado;
            
        }
        public string retornaErroLogin()
        {
            return pageInicial.retornaMsgErroLogin();
        }
    }
}
