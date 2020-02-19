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
using DesafioUtils.ProjectsUtilitarios;

namespace DesafioTests.PreTests
{
    public class PreTestMethods: TestBase
    {
        [PageObject]
        LoginStep loginStep;
        [PageObject]
        TarefasPage tarefasPage;
        //LoginStep loginStep = new LoginStep();
        //TarefasPage tarefasPage = new TarefasPage();

        public string PreTestCriarTarefa(string nomeProjeto, string nomeCategoria, string nomeResumo, string txtDescricao)
        {
            DataBaseSteps db = new DataBaseSteps();


            string projeto = nomeProjeto;
            string categoria = nomeCategoria;
            string resumo = nomeResumo;
            string descricao = txtDescricao;

            tarefasPage.abrirMenuGerenciarUsuario();
            tarefasPage.selecionaProjeto(projeto);
            tarefasPage.clicarBtnSelecionarProjeto();
            tarefasPage.selecinaComboCategoria(categoria);
            tarefasPage.preencheCampoResumo(resumo);
            tarefasPage.preencheCampoDescricao(descricao);
            tarefasPage.clicaBtnCriarNovaTarefa();
            string bugIdTela = tarefasPage.retornaBugIdDaTela();
            int bugIdInt = Convert.ToInt32(bugIdTela);

            List<string> tarefaBD = db.retornaTarefaCriadaPorId(Convert.ToString(bugIdInt));

            Assert.IsTrue(tarefaBD[21] == resumo, "Tarefa não foi criada no Pre-Teste");
            return bugIdTela;
        }
    }
}

