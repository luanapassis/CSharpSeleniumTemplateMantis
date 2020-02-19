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
    public class TarefasPage : PageBase
    {
        By menuCriarTarefa = By.XPath("//a[@href= '/mantis/bug_report_page.php']");
        By comboProjeto = By.Id("select-project-id");
        By btnSelecionarProjeto = By.XPath("//input[@value = 'Selecionar Projeto']");
        By comboCategoria = By.Id("category_id");
        By campoResumo = By.Id("summary");
        By campoDescricao = By.Id("description");
        By btnCriarNovaTarefa = By.XPath("//input[@value = 'Criar Nova Tarefa']");
        By campoBugId = By.XPath("//td[@class = 'bug-id']");
        

        public void abrirMenuGerenciarUsuario()
        {
            Click(menuCriarTarefa);
        }

        public void selecionaProjeto(string projeto)
        {
            ComboBoxSelectByVisibleText(comboProjeto, projeto);
        }
        public void clicarBtnSelecionarProjeto()
        {
            Click(btnSelecionarProjeto);
        }
        public void selecinaComboCategoria(string categoria)
        {
            ComboBoxSelectByVisibleText(comboCategoria, categoria);
        }
        public void preencheCampoResumo(string resumo)
        {
            ClearAndSendKeys(campoResumo, resumo);
        }
        public void preencheCampoDescricao(string descricao)
        {
            ClearAndSendKeys(campoDescricao, descricao);
        }
        public void clicaBtnCriarNovaTarefa()
        {
            Click(btnCriarNovaTarefa);
        }
        public string retornaBugIdDaTela()
        {
            return GetText(campoBugId);
        }

    }
}
