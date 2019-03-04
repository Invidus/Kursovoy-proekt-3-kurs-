using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Windows.Forms;

namespace KursovoyProekt_Zakazi_v._0._1
{
    public partial class ClientLK : Form
    {
        ClientC CC = new ClientC();
        SQLConnect SQLC = new SQLConnect();
        DataTable dtEvents;
        DataRow drEvents;
        public int a;
        public int c;
        public int b;
        public string s;
        public Form1 a1 = new Form1();
        public ClientLK()
        {
            InitializeComponent();
        }        
        private void ClientLK_Load(object sender, EventArgs e)
        {
            dataGridView2.Enabled = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            dataGridView1.ReadOnly = true;// Только чтение
            dataGridView2.ReadOnly = true;
            dataGridView3.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//Выбор всей строчки
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            SQLC.Connect();
            //CC.Basket();
            // Копирование шапок из верхнего ДГВ
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                dataGridView3.Columns.Add(c.Clone() as DataGridViewColumn);
            }           
            SqlCommand command = new SqlCommand("SELECT * FROM Product", SQLC.connection);
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
                dataGridView1.Rows.Add(s);
            // END GRID

            // с прошлой формы данные!!
            Form1 a1 = this.Owner as Form1;
            if (a1 != null)
            {
                s = a1.textBox1.Text;
                label1.Text = "Личный кабинет ";
                label2.Text = s;
            }
            //
        }
        private void ClientLK_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите выйти из системы?", "Предупреждение",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else e.Cancel = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            UpdateInfoC UI = new UpdateInfoC();
            UI.Owner = this;
            UI.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c = 1;
            button2.Enabled = true;
            button6.Enabled = true;
            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                int index = dataGridView3.Rows.Add(r.Clone() as DataGridViewRow);

                foreach (DataGridViewCell o in r.Cells)
                {
                    dataGridView3.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int ind = dataGridView3.SelectedCells[0].RowIndex;
                dataGridView3.Rows.RemoveAt(ind);
            }
            catch(Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int ind = dataGridView3.SelectedCells[0].RowIndex;
            dataGridView3.Rows.RemoveAt(ind);
            }
            catch(Exception ex) { MessageBox.Show("Ошибка: " + ex.Message); }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                int index = dataGridView3.Rows.Add(r.Clone() as DataGridViewRow);

                foreach (DataGridViewCell o in r.Cells)
                {

                    dataGridView3.Rows[index].Cells[o.ColumnIndex].Value = o.Value;

                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView2.Enabled = true;
            a = 2;
            dtEvents = new DataTable();
            dtEvents.Columns.Add("№ Заказа");
            dtEvents.Columns.Add("№ Доставки");
            drEvents = dtEvents.NewRow();
            drEvents[0] = b;
            drEvents[1] = a;
            dtEvents.Rows.Add(drEvents);
            dataGridView2.DataSource = dtEvents;//--!!*/
            dataGridView2.Columns[0].Width = 70;
            dataGridView2.Columns[1].Width = 70;
            if (c == 1 && radioButton2.Checked) { button4.Enabled = true; }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView2.Enabled = true;
            a = 1;
            dtEvents = new DataTable();
            dtEvents.Columns.Add("№ Заказа");
            dtEvents.Columns.Add("№ Доставки");
            drEvents = dtEvents.NewRow();
            drEvents[0] = b;
            drEvents[1] = a;
            dtEvents.Rows.Add(drEvents);
            dataGridView2.DataSource = dtEvents;//--!!*/
            dataGridView2.Columns[0].Width = 70;
            dataGridView2.Columns[1].Width = 70;
            if (c==1&&radioButton1.Checked) { button4.Enabled = true; }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView2.Enabled = true;
            a = 3;
            dtEvents = new DataTable();
            dtEvents.Columns.Add("№ Заказа");
            dtEvents.Columns.Add("№ Доставки");
            drEvents = dtEvents.NewRow();
            drEvents[0] = b;
            drEvents[1] = a;
            dtEvents.Rows.Add(drEvents);
            dataGridView2.DataSource = dtEvents;//--!!*/
            dataGridView2.Columns[0].Width = 70;
            dataGridView2.Columns[1].Width = 70;
            if (c == 1 && radioButton3.Checked) { button4.Enabled = true; }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            AdminC ACO = new AdminC();

            ReadinessStatus RS = new ReadinessStatus();
            RS.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView3.Rows.Count == 1) { MessageBox.Show("Пустой заказ, добавьте товар в корзину"); }
            else
            {
                b = int.Parse(File.ReadAllText(@"G:\\Download\\Dev\\KursovoyProekt_Zakazi_v.0.2\\B.txt", Encoding.Default));
                b++;
                File.WriteAllText(@"G:\\Download\Dev\\KursovoyProekt_Zakazi_v.0.2\\B.txt", b.ToString()); // Файл в котором хранится номер заказа.
                dataGridView2.Update();
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                button4.Enabled = false;
                string khj ="";
                string[] yu = new string[dataGridView3.RowCount];
                for (int i = 0; i < dataGridView3.RowCount - 1; i++)
                {
                    yu[i] = dataGridView3[0, i].Value.ToString() + " ";
                    khj+= yu[i];
                }
                CC.CreateOrder(label2.Text, khj);
                MessageBox.Show("Заказ отправлен в обработку");
            }
        }
    }
}

/* // Заполнение шапок в корзине
 dtEvents = new DataTable();
 dtEvents.Columns.Add("№ Продукта");
 dtEvents.Columns.Add("Название товара");
 dtEvents.Columns.Add("Цена");
 dtEvents.Columns.Add("Количество");
 //
 //Заполнение таблицы
 drEvents = dtEvents.NewRow();
 drEvents[0] = "№ Продукта";
 dtEvents.Rows.Add(drEvents);
 dataGridView3.DataSource = dtEvents;//--!!*/
//foreach (DataGridViewColumn c in dataGridView1.Columns)
//{
//    dataGridView3.Columns.Add(c.Clone() as DataGridViewColumn);
//}
////then you can copy the rows values one by one (working on the selectedrows collection)
//foreach (DataGridViewRow r in dataGridView1.SelectedRows)
//{
//    int index = dataGridView3.Rows.Add(r.Clone() as DataGridViewRow);
//    foreach (DataGridViewCell o in r.Cells)
//    {
//        dataGridView3.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
//    }
//}
//GRID
/*
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            object[] items = new object[row.Cells.Count];
                            if(dataGridView1.SelectedCells)
                            for (int i = 0; i < row.Cells.Count; i++)
                            {
                                items[i] = row.Cells[i].Value;
                            }
                            DataGridViewCell[] DGVC;
                            dataGridView1.SelectedCells.CopyTo(DGVC[]);
                            dataGridView3.Rows.Add(dataGridView1.SelectedCells.c);
                        }*/
//List<string[]> data1 = new List<string[]>();//хранение данных из списка -> корзин
//dataGridView3.Rows.Add(dataGridView1.SelectedRows.ToString());
//ConnectSQL();
////string Zapros = "Insert into Order1(Id,Date_order,Readiness_status)values("+rnds+", "+"'"++"'"+ ", 'Не_готово')";
//SqlCommand command = new SqlCommand(Zapros, connection);
//SqlDataReader sqlReader = command.ExecuteReader();
//sqlReader.Close();
//connection.Close();

// DataGridView1.Rows([строка]).Cells([столбец]).Value = "Данные"
//for (int intI = 0; intI < dataGridView3.Rows.Count; intI++)
//{
//    for (int intJ = intI + 1; intJ < dataGridView3.RowCount; intJ++)
//    {
//        if (dataGridView3.Rows[intJ].Cells[0].Value.ToString() == dataGridView3.Rows[intI].Cells[0].Value.ToString())
//        {
//            dataGridView3.Rows.RemoveAt(intJ);
//            intJ--;
//        }

//    }
//}

//then you can copy the rows values one by one (working on the selectedrows collection)