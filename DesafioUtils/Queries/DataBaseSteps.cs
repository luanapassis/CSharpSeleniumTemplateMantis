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
            string consulta1 = string.Format(@"select username from mantis_user_table where username = 'usuario1'");
            List<string> resultado1 = db.retornaDadosQuery(consulta1);
            if(resultado1 == null)
            {
                string query1 = string.Format(@" INSERT INTO mantis_user_table ( username, realname, email,
                PASSWORD, enabled, protected, access_level, login_count, lost_password_request_count, failed_login_count, cookie_string, last_visit, date_created)
                VALUES('usuario1', 'Teste','luana.assis1@gmail.com.br', 'e10adc3949ba59abbe56e057f20f883e', 1, 0, 90, 1, 0, 0, 'JCIfQbZ9Wdq0eONcOMkSOR17wMSjowjc68', 1574199190, 1574199190)");
                db.executaQuery(query1);
            }


            string consulta2 = string.Format(@"select username from mantis_user_table where username = 'usuario2'");
            List<string> resultado2 = db.retornaDadosQuery(consulta2);
            if (resultado2 == null)
            {
                string query2 = string.Format(@" INSERT INTO mantis_user_table ( username, realname, email,
                PASSWORD, enabled, protected, access_level, login_count, lost_password_request_count, failed_login_count, cookie_string, last_visit, date_created)
                VALUES('usuario2', 'Teste','luana.assis2@gmail.com.br', 'e10adc3949ba59abbe56e057f20f883e', 1, 0, 90, 1, 0, 0, 'JCIfQbZ9Wdq0eONcOMkSOR17wMSjowjc6L', 1574199190, 1574199190)");
                db.executaQuery(query2);
            }

            string consulta3 = string.Format(@"select username from mantis_user_table where username = 'luana.assis'");
            List<string> resultado3 = db.retornaDadosQuery(consulta3);
            if (resultado3 == null)
            {

                string query3 = string.Format(@" INSERT INTO mantis_user_table ( username, realname, email,
                PASSWORD, enabled, protected, access_level, login_count, lost_password_request_count, failed_login_count, cookie_string, last_visit, date_created)
                VALUES('luana.assis', 'Luana Assis','luana.assis@gmail.com.br', 'e10adc3949ba59abbe56e057f20f883e', 1, 0, 90, 1, 0, 0, 'JCIfQbZ9Wdq0eONcOMkSOR17wMSjowjc7L', 1574199190, 1574199190)");
                db.executaQuery(query3);
            }
        }
        public void cargaProjeto()
        {
            string consulta = string.Format(@"SELECT * FROM mantis_project_table WHERE NAME = 'Teste'");
            List<string> resultado = db.retornaDadosQuery(consulta);
            if (resultado == null)
            {
                string query = string.Format(@"INSERT INTO mantis_project_table ( name, status, enabled, view_state, access_min, file_path, description, category_id, inherit_global)
                                               VALUES('Teste', 10,1, 10, 10, '', '', 1, 1)");
                db.executaQuery(query);
            }
        }

    }
}
