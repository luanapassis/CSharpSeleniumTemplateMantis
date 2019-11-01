﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioSelenium.Pages;

namespace DesafioSelenium.Flows
{
    public class Step_Inicial
    {
        Page_Inicial pageInicial;
        public Step_Inicial()
        {
            pageInicial = new Page_Inicial();
        }

        public void fazLogin(string usuario, string senha)
        {
            pageInicial.preencheUsuario(usuario);
            pageInicial.clicaBtnEntra();
            pageInicial.preencheSenha(senha);
            pageInicial.clicaBtnEntra2();

        }
        public void fazLoginDataDriven(string testName)
        {
            pageInicial.preencheUsuarioDataDriven(testName);
            pageInicial.clicaBtnEntra();
            pageInicial.preencheSenhaDataDriven(testName);
            pageInicial.clicaBtnEntra2();
        }
        public string retornaUsuarioDataDriven(string testName)
        {
            return pageInicial.retornaUsuarioDataDriven(testName);
        }
    }
}
