using DesafioUtils.SeleniumHelpers;
using DesafioUtils.SeleniumHelpers.ElementsHelpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSelenium.Pages
{
    public class GerenciarProjetoPage : PageBase
    {
        By menuGerenciar = By.XPath("//a[@href= '/mantis/manage_overview_page.php']");
        By menuProjeto = By.XPath("//a[@href= '/mantis/manage_proj_page.php']");
        By gridProjeto = By.XPath("//a[contains(@href,'manage_proj_edit_page.php') and text()='Teste']");
        By comboEstado = By.Id("project-status");
        By btnAtualizarProjeto = By.XPath("//input[@value='Atualizar Projeto']");
        By btnCriarNovoProjeto = By.XPath("//button[text()='Criar Novo Projeto']");
        By campoNomeProjeto = By.Id("project-name");
        By comboVisibiliade = By.Id("project-view-state");
        By campoDescricao = By.Id("project-description");
        By btnAdicionarProjeto = By.XPath("//input[@type='submit']");
        By comboSubProjeto = By.Name("subproject_id");
        By btnAdicionarSubProjeto = By.XPath("//input[@value='Adicionar como Subprojeto']");
        By checkEnabled = By.XPath("//label/span[@class='lbl']");
        By msgErro = By.XPath("//p[contains(text(),'APPLICATION ERROR')]");
        
        public void abrirMenuGerenciarProjeto()
        {
            Click(menuGerenciar);
            Click(menuProjeto);
        }

        public void abrirGridProjeto()
        {
            Click(gridProjeto);
        }
        public void selecaoComboEstado(string estado)
        {
            ComboBoxSelectByVisibleText(comboEstado, estado);
        }
        public void clicaBtnAtualizarProjeto()
        {
            Click(btnAtualizarProjeto);
        }
        public void clicarBtnNovoProjeto()
        {
            Click(btnCriarNovoProjeto);
        }
        public void preencheNomeProjeto(string nome)
        {
            ClearAndSendKeys(campoNomeProjeto, nome);
        }
        public void selecionarVisibilidade(string visibilidade)
        {
            ComboBoxSelectByVisibleText(comboVisibiliade, visibilidade);
        }
        public void preencheDescricaoProjeto(string descricao)
        {
            ClearAndSendKeys(campoDescricao, descricao);
        }
        public void clicarAdicionarProjeto()
        {
            Click(btnAdicionarProjeto);
        }
        public void selecionaSubProjeto(string subProjeto)
        {
            ComboBoxSelectByVisibleText(comboSubProjeto, subProjeto);
        }
        public void adicionarSubProjeto()
        {
            Click(btnAdicionarSubProjeto);
        }
        public void desabilitaProjeto()
        {
            Click(checkEnabled);
        }
        public bool retornaMsgErro()
        {
            return ReturnIfElementIsDisplayed(msgErro);
        }
    }
}
