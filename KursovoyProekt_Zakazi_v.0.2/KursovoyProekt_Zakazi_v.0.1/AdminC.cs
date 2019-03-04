using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace KursovoyProekt_Zakazi_v._0._1
{
    class AdminC
    {

        public static string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=G:\\Download\\Dev\\KursovoyProekt_Zakazi_v.0.2\\KursovoyProekt_Zakazi_v.0.1\\Database1.mdf;Integrated Security=True";
        public SqlConnection connection = new SqlConnection(ConnectionString);
        public SqlConnection con = new SqlConnection(ConnectionString);
        public string Zapros = "SELECT * FROM Client";
        ClientLK CL = new ClientLK();
        SQLConnect SQ = new SQLConnect();
        public DataTable ReadinessStat(string o)
        {
            SQ.Connect();
            string req = "select Order_number,Id,Date_order,Readiness_status,Products from Client join Order2 on Client.Id1 = Order2.Id where Login = '"+o +"'";
            SqlDataAdapter ad = new SqlDataAdapter(req, SQ.connection);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            SQ.connection.Close();
            return dt;
        }
        public void SetReadyOrder(int o)
        {
            SQ.Connect();
            
            SqlCommand command = new SqlCommand("UPDATE Order2 SET Readiness_status ='Gotovo ' where Order_number ='" + o + "'",SQ.connection);
            SqlDataReader sqlReader1 = command.ExecuteReader();
            SqlCommand cm = new SqlCommand("Delete from Order1 where Order_number ='" + o + "'", SQ.connection);
            sqlReader1 = cm.ExecuteReader();
            sqlReader1.Close();
            SQ.connection.Close();
        }
        public DataTable Inventory()
        {
            AdminLK ALK = new AdminLK();
            SQ.Connect();
            string t1 = "select * from Order2";
            SqlDataAdapter ad = new SqlDataAdapter(t1,SQ.connection);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            SQ.connection.Close();
            return dt;
        }
        public void DeleteClient(string request)
        {
            connection.Open();
            SqlCommand command = new SqlCommand(request, connection);
            SqlDataReader sqlReader = command.ExecuteReader();
            sqlReader.Close();
            connection.Close();               
        }
        public DataTable GetClient()
        {
            AdminLK ALK = new AdminLK();
            SQ.Connect();
            string t = "select * from Client";
            SqlDataAdapter ad = new SqlDataAdapter(t, SQ.connection);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            SQ.connection.Close();
            return dt;
        }
        public DataTable PendingOrders()
        {
            AdminLK ALK = new AdminLK();
            SQ.Connect();
            string req = "select * from Order1 where Readiness_status = 'Ne_gotovo'";
            SqlDataAdapter ad = new SqlDataAdapter(req, SQ.connection);
            DataTable dt1 = new DataTable();
            ad.Fill(dt1);
            SQ.connection.Close();
            return dt1;
        }
        public DataTable ComplitedOrders()
        {
            AdminLK ALK = new AdminLK();
            SQ.Connect();
            string req = "select * from Order2 where Readiness_status = 'Gotovo'";
            SqlDataAdapter ad = new SqlDataAdapter(req, SQ.connection);
            DataTable dt1 = new DataTable();
            ad.Fill(dt1);
            SQ.connection.Close();
            return dt1;
        }
        public DataTable Order()
        {
            AdminLK ALK = new AdminLK();
            SQ.Connect();
            string t = "select * from Order1";
            SqlDataAdapter ad = new SqlDataAdapter(t, SQ.connection);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            SQ.connection.Close();
            return dt;

          /*  SqlCommand SQC = new SqlCommand(t, SQ.connection);
            SqlDataReader sqlReader = SQC.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (sqlReader.Read())
            {
                data.Add(new string[5]);
                data[data.Count - 1][0] = sqlReader[0].ToString();
                data[data.Count - 1][1] = sqlReader[1].ToString();
                data[data.Count - 1][2] = sqlReader[2].ToString();
                data[data.Count - 1][3] = sqlReader[3].ToString();
                data[data.Count - 1][4] = sqlReader[4].ToString();
            }
            sqlReader.Close();
            SQ.connection.Close();
            //В цикле foreach добавляем новые строки в DataGridView с помощью метода Add. Элементами строки являются столбцы, заполняемые из строкового массива, содержащегося в конкретном элементе списка List:
            foreach (string[] s in data)
                ALK.dataGridView1.Rows.Add(s);
            // END GRID
            SQ.connection.Close();*/
        }
    }
}
