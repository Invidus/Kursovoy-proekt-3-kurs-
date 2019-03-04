using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace KursovoyProekt_Zakazi_v._0._1
{
    public partial class AdminLK : Form
    {
        AdminC AC = new AdminC();
        Sclad SC = new Sclad();
        SQLConnect SQP = new SQLConnect();
        public AdminLK()
        {
            InitializeComponent();
        }
        public void GClient()//Заполнение таблицы
        {
            SQP.Connect();
            SqlCommand command = new SqlCommand("SELECT * FROM Client", SQP.connection);
            SqlDataReader sqlReader = command.ExecuteReader();           
            List<string[]> data = new List<string[]>();
            while (sqlReader.Read())
            {
                data.Add(new string[5]);
                data[data.Count - 1][0] = sqlReader[2].ToString();
                data[data.Count - 1][1] = sqlReader[1].ToString();
                data[data.Count - 1][2] = sqlReader[3].ToString();
                data[data.Count - 1][3] = sqlReader[4].ToString();
                data[data.Count - 1][4] = sqlReader[5].ToString();
            }
            sqlReader.Close();
            SQP.connection.Close();
            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                label1.Text = "Заказы ожидающие отправки на склад";
                button5.Enabled = true;
                button4.Enabled = false;
                dataGridView1.DataSource = AC.PendingOrders();
                groupBox1.Enabled = true;
                button4.Enabled = false;
                foreach (DataGridViewColumn c in dataGridView1.Columns)
                {
                    SC.dataGridView1.Columns.Add(c.Clone() as DataGridViewColumn);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sclad SC1 = new Sclad();
            SC1.Visible = true;
            button5.Enabled = false;
            button4.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label1.Text = "Выполненные заказы";
                button5.Enabled = false;
                button4.Enabled = false;
                dataGridView1.DataSource = AC.ComplitedOrders();
                groupBox1.Enabled = true;
                button4.Enabled = false;
                foreach (DataGridViewColumn c in dataGridView1.Columns)
                {
                    SC.dataGridView1.Columns.Add(c.Clone() as DataGridViewColumn);
                }
            }
        }

        private void AdminLK_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (MessageBox.Show("Вы точно хотите выйти из системы?", "Предупреждение",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else e.Cancel = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = AC.GetClient();
            label1.Text = "Зарегистрированные клиенты";
            // GClient();
            //AC.GetClient();
            groupBox1.Enabled = false;
            button4.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            button5.Enabled = true;
            label1.Text = "Заказы ожидающие отправки на склад";
            dataGridView1.DataSource = AC.Order();
            groupBox1.Enabled = true;
            radioButton2.Checked = true;
            button4.Enabled = false;
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                SC.dataGridView1.Columns.Add(c.Clone() as DataGridViewColumn);
            }
        }

        private void AdminLK_Load(object sender, EventArgs e)
        {

            Sclad SSS = new Sclad();
            SSS.Owner = this;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e) // Удаление данных
        {
            button5.Enabled = false;
            int pp = dataGridView1.CurrentRow.Index;
                string s5 = dataGridView1.Rows[pp].Cells[0].Value.ToString();
                string s6 = dataGridView1.Rows[pp].Cells[1].Value.ToString();
                AC.DeleteClient("DELETE FROM Client WHERE First_name = '" + s5 + "' and Surname = '" + s6 + "'");
            dataGridView1.Rows.Clear();
            GClient();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           SQP.Connect();
           ClientLK Clk2 = new ClientLK();
                     DateTime dt = DateTime.Now;
            var y = dt.ToString("yyyy-MM-dd");
            SqlCommand command = new SqlCommand("insert into Order2(Order_number,Id, Date_order, Readiness_status, Products)values(" +dataGridView1.SelectedCells[0].Value.ToString()+", " + dataGridView1.SelectedCells[1].Value.ToString() + ", '"+ y + "', 'Ne_gotovo', " + dataGridView1.SelectedCells[4].Value.ToString() + ")", SQP.connection);
            SqlDataReader sqlReader1 = command.ExecuteReader();
            sqlReader1.Close();
            SQP.connection.Close();
           //    sqlReader1.Close();
           //  SQP.connection.Close();
           //            SQLConnect SL = new SQLConnect();
           //            SL.Connect();
           //            button4.Enabled = false;
           //            SqlDataReader sqlReader1;
           //            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
           //            {
           //                int index = SC.dataGridView1.Rows.Add(r.Clone() as DataGridViewRow);

            //                foreach (DataGridViewCell o in r.Cells)
            //                {
            //                    SC.dataGridView1.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
            //                }
            //            }
            //            SqlCommand command = new SqlCommand("insert into Order2(Id, Date_order, Readiness_status, Products)values('"
            //+ dataGridView1.CurrentRow.Cells[4].Value + "'",SL.connection);

            //            sqlReader1 = command.ExecuteReader();
            //            sqlReader1.Close();
            //            SL.connection.Close();
            //            MessageBox.Show("Товар успешно добавлен на склад");
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
