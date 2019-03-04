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
    public partial class ForgotPassword : Form
    {
        ForgotPassC FPS = new ForgotPassC();
        public ForgotPassword()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FPS.Remembered("SELECT Login,Password FROM Client where First_name = '" + textBox1.Text + "' and Surname = '" + textBox2.Text + "'", textBox1.Text,textBox2.Text);
            MessageBox.Show("Логин: " + FPS.s10 + "  Пароль: " + FPS.GetP());
        }
        private void ForgotPassword_Load(object sender, EventArgs e)
        {// login = 1 pass = 0
         Form1 f1 = this.Owner as Form1;
         label4.Visible = true; label1.Visible = true; textBox1.Visible = true; textBox2.Visible = true;           
        }
    }
}
