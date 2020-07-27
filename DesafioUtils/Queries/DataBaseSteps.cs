using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesafioUtils.DataBaseHelpres;

namespace DesafioUtils.Queries
{
    public class DataBaseSteps : DataBaseInteractions
    {
        DataBaseInteractions db = new DataBaseInteractions();

        public void cargaTabelaUsuario()
        {
            string consulta1 = string.Format(@"select username from mantis_user_mantis where username = 'usuario1'");
            List<string> resultado1 = db.retornaDadosQuery(consulta1);
            if(resultado1 == null)
            {
                string query1 = string.Format(@" INSERT INTO mantis_user_mantis ( username, realname, email,
                PASSWORD, enabled, protected, access_level, login_count, lost_password_request_count, failed_login_count, cookie_string, last_visit, date_created)
                VALUES('usuario1', 'Teste','luana.assis1@gmail.com', 'e10adc3949ba59abbe56e057f20f883e', 1, 0, 90, 1, 0, 0, 'JCIfQbZ9Wdq0eONcOMkSOR17wMSjowjc68', 1574199190, 1574199190)");
                db.executaQuery(query1);
            }
            //


            string consulta2 = string.Format(@"select username from mantis_user_mantis where username = 'usuario2'");
            List<string> resultado2 = db.retornaDadosQuery(consulta2);
            if (resultado2 == null)
            {
                string query2 = string.Format(@" INSERT INTO mantis_user_mantis ( username, realname, email,
                PASSWORD, enabled, protected, access_level, login_count, lost_password_request_count, failed_login_count, cookie_string, last_visit, date_created)
                VALUES('usuario2', 'Teste','luana.assis2@gmail.com', 'e10adc3949ba59abbe56e057f20f883e', 1, 0, 90, 1, 0, 0, 'JCIfQbZ9Wdq0eONcOMkSOR17wMSjowjc6L', 1574199190, 1574199190)");
                db.executaQuery(query2);
            }

            string consulta3 = string.Format(@"select username from mantis_user_mantis where username = 'luana.assis'");
            List<string> resultado3 = db.retornaDadosQuery(consulta3);
            if (resultado3 == null)
            {

                string query3 = string.Format(@" INSERT INTO mantis_user_mantis ( username, realname, email,
                PASSWORD, enabled, protected, access_level, login_count, lost_password_request_count, failed_login_count, cookie_string, last_visit, date_created)
                VALUES('luana.assis', 'Luana Assis','luana.assis@gmail.com', 'e10adc3949ba59abbe56e057f20f883e', 1, 0, 90, 1, 0, 0, 'JCIfQbZ9Wdq0eONcOMkSOR17wMSjowjc7L', 1574199190, 1574199190)");
                db.executaQuery(query3);
            }
            string consulta4 = string.Format(@"select username from mantis_user_mantis where username = 'usu.inativo'");
            List<string> resultado4 = db.retornaDadosQuery(consulta4);
            if (resultado4 == null)
            {

                string query4 = string.Format(@" INSERT INTO mantis_user_mantis ( username, realname, email,
                PASSWORD, enabled, protected, access_level, login_count, lost_password_request_count, failed_login_count, cookie_string, last_visit, date_created)
                VALUES('usu.inativo', 'Usuario inativo','usu.inativo@gmail.com', 'e10adc3949ba59abbe56e057f20f883e', 0, 0, 90, 1, 0, 0, 'JCIfQbZ9Wdq0eONcOMkSOR17wMSjowsc7L', 1574199190, 1574199190)");
                db.executaQuery(query4);
            }
            string consulta5 = string.Format(@"select username from mantis_user_mantis where email = 'alteraNome@gmail.com'");
            List<string> resultado5 = db.retornaDadosQuery(consulta5);
            if (resultado5 == null)
            {

                string query5 = string.Format(@" INSERT INTO mantis_user_mantis ( username, realname, email,
                PASSWORD, enabled, protected, access_level, login_count, lost_password_request_count, failed_login_count, cookie_string, last_visit, date_created)
                VALUES('testeAlteraNome', 'TesteAlteraNomeReal','alteraNome@gmail.com', 'e10adc3949ba59abbe56e057f20f883e', 1, 0, 90, 1, 0, 0, 'JCIfQbZ9Wdq0eONcOMkSOR17wMSjokkc7L', 1574199190, 1574199190)");
                db.executaQuery(query5);
            }
            //
        }
        public void cargaProjeto()
        {
            string consulta = string.Format(@"SELECT * FROM mantis_project_mantis WHERE NAME = 'Teste'");
            List<string> resultado = db.retornaDadosQuery(consulta);
            if (resultado == null)
            {
                string query = string.Format(@"INSERT INTO mantis_project_mantis ( name, status, enabled, view_state, access_min, file_path, description, category_id, inherit_global)
                                               VALUES('Teste', 10,1, 10, 10, '', '', 1, 1)");
                db.executaQuery(query);
            }
            //

            string consulta3 = string.Format(@"SELECT * FROM mantis_project_mantis WHERE NAME = 'Teste SubProjeto'");
            List<string> resultado3 = db.retornaDadosQuery(consulta3);
            if (resultado3 == null)
            {
                string query3 = string.Format(@"INSERT INTO mantis_project_mantis ( name, status, enabled, view_state, access_min, file_path, description, category_id, inherit_global)
                                               VALUES('Teste SubProjeto', 10,1, 10, 10, '', '', 1, 1)");
                db.executaQuery(query3);
            }
            

        }
        
        public void cargaMarcadores()
        {
            //seleciona id
            string consulta0 = string.Format(@"select id from mantis_user_mantis where username = 'luana.assis'");
            List<string> resultado0 = db.retornaDadosQuery(consulta0);
            string idUser = resultado0[0];

            //where por descricao, porque os casos de testes atualizam o nome dele
            string consulta = string.Format(@"SELECT * FROM mantis_tag_mantis WHERE description = 'descricao'");
            List<string> resultado = db.retornaDadosQuery(consulta);
            if (resultado == null)
            {
                string query = string.Format(@"INSERT INTO mantis_tag_mantis(user_id, NAME, description, 
                                               date_created, date_updated) VALUES({0}, 'marcadorTeste', 'descricao', 1581651675, 1581651675)", idUser);
                db.executaQuery(query);
            }
           //
            string consulta1 = string.Format(@"SELECT * FROM mantis_tag_mantis WHERE NAME = 'marcadorTeste2'");
            List<string> resultado1 = db.retornaDadosQuery(consulta1);
            if (resultado1 == null)
            {
                string query1 = string.Format(@"INSERT INTO mantis_tag_mantis(user_id, NAME, description, 
                                               date_created, date_updated) VALUES({0}, 'marcadorTeste2', 'descricao2', 1581651675, 1581651675)", idUser);
                db.executaQuery(query1);
            }
            
        }

        public void atualizacaoCargaUsuario()
        {
            string consulta = string.Format(@"select username from mantis_user_mantis where username = 'usuario1'");
            List<string> resultado = db.retornaDadosQuery(consulta);
            if (resultado == null)
            {
                string query = string.Format(@" INSERT INTO mantis_user_mantis ( username, realname, email,
                PASSWORD, enabled, protected, access_level, login_count, lost_password_request_count, failed_login_count, cookie_string, last_visit, date_created)
                VALUES('usuario1', 'Teste','luana.assis1@gmail.com', 'e10adc3949ba59abbe56e057f20f883e', 1, 0, 90, 1, 0, 0, 'JCIfQbZ9Wdq0eONcOMkSOR17wMSjowjc68', 1574199190, 1574199190)");
                db.executaQuery(query);
            }

            string consulta1 = string.Format(@"select username from mantis_user_mantis where username = 'usuario1'");
            List<string> resultado1 = db.retornaDadosQuery(consulta1);
            if (resultado1.Count >= 1)
            {
                string query1 = string.Format(@"update mantis_user_mantis set enabled = 1, access_level = 90, email = 'luana.assis1@gmail.com' where username = 'usuario1'");
                db.executaQuery(query1);
            }

            string consulta2 = string.Format(@"select username from mantis_user_mantis where email = 'alteraNome@gmail.com'");
            List<string> resultado2 = db.retornaDadosQuery(consulta2);
            if (resultado2.Count >= 1)
            {
                string query2 = string.Format(@"update mantis_user_mantis set username = 'testeAlteraNome', realname = 'TesteAlteraNomeReal'  where email = 'alteraNome@gmail.com'");
                db.executaQuery(query2);
            }
        }
        public void atualizacaoCargaProjeto()
        {
            string consulta1 = string.Format(@"SELECT name FROM mantis_project_mantis WHERE NAME = 'Teste'");
            List<string> resultado1 = db.retornaDadosQuery(consulta1);
            if (resultado1.Count >= 1)
            {
                string query1 = string.Format(@"update mantis_project_mantis set status = 10, view_state= 10, enabled= 1 where name = 'Teste'");
                db.executaQuery(query1);
            }
            string consulta2 = string.Format(@"delete FROM mantis_project_mantis WHERE NAME = 'Projeto Teste Automatizado'");
            List<string> resultado2 = db.retornaDadosQuery(consulta2);

            string consulta3 = string.Format(@"delete FROM mantis_project_hierarchy_mantis");
            db.executaQuery(consulta3);
        }
        public void atualizacaoCargaMarcadores()
        {
             string query11 = string.Format(@"update mantis_tag_mantis set NAME = 'marcadorTeste' where description = 'descricao'");
                    db.executaQuery(query11);
             string query12 = string.Format(@"update mantis_tag_mantis set description = 'descricao2' where NAME = 'marcadorTeste2'");
                    db.executaQuery(query12);
        }

        //pesquisas-------------------
        public string retornaStatusUsuario(string usuario)
        {
            string consulta = string.Format(@"SELECT enabled FROM mantis_user_mantis where username = '{0}'", usuario);
            List<string> resultado = db.retornaDadosQuery(consulta);
            return resultado[0];
        }
        public string retornaNivelAcesso(string usuario)
        {
            string consulta = string.Format(@"SELECT access_level FROM mantis_user_mantis where username = '{0}'", usuario);
            List<string> resultado = db.retornaDadosQuery(consulta);
            return resultado[0];
        }
        public string retornaEmailUsuario(string usuario)
        {
            string consulta = string.Format(@"SELECT email FROM mantis_user_mantis where username = '{0}'", usuario);
            List<string> resultado = db.retornaDadosQuery(consulta);
            return resultado[0];
        }

        public string retornaUsuario(string usuario)
        {
            string consulta = string.Format(@"select username from mantis_user_mantis where username = '{0}'", usuario);
            List<string> resultado = db.retornaDadosQuery(consulta);
            if(resultado == null)
            {
                return null;
            }
            else
            {
                return resultado[0];
            }
        }
        public string retornaNomeUsuario(string email)
        {
            string consulta = string.Format(@"SELECT username FROM mantis_user_mantis where email = '{0}'", email);
            List<string> resultado = db.retornaDadosQuery(consulta);
            return resultado[0];
        }
        public string retornaNomeRealUsuario(string email)
        {
            string consulta = string.Format(@"SELECT realname FROM mantis_user_mantis where email = '{0}'", email);
            List<string> resultado = db.retornaDadosQuery(consulta);
            return resultado[0];
        }
        public string retornaidUsuario(string nome)
        {
            string consulta = string.Format(@"SELECT id FROM mantis_user_mantis where username = '{0}'", nome);
            List<string> resultado = db.retornaDadosQuery(consulta);
            return resultado[0];
        }
        public string retornaStatusProjeto(string projeto)
        {
            string consulta = string.Format(@"SELECT status FROM mantis_project_mantis WHERE NAME = '{0}'", projeto);
            List<string> resultado = db.retornaDadosQuery(consulta);
            return resultado[0];
        }
        public string retornaVisibilidadeProjeto(string projeto)
        {
            string consulta = string.Format(@"SELECT view_state FROM mantis_project_mantis WHERE NAME = '{0}'", projeto);
            List<string> resultado = db.retornaDadosQuery(consulta);
            return resultado[0];
        }
        public List<string> retornaDadosProjeto(string projeto)
        {
            string consulta = string.Format(@"SELECT * FROM mantis_project_mantis WHERE NAME = '{0}'", projeto);
            List<string> resultado = db.retornaDadosQuery(consulta);
            if (resultado == null)
            {
                return null;
            }
            else
            {
                return resultado;
            }
        }
        public List<string> retornaVinculoSubProjeto(string idPai, string idFilho)
        {
            string consulta = string.Format(@"SELECT * FROM mantis_project_hierarchy_mantis WHERE child_id = {0} AND parent_id= {1}", idFilho, idPai);
            List<string> resultado = db.retornaDadosQuery(consulta);
            if (resultado == null)
            {
                return null;
            }
            else
            {
                return resultado;
            }
        }
        public List<string> retornaMarcadorPorNome(string nome)
        {
            string consulta = string.Format(@"SELECT * FROM mantis_tag_mantis WHERE NAME = '{0}'", nome);
            List<string> resultado = db.retornaDadosQuery(consulta);
            return resultado;
        }
        public List<string> retornaMarcadorPorDescricao(string descricao)
        {
            string consulta = string.Format(@"SELECT * FROM mantis_tag_mantis WHERE description = '{0}'", descricao);
            List<string> resultado = db.retornaDadosQuery(consulta);
            return resultado;
        }

        //Tarefas
        public List<string> retornaTarefaCriadaPorNome(string nomeTarefa)
        {
            string consulta = string.Format(@"SELECT * from mantis_bug_mantis bm
                                            INNER join mantis_bug_text_mantis btm
                                            ON bm.id = btm.id
                                            WHERE SUMMARY = '{0}'", nomeTarefa);
            List<string> resultado = db.retornaDadosQuery(consulta);
            return resultado;
        }
        public List<string> retornaTarefaCriadaPorId(string id)
        {
            string consulta = string.Format(@"SELECT * from mantis_bug_mantis bm
                                            INNER join mantis_bug_text_mantis btm
                                            ON bm.id = btm.id
                                            WHERE bm.ID = '{0}'", id);
            List<string> resultado = db.retornaDadosQuery(consulta);
            return resultado;
        }
        public List<string> retornaTagTarefa(int id)
        {
            string consulta = string.Format(@"SELECT * from mantis_bug_tag_mantis WHERE bug_id = '{0}'", id);
            List<string> resultado = db.retornaDadosQuery(consulta);
            return resultado;
        }
        public List<string> retornaRelacaoTarefa(int id)
        {
            string consulta = string.Format(@"SELECT * from mantis_bug_relationship_mantis WHERE SOURCE_bug_id = '{0}' ORDER BY destination_bug_id desc", id);
            List<string> resultado = db.retornaDadosQuery(consulta);
            return resultado;
        }
    }
}
