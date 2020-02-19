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
using DesafioTests.PreTests;

namespace DesafioTests.Tests
{
    public class TarefasTest : TestBase
    {
        [PageObject]
        LoginStep loginStep;
        [PageObject]
        HomePage homePage;
        [PageObject]
        TarefasPage tarefasPage;
        [PageObject]
        MinhaVisaoPage minhaVisaoPage;
        [PageObject]
        VerTarefasPage verTarefasPage;

        public string usuario = ConfigurationManager.AppSettings["usuarioMantis"];
        public string senha = ConfigurationManager.AppSettings["senhaMantis"];

        [Test]
        public void Test_criaTarefaSucesso()
        {
            DataBaseSteps db = new DataBaseSteps();
                        
            string projeto = "Teste";
            string categoria = "[Todos os Projetos] General";
            string resumo = "Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4); 
            string descricao = "Descricao Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);

            loginStep.fazLogin(usuario, senha);
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

            Assert.IsNotNull(tarefaBD);
            Assert.IsTrue(tarefaBD[21] == resumo);
        }

        [Test]
        public void Test_verificaTarefaCriadaEmMinhaVisao()
        {
            DataBaseSteps db = new DataBaseSteps();
            PreTestMethods preTest = new PreTestMethods();

            string projeto = "Teste";
            string categoria = "[Todos os Projetos] General";
            string resumo = "Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string descricao = "Descricao Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);

            loginStep.fazLogin(usuario, senha);
            string idTarefa = preTest.PreTestCriarTarefa(projeto, categoria, resumo, descricao);
            minhaVisaoPage.abrirMenuMinhaVisao();
            bool tarefaExiste = minhaVisaoPage.verificaExistenciaTarefaMinhaVisao(idTarefa);

            Assert.IsTrue(tarefaExiste);
        }
        [Test]
        public void Test_verificaFiltroTarefa()
        {
            DataBaseSteps db = new DataBaseSteps();
            PreTestMethods preTest = new PreTestMethods();

            string projeto = "Teste";
            string categoria = "[Todos os Projetos] General";
            string resumo = "Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string descricao = "Descricao Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);

            loginStep.fazLogin(usuario, senha);
            string idTarefa = preTest.PreTestCriarTarefa(projeto, categoria, resumo, descricao);
            verTarefasPage.abrirMenuVerTarefas();
            verTarefasPage.preencheFiltroTarefa(idTarefa);
            verTarefasPage.clicarFiltrarTarefa();
            string idRetornadoGrid = verTarefasPage.retornaIdGridTarefa();

            Assert.IsTrue(idTarefa == idRetornadoGrid);
        }
        [Test]
        public void Test_adicionaMarcadorTarefa()
        {
            DataBaseSteps db = new DataBaseSteps();
            PreTestMethods preTest = new PreTestMethods();

            string projeto = "Teste";
            string categoria = "[Todos os Projetos] General";
            string resumo = "Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string descricao = "Descricao Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string tag = "tag";

            loginStep.fazLogin(usuario, senha);
            string idTarefa = preTest.PreTestCriarTarefa(projeto, categoria, resumo, descricao);
            homePage.preenchePesquisaTarefa(idTarefa);
            verTarefasPage.preencheTag(tag);
            verTarefasPage.clicaAplicarTag();

            List<string> tagTarefaBD = db.retornaTagTarefa(Convert.ToInt32(idTarefa));

            Assert.IsNotNull(tagTarefaBD);
        }
        [Test]
        public void Test_removeMarcadorTarefa()
        {
            DataBaseSteps db = new DataBaseSteps();
            PreTestMethods preTest = new PreTestMethods();

            string projeto = "Teste";
            string categoria = "[Todos os Projetos] General";
            string resumo = "Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string descricao = "Descricao Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string tag = "tag";

            loginStep.fazLogin(usuario, senha);
            string idTarefa = preTest.PreTestCriarTarefa(projeto, categoria, resumo, descricao);
            homePage.preenchePesquisaTarefa(idTarefa);
            verTarefasPage.preencheTag(tag);
            verTarefasPage.clicaAplicarTag();

            List<string> tagTarefaBD = db.retornaTagTarefa(Convert.ToInt32(idTarefa));

            verTarefasPage.clicaBtnRemoverTag();

            List<string> tagTarefaAposDeletarBD = db.retornaTagTarefa(Convert.ToInt32(idTarefa));

            Assert.IsNotNull(tagTarefaBD);
            Assert.IsNull(tagTarefaAposDeletarBD);
        }
        [Test]
        public void Test_adicionaRelacaoInvalida()
        {
            DataBaseSteps db = new DataBaseSteps();
            PreTestMethods preTest = new PreTestMethods();

            string projeto = "Teste";
            string categoria = "[Todos os Projetos] General";
            string resumo = "Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string descricao = "Descricao Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string relacao = "relacaoIvalida";

            loginStep.fazLogin(usuario, senha);
            string idTarefa = preTest.PreTestCriarTarefa(projeto, categoria, resumo, descricao);
            homePage.preenchePesquisaTarefa(idTarefa);
            verTarefasPage.preencheRelacaoTarefa(relacao);
            verTarefasPage.clicaBtnAddRelacao();
            bool msgErro= verTarefasPage.retornaMsgErro();

            Assert.IsTrue(msgErro);
        }
        [Test]
        public void Test_adicionaRelacaoSucesso()
        {
            DataBaseSteps db = new DataBaseSteps();
            PreTestMethods preTest = new PreTestMethods();

            string projeto = "Teste";
            string categoria = "[Todos os Projetos] General";
            string resumo = "Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string descricao = "Descricao Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string tipoRelacao = "está relacionado a";

            loginStep.fazLogin(usuario, senha);
            string idTarefa = preTest.PreTestCriarTarefa(projeto, categoria, resumo, descricao);
            int relacao = Convert.ToInt32(idTarefa);
            homePage.preenchePesquisaTarefa(idTarefa);
            verTarefasPage.selecionaComboTipoRelacao(tipoRelacao);
            verTarefasPage.preencheRelacaoTarefa(Convert.ToString(relacao-1));
            verTarefasPage.clicaBtnAddRelacao();

            List<string> relacaoTarefaBD = db.retornaRelacaoTarefa(Convert.ToInt32(idTarefa));
            Assert.IsTrue(relacaoTarefaBD[2] == Convert.ToString(relacao - 1));
            Assert.IsTrue(relacaoTarefaBD[3] == "1");
        }
        [Test]
        public void Test_adicionaRelacaoPaiSucesso()
        {
            DataBaseSteps db = new DataBaseSteps();
            PreTestMethods preTest = new PreTestMethods();

            string projeto = "Teste";
            string categoria = "[Todos os Projetos] General";
            string resumo = "Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string descricao = "Descricao Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string tipoRelacao = "é pai de";

            loginStep.fazLogin(usuario, senha);
            string idTarefa = preTest.PreTestCriarTarefa(projeto, categoria, resumo, descricao);
            int relacao = Convert.ToInt32(idTarefa);
            homePage.preenchePesquisaTarefa(idTarefa);
            verTarefasPage.selecionaComboTipoRelacao(tipoRelacao);
            verTarefasPage.preencheRelacaoTarefa(Convert.ToString(relacao - 1));
            verTarefasPage.clicaBtnAddRelacao();

            List<string> relacaoTarefaBD = db.retornaRelacaoTarefa(Convert.ToInt32(idTarefa));
            Assert.IsTrue(relacaoTarefaBD[2] == Convert.ToString(relacao - 1));
            Assert.IsTrue(relacaoTarefaBD[3] == "2");
        }
        [Test]
        public void Test_adicionaRelacaoFilhoSucesso()
        {
            DataBaseSteps db = new DataBaseSteps();
            PreTestMethods preTest = new PreTestMethods();

            string projeto = "Teste";
            string categoria = "[Todos os Projetos] General";
            string resumo = "Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string descricao = "Descricao Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string tipoRelacao = "é filho de";

            loginStep.fazLogin(usuario, senha);
            string idTarefa = preTest.PreTestCriarTarefa(projeto, categoria, resumo, descricao);
            int relacao = Convert.ToInt32(idTarefa);
            homePage.preenchePesquisaTarefa(idTarefa);
            verTarefasPage.selecionaComboTipoRelacao(tipoRelacao);
            verTarefasPage.preencheRelacaoTarefa(Convert.ToString(relacao - 1));
            verTarefasPage.clicaBtnAddRelacao();

            List<string> relacaoTarefaBD = db.retornaRelacaoTarefa(relacao - 1);
            Assert.IsTrue(relacaoTarefaBD[1] == Convert.ToString(relacao - 1));
            Assert.IsTrue(relacaoTarefaBD[3] == "2");
        }
        [Test]
        public void Test_adicionaRelacaoDuplicadaSucesso()
        {
            DataBaseSteps db = new DataBaseSteps();
            PreTestMethods preTest = new PreTestMethods();

            string projeto = "Teste";
            string categoria = "[Todos os Projetos] General";
            string resumo = "Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string descricao = "Descricao Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string tipoRelacao = "é duplicado de";

            loginStep.fazLogin(usuario, senha);
            string idTarefa = preTest.PreTestCriarTarefa(projeto, categoria, resumo, descricao);
            int relacao = Convert.ToInt32(idTarefa);
            homePage.preenchePesquisaTarefa(idTarefa);
            verTarefasPage.selecionaComboTipoRelacao(tipoRelacao);
            verTarefasPage.preencheRelacaoTarefa(Convert.ToString(relacao - 1));
            verTarefasPage.clicaBtnAddRelacao();

            List<string> relacaoTarefaBD = db.retornaRelacaoTarefa(Convert.ToInt32(idTarefa));
            Assert.IsTrue(relacaoTarefaBD[2] == Convert.ToString(relacao - 1));
            Assert.IsTrue(relacaoTarefaBD[3] == "0");
        }
        [Test]
        public void Test_adicionaRelacaoPossuiDuplicidadeSucesso()
        {
            DataBaseSteps db = new DataBaseSteps();
            PreTestMethods preTest = new PreTestMethods();

            string projeto = "Teste";
            string categoria = "[Todos os Projetos] General";
            string resumo = "Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string descricao = "Descricao Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string tipoRelacao = "possui duplicado";

            loginStep.fazLogin(usuario, senha);
            string idTarefa = preTest.PreTestCriarTarefa(projeto, categoria, resumo, descricao);
            int relacao = Convert.ToInt32(idTarefa);
            homePage.preenchePesquisaTarefa(idTarefa);
            verTarefasPage.selecionaComboTipoRelacao(tipoRelacao);
            verTarefasPage.preencheRelacaoTarefa(Convert.ToString(relacao - 1));
            verTarefasPage.clicaBtnAddRelacao();

            List<string> relacaoTarefaBD = db.retornaRelacaoTarefa(relacao - 1);
            Assert.IsTrue(relacaoTarefaBD[1] == Convert.ToString(relacao - 1));
            Assert.IsTrue(relacaoTarefaBD[3] == "0");
        }
        [Test]
        public void Test_atribuiTarefaUsuario()
        {
            DataBaseSteps db = new DataBaseSteps();
            PreTestMethods preTest = new PreTestMethods();

            string projeto = "Teste";
            string categoria = "[Todos os Projetos] General";
            string resumo = "Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string descricao = "Descricao Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);


            loginStep.fazLogin(usuario, senha);
            string idTarefa = preTest.PreTestCriarTarefa(projeto, categoria, resumo, descricao);
            int bugIdInt = Convert.ToInt32(idTarefa);
            homePage.preenchePesquisaTarefa(idTarefa);
            verTarefasPage.clicaBtnAtualizarTarefa();
            verTarefasPage.selecinaComboAtribuicao(usuario);
            verTarefasPage.clicaBntConfirmaAtualizacaoTarefa();

            string idUsuario = db.retornaidUsuario(usuario);
            List<string> tarefaBD = db.retornaTarefaCriadaPorId(Convert.ToString(bugIdInt));

            Assert.IsTrue(tarefaBD[3] == idUsuario);
        }
        [Test]
        public void Test_tentaResolverTarefaComStatusNovo()
        {
            DataBaseSteps db = new DataBaseSteps();
            PreTestMethods preTest = new PreTestMethods();

            string projeto = "Teste";
            string categoria = "[Todos os Projetos] General";
            string resumo = "Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string descricao = "Descricao Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string resolucao = "corrigido";

            loginStep.fazLogin(usuario, senha);
            string idTarefa = preTest.PreTestCriarTarefa(projeto, categoria, resumo, descricao);
            int bugIdInt = Convert.ToInt32(idTarefa);
            homePage.preenchePesquisaTarefa(idTarefa);
            verTarefasPage.clicaBtnAtualizarTarefa();
            verTarefasPage.selecionaComboResolucao(resolucao);
            verTarefasPage.clicaBntConfirmaAtualizacaoTarefa();
            bool msgErro = verTarefasPage.retornaMsgErro();

            Assert.IsTrue(msgErro);
        }
        [Test]
        public void Test_tentaResolverTarefaSucesso()
        {
            DataBaseSteps db = new DataBaseSteps();
            PreTestMethods preTest = new PreTestMethods();

            string projeto = "Teste";
            string categoria = "[Todos os Projetos] General";
            string resumo = "Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string descricao = "Descricao Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string status = "resolvido";
            string resolucao = "corrigido";

            loginStep.fazLogin(usuario, senha);
            string idTarefa = preTest.PreTestCriarTarefa(projeto, categoria, resumo, descricao);
            int bugIdInt = Convert.ToInt32(idTarefa);
            homePage.preenchePesquisaTarefa(idTarefa);
            verTarefasPage.clicaBtnAtualizarTarefa();
            verTarefasPage.selecionaStatusTarefa(status);
            verTarefasPage.selecionaComboResolucao(resolucao);
            verTarefasPage.clicaBntConfirmaAtualizacaoTarefa();

            List<string> tarefaBD = db.retornaTarefaCriadaPorId(Convert.ToString(bugIdInt));

            Assert.IsTrue(tarefaBD[9] == "20");
        }
        [Test]
        public void Test_alteraPrioridadeTarefa()
        {
            DataBaseSteps db = new DataBaseSteps();
            PreTestMethods preTest = new PreTestMethods();

            string projeto = "Teste";
            string categoria = "[Todos os Projetos] General";
            string resumo = "Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string descricao = "Descricao Tarefa " + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string prioridade = "urgente";

            loginStep.fazLogin(usuario, senha);
            string idTarefa = preTest.PreTestCriarTarefa(projeto, categoria, resumo, descricao);
            int bugIdInt = Convert.ToInt32(idTarefa);
            homePage.preenchePesquisaTarefa(idTarefa);
            verTarefasPage.clicaBtnAtualizarTarefa();
            verTarefasPage.selecinaComboPrioridade(prioridade);
            verTarefasPage.clicaBntConfirmaAtualizacaoTarefa();

            List<string> tarefaBD = db.retornaTarefaCriadaPorId(Convert.ToString(bugIdInt));

            Assert.IsTrue(tarefaBD[5] == "50");
        }
    }
}
