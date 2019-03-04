using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Sql;
using System.Threading.Tasks;

namespace KursovoyProekt_Zakazi_v._0._1
{
    class ForgotPassC
    {
        public string connectRow;
        public string s10 { get; set; }
        string s11;
        public SqlConnection connection;
        public ForgotPassC()
        {
            s10 = "";
            s11 = "";
            connectRow = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=G:\\Download\\Dev\\KursovoyProekt_Zakazi_v.0.2\\KursovoyProekt_Zakazi_v.0.1\\Database1.mdf;Integrated Security=True";
        }
        public void Remembered(string request,string s0,string s1)
        {
            connectRow = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=G:\\Download\\Dev\\KursovoyProekt_Zakazi_v.0.2\\KursovoyProekt_Zakazi_v.0.1\\Database1.mdf;Integrated Security=True";
            connection = new SqlConnection(connectRow);
            connection.Open();
            SqlCommand command = new SqlCommand(request, connection);
            SqlDataReader sqlReader = command.ExecuteReader();
            while (sqlReader.Read())
            {
                s10 = sqlReader[0].ToString();
                s11 = sqlReader[1].ToString();
            }
            sqlReader.Close();
            connection.Close();
        }
       /* public string GetL()
        {
            return s10;
        }*/
        public string GetP()
        {
            return s11;
        }
    }
}
