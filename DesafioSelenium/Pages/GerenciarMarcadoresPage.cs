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
    public class GerenciarMarcadoresPage : PageBase
    {
        By menuGerenciar = By.XPath("//a[@href= '/mantis/manage_overview_page.php']");
        By menuMarcador = By.XPath("//a[@href= '/mantis/manage_tags_page.php']");
        By gridMarcadorTeste = By.XPath("//a[text()='marcadorTeste']");
        By gridMarcadorTeste2 = By.XPath("//a[text()='marcadorTeste2']");
        By btnAtualizarMarcador = By.XPath("//input[@value='Atualizar Marcador']");
        By campoNomeMarcador = By.Id("tag-name");
        By comboUsuMarcador = By.Id("tag-user-id");
        By campoDescricaoMarcador = By.Id("tag-description");
        By btnCriarMarcador = By.XPath("//a[text()='Criar Marcador']");
        By btnConfirmaCriarMarcador = By.Name("config_set");
        By msgErro = By.XPath("//p[contains(text(),'APPLICATION ERROR')]");

        public void abrirMenuGerenciarMarcadores()
        {
            Click(menuGerenciar);
            Click(menuMarcador);
        }

        public void selecionaMarcadorTeste()
        {
            Click(gridMarcadorTeste);
        }
        public void selecionaMarcadorTeste2()
        {
            Click(gridMarcadorTeste2);
        }
        public void clicaAtualizarMarcador()
        {
            Click(btnAtualizarMarcador);
        }
        public void preencheNomeMarcador(string texto)
        {
            ClearAndSendKeys(campoNomeMarcador, texto);
        }
        public void preencheUsuarioMarcador(string usuario)
        {
            ComboBoxSelectByVisibleText(comboUsuMarcador, usuario);
        }
        public void preencheDescricaoMarcador(string texto)
        {
            ClearAndSendKeys(campoDescricaoMarcador, texto);
        }
        public bool retornaMsgErro()
        {
            return ReturnIfElementIsDisplayed(msgErro);
        }
        public void clicaBtnCriarMarcador()
        {
            Click(btnCriarMarcador);
        }
        public void clicaBtnConfirmarCriacaoMarcador()
        {
            Click(btnConfirmaCriarMarcador);
        }
    }
}
