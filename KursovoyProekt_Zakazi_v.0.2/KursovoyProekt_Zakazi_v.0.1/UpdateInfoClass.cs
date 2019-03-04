using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace KursovoyProekt_Zakazi_v._0._1
{
    class UpdateInfoClass
    {
        public SqlConnection connection;
        public int p;
        public string ConnectionString;

        public UpdateInfoClass()
        {
            ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=G:\\Download\\Dev\\KursovoyProekt_Zakazi_v.0.2\\KursovoyProekt_Zakazi_v.0.1\\Database1.mdf;Integrated Security=True";
            p = 0;
        }
        public void CheInfo(string s0,string s1, string s2, string s3, string s4, string s5, string s6, string ss)
        {
            connection = new SqlConnection(ConnectionString);
            if (s0 != "Оставьте поле нетронутым, если не хотите его менять")
            {

                    connection.Open();
                    string Zapros = "UPDATE Client SET First_name ='" + s0 + "' where Login ='" + ss + "'";
                    SqlCommand commmand = new SqlCommand(Zapros, connection);
                    SqlDataReader sqlReader = commmand.ExecuteReader();
                    sqlReader.Close();
                    connection.Close();
                

            }
            if (s1 != "Оставьте поле нетронутым, если не хотите его менять")
            {
               
               
                    connection.Open();
                    string Zapros = "UPDATE Client SET Surname ='" + s1 + "' where Login ='" + ss + "'";
                    SqlCommand commmand = new SqlCommand(Zapros, connection);
                    SqlDataReader sqlReader = commmand.ExecuteReader();
                    sqlReader.Close();
                    connection.Close();
                
            }
            if (s2 != "Оставьте поле нетронутым, если не хотите его менять")
            {
     
                    connection.Open();
                    string Zapros = "UPDATE Client SET Last_name ='" + s2 + "' where Login ='" + ss + "'";
                    SqlCommand commmand = new SqlCommand(Zapros, connection);
                    SqlDataReader sqlReader = commmand.ExecuteReader();
                    sqlReader.Close();
                    connection.Close();
                
            }
            if (s3 != "Оставьте поле нетронутым, если не хотите его менять")
            {

                    connection.Open();
                    string Zapros = "UPDATE Client SET Phone ='" + s3 + "' where Login ='" + ss + "'";
                    SqlCommand commmand = new SqlCommand(Zapros, connection);
                    SqlDataReader sqlReader = commmand.ExecuteReader();
                    sqlReader.Close();
                    connection.Close();
                
            }
            if (s4 != "Оставьте поле нетронутым, если не хотите его менять")
            {

                    connection.Open();
                    string Zapros = "UPDATE Client SET Login ='" + s4 + "' where Login ='" + ss + "'";
                    SqlCommand commmand = new SqlCommand(Zapros, connection);
                    SqlDataReader sqlReader = commmand.ExecuteReader();
                    sqlReader.Close();
                    connection.Close();
                
            }
            if (s5 != "Оставьте поле нетронутым, если не хотите его менять")
            {

                    connection.Open();
                    string Zapros = "UPDATE Client SET Password ='" + s5 + "' where Login ='" + ss + "'";
                    SqlCommand commmand = new SqlCommand(Zapros, connection);
                    SqlDataReader sqlReader = commmand.ExecuteReader();
                    sqlReader.Close();
                    connection.Close();
                
            }
            if (s6 != "Оставьте поле нетронутым, если не хотите его менять")
            {

                    connection.Open();
                    string Zapros = "UPDATE Client SET Client_address ='" + s6 + "' where Login ='" + ss + "'";
                    SqlCommand commmand = new SqlCommand(Zapros, connection);
                    SqlDataReader sqlReader = commmand.ExecuteReader();
                    sqlReader.Close();
                    connection.Close();
                
            }
            p = 1;
        }public int GetN()
        {
            return p;
        }
    }
}
