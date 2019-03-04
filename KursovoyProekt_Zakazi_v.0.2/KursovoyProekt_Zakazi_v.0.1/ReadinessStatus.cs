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
    public partial class ReadinessStatus : Form
    {
        AdminC AC = new AdminC();
        public string YU;
        public ReadinessStatus()
        {
            InitializeComponent();
        }

        private void ReadinessStatus_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") { MessageBox.Show("Введите логин!"); }
            else
            {
                YU = textBox1.Text;
                AdminC ACO = new AdminC();
                dataGridView1.DataSource = ACO.ReadinessStat(YU);
            }
        }
    }
}
