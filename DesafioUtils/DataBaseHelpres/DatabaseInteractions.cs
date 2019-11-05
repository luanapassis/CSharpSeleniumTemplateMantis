using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace DesafioUtils.DataBaseHelpres
{
    public class DataBaseInteractions
    {
        public static MySqlConnection GetDBConnection()
        {
            string connectionString = "Server=" + ConfigurationManager.AppSettings["DatabaseServer"] + ";" +
                                      "Port=" + ConfigurationManager.AppSettings["Port"] + ";" +
                                      "Database=" + ConfigurationManager.AppSettings["DatabaseName"] + ";" +
                                      "UID=" + ConfigurationManager.AppSettings["DBUser"] + "; " +
                                      "Password=" + ConfigurationManager.AppSettings["DBPassword"] + ";" +
                                      "SslMode=" + ConfigurationManager.AppSettings["SslMode"];
            MySqlConnection connection = new MySqlConnection(connectionString);

            return connection;
        }


        public void DBRunQuery(string query)
        {

            //string x = "Server=192.168.99.100;Port = 3306; Database=bugtracker;UID=mantisbt;Password=mantisbt;SslMode=none";

            using (MySqlCommand cmd = new MySqlCommand(query, GetDBConnection()))
            {    //watch out for this SQL injection vulnerability below
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string someStringFromColumnZero = reader.GetString(0);
                    string someStringFromColumnOne = reader.GetString(1);
                    Console.WriteLine(someStringFromColumnZero + "," + someStringFromColumnOne);
                }
                cmd.Connection.Close();
            }

        }

        /*
        public void executaQuery(String query)
        {


            try
            {
                connection = getDBConnection();
                Console.WriteLine("Connecting to MySQL...");
                connection.Open();


                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " -- " + rdr[1]);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            connection.Close();
            Console.WriteLine("Done.");

            
            connection = getDBConnection();

            connection.Open();

            MySqlCommand cmd = new MySqlCommand(query, connection);
            
            cmd.CommandTimeout = Int32.Parse(ConfigurationManager.AppSettings["DBConnectionTimeout"]);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            
        }
       

       /*

        public List<string> retornaDadosQuery(String query)
        {

            DataSet ds = new DataSet();
            List<string> lista = new List<string>();


            using (SqlCommand cmd = new SqlCommand(query, getDBConnection()))
            {
                cmd.CommandTimeout = Int32.Parse(ConfigurationManager.AppSettings["DBConnectionTimeout"]);
                cmd.Connection.Open();
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                ds.Tables.Add(table);
                cmd.Connection.Close();
            }




            if (ds.Tables[0].Columns.Count == 0)
            {
                return null;
            }

            try
            {
                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                {
                    lista.Add(ds.Tables[0].Rows[0][i].ToString());
                }
            }
            catch (Exception)
            {

                return null;
            }

            return lista;
        }



        public List<string> retornaListaDadosQuery(String query)
        {

            DataSet ds = new DataSet();
            List<string> lista = new List<string>();

            using (SqlCommand cmd = new SqlCommand(query, getDBConnection()))
            {
                cmd.CommandTimeout = Int32.Parse(ConfigurationManager.AppSettings["DBConnectionTimeout"]);
                cmd.Connection.Open();
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                ds.Tables.Add(table);
                cmd.Connection.Close();
            }

            if (ds.Tables[0].Columns.Count == 0)
            {
                return null;
            }

            try
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        lista.Add(ds.Tables[0].Rows[i][j].ToString());
                    }
                }

            }
            catch (Exception)
            {

                return null;
            }
            return lista;
        }
        
    */
    }
}
