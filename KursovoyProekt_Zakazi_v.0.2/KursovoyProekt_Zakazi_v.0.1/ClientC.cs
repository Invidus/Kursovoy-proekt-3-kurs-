using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace KursovoyProekt_Zakazi_v._0._1
{
    public class ClientC
    {
        SQLConnect SQLC = new SQLConnect();
        public DateTime dt = DateTime.Now;
        public string rs;
        public void Basket()
        {
            SQLC.Connect();
            ClientLK CLK1 = new ClientLK();
            foreach (DataGridViewColumn c in CLK1.dataGridView1.Columns)
            {
                CLK1.dataGridView3.Columns.Add(c.Clone() as DataGridViewColumn);
            }
            string Zapros = "SELECT * FROM Product";
            SqlCommand command = new SqlCommand(Zapros, SQLC.connection);
            SqlDataReader sqlReader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();
            while (sqlReader.Read())
            {
                data.Add(new string[3]);
                data[data.Count - 1][0] = sqlReader[0].ToString();
                data[data.Count - 1][1] = sqlReader[1].ToString();
                data[data.Count - 1][2] = sqlReader[2].ToString();
            }
            sqlReader.Close();
            SQLC.connection.Close();
            //В цикле foreach добавляем новые строки в DataGridView с помощью метода Add. Элементами строки являются столбцы, заполняемые из строкового массива, содержащегося в конкретном элементе списка List:
            foreach (string[] s in data)
                CLK1.dataGridView1.Rows.Add(s);
            // END GRID
        }
        public void CreateOrder(string u,string products)
        {
            string tuy;
            SQLC.Connect();
            ClientLK Clk2 = new ClientLK();            
            rs = "Не_готово";
            SqlCommand command1 = new SqlCommand("select Id1 from Client where Login ='"+u+"'",SQLC.connection);
            SqlDataReader sqlReader1 = command1.ExecuteReader();
            sqlReader1.Read();
            tuy = sqlReader1[0].ToString();
            sqlReader1.Close();
            var y = dt.ToString("yyyy-MM-dd");
            SqlCommand command = new SqlCommand("insert into Order1(Id, Date_order, Readiness_status, Products)values(" + tuy + ", '" +y + "', 'Ne_gotovo', '" + products + "')", SQLC.connection);
            sqlReader1 = command.ExecuteReader();
            sqlReader1.Close();
            SQLC.connection.Close();

        }
    }
}
