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

namespace DesafioTests.Tests
{
    public class GerenciarTests : TestBase
    {
        [PageObject]
        GerenciarUsuarioPage gerenciarUsuarioPage;
        [PageObject]
        LoginStep loginStep;
        [PageObject]
        GerenciarProjetoPage gerenciarProjetoPage;
        [PageObject]
        GerenciarMarcadoresPage gerenciarMarcadoresPage;

        public string usuario = ConfigurationManager.AppSettings["usuarioMantis"];
        public string senha = ConfigurationManager.AppSettings["senhaMantis"];

        #region Teste gerenciamento usuário
        [Test]
        public void Test_verificaTrocaPerfilAdministrador()
        {
            DataBaseSteps db = new DataBaseSteps();

            string usuarioAtualizar = "usuario1";
            string perfil = "administrador";

            loginStep.fazLogin(usuario, senha);
            gerenciarUsuarioPage.abrirMenuGerenciarUsuario();
            gerenciarUsuarioPage.pesquisarUsuario(usuarioAtualizar);
            gerenciarUsuarioPage.clicaPrimeirGridUsuario();
            gerenciarUsuarioPage.selecionaNivelUsuario(perfil);
            gerenciarUsuarioPage.gravaAlteracaoUsuario();

            string status = db.retornaNivelAcesso(usuarioAtualizar);

            Assert.IsTrue(status == "90");
        }
        [Test]
        public void Test_inativaUsuario()
        {
            DataBaseSteps db = new DataBaseSteps();

            string usuarioDesativar = "usuario1";

            loginStep.fazLogin(usuario, senha);
            gerenciarUsuarioPage.abrirMenuGerenciarUsuario();
            gerenciarUsuarioPage.pesquisarUsuario(usuarioDesativar);
            gerenciarUsuarioPage.clicaPrimeirGridUsuario();
            gerenciarUsuarioPage.desabilitaUsuario();
            gerenciarUsuarioPage.gravaAlteracaoUsuario();

            string status = db.retornaStatusUsuario(usuarioDesativar);

            Assert.IsTrue(status == "0");           
        }
        [Test]
        public void Test_verificaTrocaPerfilGerente()
        {
            DataBaseSteps db = new DataBaseSteps();

            string usuarioAtualizar = "usuario1";
            string perfil = "gerente";

            loginStep.fazLogin(usuario, senha);
            gerenciarUsuarioPage.abrirMenuGerenciarUsuario();
            gerenciarUsuarioPage.pesquisarUsuario(usuarioAtualizar);
            gerenciarUsuarioPage.clicaPrimeirGridUsuario();
            gerenciarUsuarioPage.selecionaNivelUsuario(perfil);
            gerenciarUsuarioPage.gravaAlteracaoUsuario();

            string status = db.retornaNivelAcesso(usuarioAtualizar);

            Assert.IsTrue(status == "70");
        }
        [Test]
        public void Test_verificaTrocaPerfilDesenvolvedor()
        {
            DataBaseSteps db = new DataBaseSteps();

            string usuarioAtualizar = "usuario1";
            string perfil = "desenvolvedor";

            loginStep.fazLogin(usuario, senha);
            gerenciarUsuarioPage.abrirMenuGerenciarUsuario();
            gerenciarUsuarioPage.pesquisarUsuario(usuarioAtualizar);
            gerenciarUsuarioPage.clicaPrimeirGridUsuario();
            gerenciarUsuarioPage.selecionaNivelUsuario(perfil);
            gerenciarUsuarioPage.gravaAlteracaoUsuario();

            string status = db.retornaNivelAcesso(usuarioAtualizar);

            Assert.IsTrue(status == "55");
        }
        [Test]
        public void Test_verificaTrocaPerfilAtualizador()
        {
            DataBaseSteps db = new DataBaseSteps();

            string usuarioAtualizar = "usuario1";
            string perfil = "atualizador";

            loginStep.fazLogin(usuario, senha);
            gerenciarUsuarioPage.abrirMenuGerenciarUsuario();
            gerenciarUsuarioPage.pesquisarUsuario(usuarioAtualizar);
            gerenciarUsuarioPage.clicaPrimeirGridUsuario();
            gerenciarUsuarioPage.selecionaNivelUsuario(perfil);
            gerenciarUsuarioPage.gravaAlteracaoUsuario();

            string status = db.retornaNivelAcesso(usuarioAtualizar);

            Assert.IsTrue(status == "40");
        }
        [Test]
        public void Test_verificaTrocaPerfilRelator()
        {
            DataBaseSteps db = new DataBaseSteps();

            string usuarioAtualizar = "usuario1";
            string perfil = "relator";

            loginStep.fazLogin(usuario, senha);
            gerenciarUsuarioPage.abrirMenuGerenciarUsuario();
            gerenciarUsuarioPage.pesquisarUsuario(usuarioAtualizar);
            gerenciarUsuarioPage.clicaPrimeirGridUsuario();
            gerenciarUsuarioPage.selecionaNivelUsuario(perfil);
            gerenciarUsuarioPage.gravaAlteracaoUsuario();

            string status = db.retornaNivelAcesso(usuarioAtualizar);

            Assert.IsTrue(status == "25");
        }
        [Test]
        public void Test_verificaTrocaPerfilVisualizador()
        {
            DataBaseSteps db = new DataBaseSteps();

            string usuarioAtualizar = "usuario1";
            string perfil = "visualizador";

            loginStep.fazLogin(usuario, senha);
            gerenciarUsuarioPage.abrirMenuGerenciarUsuario();
            gerenciarUsuarioPage.pesquisarUsuario(usuarioAtualizar);
            gerenciarUsuarioPage.clicaPrimeirGridUsuario();
            gerenciarUsuarioPage.selecionaNivelUsuario(perfil);
            gerenciarUsuarioPage.gravaAlteracaoUsuario();

            string status = db.retornaNivelAcesso(usuarioAtualizar);

            Assert.IsTrue(status == "10");
        }
        [Test]
        public void Test_verificaAlteracaoEmailUsuario()
        {
            DataBaseSteps db = new DataBaseSteps();

            string usuarioAtualizar = "usuario1";
            string email = "teste@hotmail.com";

            loginStep.fazLogin(usuario, senha);
            gerenciarUsuarioPage.abrirMenuGerenciarUsuario();
            gerenciarUsuarioPage.pesquisarUsuario(usuarioAtualizar);
            gerenciarUsuarioPage.clicaPrimeirGridUsuario();
            gerenciarUsuarioPage.preencheEmail(email);
            gerenciarUsuarioPage.gravaAlteracaoUsuario();

            string novoEmail = db.retornaEmailUsuario(usuarioAtualizar);

            Assert.IsTrue(novoEmail == email);
        }
        [Test]
        public void Test_apagaUsuario()
        {
            DataBaseSteps db = new DataBaseSteps();

            string usuarioApagar = "usuario1";

            loginStep.fazLogin(usuario, senha);
            gerenciarUsuarioPage.abrirMenuGerenciarUsuario();
            gerenciarUsuarioPage.pesquisarUsuario(usuarioApagar);
            gerenciarUsuarioPage.clicaPrimeirGridUsuario();
            gerenciarUsuarioPage.apagaUsuario();

            string usu = db.retornaUsuario(usuarioApagar);

            Assert.IsNull(usu);
        }
        [Test]
        public void Test_alteraNomeUsuario()
        {
            DataBaseSteps db = new DataBaseSteps();

            string usuarioAlterar = "testeAlteraNome";
            string novoNomeUsuario = "NovoNome"+Utilitarios.GetRandomIDNumber().Substring(1,4);

            loginStep.fazLogin(usuario, senha);
            gerenciarUsuarioPage.abrirMenuGerenciarUsuario();
            gerenciarUsuarioPage.pesquisarUsuario(usuarioAlterar);
            gerenciarUsuarioPage.clicaPrimeirGridUsuario();
            gerenciarUsuarioPage.preencheNomeUsuario(novoNomeUsuario);
            gerenciarUsuarioPage.gravaAlteracaoUsuario();

            string usu = db.retornaNomeUsuario("alteraNome@gmail.com");

            Assert.IsTrue(usu == novoNomeUsuario);
        }
        [Test]
        public void Test_alteraNomeRealUsuario()
        {
            DataBaseSteps db = new DataBaseSteps();

            string usuarioAlterar = "testeAlteraNome";
            string novoNomeRealUsuario = "NovoNome" + Utilitarios.GetRandomIDNumber().Substring(1, 4);

            loginStep.fazLogin(usuario, senha);
            gerenciarUsuarioPage.abrirMenuGerenciarUsuario();
            gerenciarUsuarioPage.pesquisarUsuario(usuarioAlterar);
            gerenciarUsuarioPage.clicaPrimeirGridUsuario();
            gerenciarUsuarioPage.preencheNomeVerdadeiro(novoNomeRealUsuario);
            gerenciarUsuarioPage.gravaAlteracaoUsuario();

            string usu = db.retornaNomeRealUsuario("alteraNome@gmail.com");

            Assert.IsTrue(usu == novoNomeRealUsuario);
        }
        [Test]
        public void Test_criaNovoUsuario()
        {
            DataBaseSteps db = new DataBaseSteps();

            string usuarioCriar = "Usu" + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string nomeCriar = "Nome" + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string emailCriar = "a"+ Utilitarios.GetRandomIDNumber().Substring(1, 4) +"@gmail.com";
            string nivelAcessoCriar = "administrador";

            loginStep.fazLogin(usuario, senha);
            gerenciarUsuarioPage.abrirMenuGerenciarUsuario();
            gerenciarUsuarioPage.criarNovoUsuario();
            gerenciarUsuarioPage.preencheCampoNovoNomeUsuario(usuarioCriar);
            gerenciarUsuarioPage.preencheCampoNovoNomeReal(nomeCriar);
            gerenciarUsuarioPage.preencheCampoNovoEmail(emailCriar);
            gerenciarUsuarioPage.preencheCampoNovoNivel(nivelAcessoCriar);
            gerenciarUsuarioPage.confirmarNovoUsuario();

            string usu = db.retornaUsuario(usuarioCriar);

            Assert.IsNotNull(usu);
        }
        [Test]
        public void Test_criaUsuarioNomeJaCadastrado()
        {
            DataBaseSteps db = new DataBaseSteps();

            string usuarioCriar = "Usuario1";
            string nomeCriar = "Nome" + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string emailCriar = "a" + Utilitarios.GetRandomIDNumber().Substring(1, 4) + "@gmail.com";
            string nivelAcessoCriar = "administrador";

            loginStep.fazLogin(usuario, senha);
            gerenciarUsuarioPage.abrirMenuGerenciarUsuario();
            gerenciarUsuarioPage.criarNovoUsuario();
            gerenciarUsuarioPage.preencheCampoNovoNomeUsuario(usuarioCriar);
            gerenciarUsuarioPage.preencheCampoNovoNomeReal(nomeCriar);
            gerenciarUsuarioPage.preencheCampoNovoEmail(emailCriar);
            gerenciarUsuarioPage.preencheCampoNovoNivel(nivelAcessoCriar);
            gerenciarUsuarioPage.confirmarNovoUsuario();
            bool msgErro = gerenciarProjetoPage.retornaMsgErro();

            string usu = db.retornaUsuario(usuarioCriar);

            Assert.IsTrue(msgErro);
        }
        [Test]
        public void Test_criaUsuarioEmailJaCadastrado()
        {
            DataBaseSteps db = new DataBaseSteps();

            string usuarioCriar = "Usu" + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string nomeCriar = "Nome" + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string emailCriar = "luana.assis1@gmail.com";
            string nivelAcessoCriar = "administrador";

            loginStep.fazLogin(usuario, senha);
            gerenciarUsuarioPage.abrirMenuGerenciarUsuario();
            gerenciarUsuarioPage.criarNovoUsuario();
            gerenciarUsuarioPage.preencheCampoNovoNomeUsuario(usuarioCriar);
            gerenciarUsuarioPage.preencheCampoNovoNomeReal(nomeCriar);
            gerenciarUsuarioPage.preencheCampoNovoEmail(emailCriar);
            gerenciarUsuarioPage.preencheCampoNovoNivel(nivelAcessoCriar);
            gerenciarUsuarioPage.confirmarNovoUsuario();
            bool msgErro = gerenciarProjetoPage.retornaMsgErro();

            string usu = db.retornaUsuario(usuarioCriar);

            Assert.IsTrue(msgErro);
        }

        #endregion
        #region Teste Gerenciamento Projeto
        [Test]
        public void Test_editarStadoParaRelease()
        {
            DataBaseSteps db = new DataBaseSteps();

            string estado = "release";
            string projeto = "Teste";

            loginStep.fazLogin(usuario, senha);
            gerenciarProjetoPage.abrirMenuGerenciarProjeto();
            gerenciarProjetoPage.abrirGridProjeto();
            gerenciarProjetoPage.selecaoComboEstado(estado);
            gerenciarProjetoPage.clicaBtnAtualizarProjeto();

            string status = db.retornaStatusProjeto(projeto);

            Assert.IsTrue(status == "30");
        }
        [Test]
        public void Test_editarStadoParaEstavel()
        {
            DataBaseSteps db = new DataBaseSteps();

            string estado = "estável";
            string projeto = "Teste";

            loginStep.fazLogin(usuario, senha);
            gerenciarProjetoPage.abrirMenuGerenciarProjeto();
            gerenciarProjetoPage.abrirGridProjeto();
            gerenciarProjetoPage.selecaoComboEstado(estado);
            gerenciarProjetoPage.clicaBtnAtualizarProjeto();

            string status = db.retornaStatusProjeto(projeto);

            Assert.IsTrue(status == "50");
        }
        [Test]
        public void Test_editarStadoParaObsoleto()
        {
            DataBaseSteps db = new DataBaseSteps();

            string estado = "obsoleto";
            string projeto = "Teste";

            loginStep.fazLogin(usuario, senha);
            gerenciarProjetoPage.abrirMenuGerenciarProjeto();
            gerenciarProjetoPage.abrirGridProjeto();
            gerenciarProjetoPage.selecaoComboEstado(estado);
            gerenciarProjetoPage.clicaBtnAtualizarProjeto();

            string status = db.retornaStatusProjeto(projeto);

            Assert.IsTrue(status == "70");
        }
        [Test]
        public void Test_criarNovoProjeto()
        {
            DataBaseSteps db = new DataBaseSteps();

            string nomeProjeto = "Projeto Teste Automatizado";
            string estadoProjeto = "release";
            string visibilidadeProjeto = "público";
            string descricaoProjeto = "Inserindo projeto atravez de testes automaziados.";

            loginStep.fazLogin(usuario, senha);
            gerenciarProjetoPage.abrirMenuGerenciarProjeto();
            gerenciarProjetoPage.clicarBtnNovoProjeto();
            gerenciarProjetoPage.preencheNomeProjeto(nomeProjeto);
            gerenciarProjetoPage.selecaoComboEstado(estadoProjeto);
            gerenciarProjetoPage.selecionarVisibilidade(visibilidadeProjeto);
            gerenciarProjetoPage.preencheDescricaoProjeto(descricaoProjeto);
            gerenciarProjetoPage.clicarAdicionarProjeto();

            List<string> dadosProjeto = db.retornaDadosProjeto(nomeProjeto);

            Assert.IsNotNull(dadosProjeto);
        }
        [Test]
        public void Test_alterarVisibilidadePrivado()
        {
            DataBaseSteps db = new DataBaseSteps();

            string visibilidade = "privado";
            string projeto = "Teste";

            loginStep.fazLogin(usuario, senha);
            gerenciarProjetoPage.abrirMenuGerenciarProjeto();
            gerenciarProjetoPage.abrirGridProjeto();
            gerenciarProjetoPage.selecionarVisibilidade(visibilidade);
            gerenciarProjetoPage.clicaBtnAtualizarProjeto();

            string view = db.retornaVisibilidadeProjeto(projeto);

            Assert.IsTrue(view == "50");
        }
        [Test]
        public void Test_alterarVisibilidadePublico()
        {
            DataBaseSteps db = new DataBaseSteps();

            string visibilidade = "público";
            string projeto = "Teste";

            loginStep.fazLogin(usuario, senha);
            gerenciarProjetoPage.abrirMenuGerenciarProjeto();
            gerenciarProjetoPage.abrirGridProjeto();
            gerenciarProjetoPage.selecionarVisibilidade(visibilidade);
            gerenciarProjetoPage.clicaBtnAtualizarProjeto();

            string view = db.retornaVisibilidadeProjeto(projeto);

            Assert.IsTrue(view == "10");
        }
        [Test]
        public void Test_vincularSubProjeto()
        {
            DataBaseSteps db = new DataBaseSteps();

            string projeto = "Teste";
            string subProjeto = "Teste SubProjeto";

            loginStep.fazLogin(usuario, senha);
            gerenciarProjetoPage.abrirMenuGerenciarProjeto();
            gerenciarProjetoPage.abrirGridProjeto();
            gerenciarProjetoPage.selecionaSubProjeto(subProjeto);
            gerenciarProjetoPage.adicionarSubProjeto();

            List<string> dadosProjetoPai = db.retornaDadosProjeto(projeto);
            string idProjetoPai = dadosProjetoPai[0];

            List<string> dadosProjetoFilho = db.retornaDadosProjeto(subProjeto);
            string idProjetoFilho = dadosProjetoFilho[0];

            List<string> dadosVinculo = db.retornaVinculoSubProjeto(idProjetoPai, idProjetoFilho);

            Assert.IsNotNull(dadosVinculo);

        }
        [Test]
        public void Test_desabilitarProjeto()
        {
            DataBaseSteps db = new DataBaseSteps();

            string projeto = "Teste";

            loginStep.fazLogin(usuario, senha);
            gerenciarProjetoPage.abrirMenuGerenciarProjeto();
            gerenciarProjetoPage.abrirGridProjeto();
            gerenciarProjetoPage.desabilitaProjeto();
            gerenciarProjetoPage.clicaBtnAtualizarProjeto();

            List<string> dadosProjeto = db.retornaDadosProjeto(projeto);
            string status = dadosProjeto[3];
                        
            Assert.IsTrue(status == "0");

        }
        [Test]
        public void Test_cadastrarProjetoNomeJaExistente()
        {
            DataBaseSteps db = new DataBaseSteps();

            string nomeProjeto = "Teste";
            string estadoProjeto = "desenvolvimento";
            string visibilidadeProjeto = "público";
            string descricaoProjeto = "Inserindo projeto atravez de testes automaziados.";

            loginStep.fazLogin(usuario, senha);
            gerenciarProjetoPage.abrirMenuGerenciarProjeto();
            gerenciarProjetoPage.clicarBtnNovoProjeto();
            gerenciarProjetoPage.preencheNomeProjeto(nomeProjeto);
            gerenciarProjetoPage.selecaoComboEstado(estadoProjeto);
            gerenciarProjetoPage.selecionarVisibilidade(visibilidadeProjeto);
            gerenciarProjetoPage.preencheDescricaoProjeto(descricaoProjeto);
            gerenciarProjetoPage.clicarAdicionarProjeto();
            bool msg = gerenciarProjetoPage.retornaMsgErro();

            List<string> dadosProjeto = db.retornaDadosProjeto(nomeProjeto);

            Assert.IsTrue(msg);
            Assert.IsTrue(dadosProjeto.Count() == 10);          

        }
        #endregion

        #region Teste Gerenciamento Marcadores
        [Test]
        public void Test_editarNomeMarcador()
        {
            DataBaseSteps db = new DataBaseSteps();

            string novoNomeMarcador = "NovoNomeMarcador";
            string descricaoMarcador = "descricao";
            
            loginStep.fazLogin(usuario, senha);
            gerenciarMarcadoresPage.abrirMenuGerenciarMarcadores();
            gerenciarMarcadoresPage.selecionaMarcadorTeste();
            gerenciarMarcadoresPage.clicaAtualizarMarcador();
            gerenciarMarcadoresPage.preencheNomeMarcador(novoNomeMarcador);
            gerenciarMarcadoresPage.clicaAtualizarMarcador();
            
            List<string> marcadorRetornado = db.retornaMarcadorPorDescricao(descricaoMarcador);
            string nomeMarcadorBD = marcadorRetornado[2];

            Assert.That(novoNomeMarcador == nomeMarcadorBD);
        }
        [Test]
        public void Test_cadastrarNomeMarcadorJaExistente()
        {
            DataBaseSteps db = new DataBaseSteps();

            string novoNomeMarcadorAtualizar = "marcadorTeste2";
            string descricaoMarcador = "descricao"; 

            loginStep.fazLogin(usuario, senha);
            gerenciarMarcadoresPage.abrirMenuGerenciarMarcadores();
            gerenciarMarcadoresPage.selecionaMarcadorTeste();
            gerenciarMarcadoresPage.clicaAtualizarMarcador();
            gerenciarMarcadoresPage.preencheNomeMarcador(novoNomeMarcadorAtualizar);
            gerenciarMarcadoresPage.clicaAtualizarMarcador();
            bool msgErro = gerenciarMarcadoresPage.retornaMsgErro();

            List<string> marcadorRetornado = db.retornaMarcadorPorNome(novoNomeMarcadorAtualizar);

            Assert.That(marcadorRetornado.Count() == 6);
            Assert.IsTrue(msgErro);
        }
        [Test]
        public void Test_editarDescricaoMarcador()
        {
            DataBaseSteps db = new DataBaseSteps();

            string novaDescricaoMarcador = "Nova descrição para marcador";

            loginStep.fazLogin(usuario, senha);
            gerenciarMarcadoresPage.abrirMenuGerenciarMarcadores();
            gerenciarMarcadoresPage.selecionaMarcadorTeste2();
            gerenciarMarcadoresPage.clicaAtualizarMarcador();
            gerenciarMarcadoresPage.preencheDescricaoMarcador(novaDescricaoMarcador);
            gerenciarMarcadoresPage.clicaAtualizarMarcador();

            List<string> marcadorRetornado = db.retornaMarcadorPorNome("marcadorTeste2");
            string descricaoMarcadorBD = marcadorRetornado[3];

            Assert.That(descricaoMarcadorBD == novaDescricaoMarcador);
        }
        [Test]
        public void Test_criarNovoMarcador()
        {
            DataBaseSteps db = new DataBaseSteps();

            string nomeMarcador = "CadastroMarcador" + Utilitarios.GetRandomIDNumber().Substring(1, 4);
            string descricaoMarcador = "Descricao Marcador " + Utilitarios.GetRandomIDNumber().Substring(1, 6);

            loginStep.fazLogin(usuario, senha);
            gerenciarMarcadoresPage.abrirMenuGerenciarMarcadores();
            gerenciarMarcadoresPage.clicaBtnCriarMarcador();
            gerenciarMarcadoresPage.preencheNomeMarcador(nomeMarcador);
            gerenciarMarcadoresPage.preencheDescricaoMarcador(descricaoMarcador);
            gerenciarMarcadoresPage.clicaBtnConfirmarCriacaoMarcador();

            List<string> marcadorBD = db.retornaMarcadorPorNome(nomeMarcador);

            Assert.IsNotNull(marcadorBD);
        }
        #endregion
    }
}
