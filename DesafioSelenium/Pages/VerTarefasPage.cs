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
    public class VerTarefasPage : PageBase
    {
        By menuVerTarefas = By.XPath("//a[@href= '/mantis/view_all_bug_page.php']");
        By campoFiltroTarefas = By.Id("filter-search-txt");
        By btnFiltrarTarefas = By.XPath("//input[@value='Aplicar Filtro']");
        By gridTarefaId = By.XPath("//td[@class= 'column-id']/a");
        By campoTag = By.Id("tag_string");
        By btnAplicarTag = By.XPath("//input[@value='Aplicar']");
        By btnRemoverTag = By.XPath("//a[contains(@href,'tag_detach')]");
        By campoRelacaoTarefa = By.Name("dest_bug_id");
        By btnAddRelacao = By.Name("add_relationship");
        By btnAtualizarTarefa = By.XPath("//input[@value='Atualizar']");
        By comboTipoRelacao = By.Name("rel_type");
        By comboAtribuicao = By.Name("handler_id");
        By btnConfirmarAtualizacaoTarefa = By.XPath("//input[@value='Atualizar Informação']");
        By comboResolucao = By.Id("resolution");
        By comboStatus = By.Name("status");
        By comboPrioridade = By.Id("priority");
        By msgErro = By.XPath("//p[contains(text(),'APPLICATION ERROR')]");


        public void abrirMenuVerTarefas()
        {
            Click(menuVerTarefas);
        }
        public void preencheFiltroTarefa(string codigoTarefa)
        {
            ClearAndSendKeys(campoFiltroTarefas, codigoTarefa);
        }
        public void clicarFiltrarTarefa()
        {
            Click(btnFiltrarTarefas);
        }
        public string retornaIdGridTarefa()
        {
            return GetText(gridTarefaId);
        }
        public void preencheTag(string tag)
        {
            SendKeys(campoTag, tag);
        }
        public void clicaAplicarTag()
        {
            Click(btnAplicarTag);
        }
        public void clicaBtnRemoverTag()
        {
            Click(btnRemoverTag);
        }
        public void preencheRelacaoTarefa(string relacao)
        {
            SendKeys(campoRelacaoTarefa, relacao);
        }
        public void clicaBtnAddRelacao()
        {
            Click(btnAddRelacao);
        }
        public bool retornaMsgErro()
        {
            return ReturnIfElementIsDisplayed(msgErro);
        }
        public void selecionaComboTipoRelacao(string tipoRelacao)
        {
            ComboBoxSelectByVisibleText(comboTipoRelacao, tipoRelacao);
        }
        public void clicaBtnAtualizarTarefa()
        {
            Click(btnAtualizarTarefa);
        }
        public void selecinaComboAtribuicao(string usuario)
        {
            ComboBoxSelectByVisibleText(comboAtribuicao, usuario);
        }
        public void clicaBntConfirmaAtualizacaoTarefa()
        {
            Click(btnConfirmarAtualizacaoTarefa);
        }
        public void selecionaComboResolucao(string resolucao)
        {
            ComboBoxSelectByVisibleText(comboResolucao, resolucao);
        }
        public void selecionaStatusTarefa(string status)
        {
            ComboBoxSelectByVisibleText(comboStatus, status);
        }
        public void selecinaComboPrioridade(string prioridade)
        {
            ComboBoxSelectByVisibleText(comboPrioridade, prioridade);
        }
    }
}
