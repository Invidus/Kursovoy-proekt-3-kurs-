using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursovoyProekt_Zakazi_v._0._1
{
    public partial class Sclad : Form
    {
        public Sclad()
        {
            InitializeComponent();
        }
        AdminC AC = new AdminC();
        private void Sclad_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AdminLK main = this.Owner as AdminLK;
            dataGridView1.DataSource = AC.Inventory();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AC.SetReadyOrder(int.Parse(dataGridView1.SelectedCells[0].Value.ToString()));
            MessageBox.Show("Заказ готов!");
            dataGridView1.DataSource = AC.Inventory();
        }
    }
}
