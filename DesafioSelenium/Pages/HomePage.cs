using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using DesafioUtils.SeleniumUtilitarios;
using DesafioUtils.SeleniumHelpers;
using DesafioUtils.SeleniumHelpers.ElementsHelpers;

namespace DesafioSelenium.Pages
{
    public class HomePage : PageBase
    {
        By usuLogado = (By.XPath("//span[@class = 'user-info']"));
        By menuProjeto = (By.XPath("//a[@data-toggle= 'dropdown']"));
        By projetoMassa = (By.XPath("//a[text()=' Teste ']"));
        By campoPesquisaTarefa = (By.Name("bug_id"));



        public string retornaUsuLogado()
        {
           return GetText(usuLogado);
        }
        public string retornaProjetoMassa()
        {
            Click(menuProjeto);
            string retorno = GetText(projetoMassa);
            Click(menuProjeto);
            return retorno;
        }
        public void clicaProjetoMassa()
        {
            Click(menuProjeto);
            Click(projetoMassa);
        }
        public void preenchePesquisaTarefa(string tarefaId)
        {
            SendKeys(campoPesquisaTarefa, tarefaId);
            SendKeys(campoPesquisaTarefa, Keys.Enter);
        }
    }
}
