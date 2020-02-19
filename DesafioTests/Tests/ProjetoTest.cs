using DesafioSelenium.Flows;
using DesafioSelenium.Pages;
using DesafioTests.BaseClasses;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioUtils.JavaScriptHelpres;
using DesafioSelenium.DataDriven;
using DesafioSelenium.Steps;
using DesafioUtils.Queries;
using System.Configuration;
using DesafioUtils.ExtentReport;

namespace DesafioTests.Tests
{
    public class ProjetoTest : TestBase
    {
        [PageObject]
        LoginStep loginStep;
        [PageObject]
        HomeStep homeStep;
        [PageObject]
        HomePage homePage;

        public string usuario = ConfigurationManager.AppSettings["usuarioMantis"];
        public string senha = ConfigurationManager.AppSettings["senhaMantis"];

        [Test]
        [Description ("Verifica se o projeto cadastrado pela massa de teste está disponível para seleção")]
        public void Test_verificaProjetoExistente()
        {
            string projetoExistente = "Teste";

            loginStep.fazLogin(usuario, senha);
            string projetoLocalizado = homePage.retornaProjetoMassa();

            Assert.IsTrue(projetoExistente == projetoLocalizado);

        }

        [Test]
        [Description("Verifica se o projeto cadastrado pela massa de teste está selecionado")]
        public void Test_verificaSelecaoProjetoExistente()
        {
            string projetoExistente = "Teste";

            loginStep.fazLogin(usuario, senha);
            string projetoLocalizado = homePage.retornaProjetoMassa();
            homePage.clicaProjetoMassa();

            Assert.IsTrue(projetoExistente == projetoLocalizado);

        }
    }
}
