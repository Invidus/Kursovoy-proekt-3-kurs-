using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace KursovoyProekt_Zakazi_v._0._1
{
    
    public partial class Form1 : Form
    {
        public SQLConnect SQ = new SQLConnect();
        public string Peredat;
        public int a=2;
        public int Errora;
        public Form1()            
        {
            InitializeComponent();
        }
           private void Form1_Load(object sender, EventArgs e)
        {
            ClientLK CLK = new ClientLK();
            CLK.Owner = this;
             textBox1.Text = "Логин";
             textBox1.ForeColor = SystemColors.ButtonShadow;
             textBox2.Text = "Пароль";
             textBox2.ForeColor = SystemColors.ButtonShadow;
        }
        private void textBox1_Click(object sender, EventArgs e)// Скрытие Логина и пароля 
        {

            if (textBox1.Text == "Логин" || textBox2.Text == "Пароль")
            {
                textBox1.ForeColor = SystemColors.WindowText;
                label1.Visible = true;
                textBox1.Text = null;
                textBox2.ForeColor = SystemColors.WindowText;
                label2.Visible = true;
                textBox2.Text = null;
                textBox2.UseSystemPasswordChar = true;
            }

        }
        private void textBox2_Click(object sender, EventArgs e) // Скрытие Логина и пароля 
        {
            if (textBox2.Text == "Пароль"|| textBox1.Text =="Логин")
            {
                textBox2.ForeColor = SystemColors.WindowText;
                label2.Visible = true;
                textBox2.Text = null;
                textBox2.UseSystemPasswordChar = true;
                textBox1.ForeColor = SystemColors.WindowText;
                label1.Visible = true;
                textBox1.Text = null;
            }
        }
        private void Form1_Activated(object sender, EventArgs e)
        {
            button1.Focus();
        }
        private void label5_Click(object sender, EventArgs e) // Срабатывает при нажатии забыл пароль
        {
            a = 0;
            ForgotPassword FP = new ForgotPassword();
            FP.Owner = this;
            FP.Visible = true;
        }
        private void label4_Click(object sender, EventArgs e)// Срабатывает при нажатии регистрация
        {
            Registration Reg = new Registration();
            Reg.Visible = true;
        }
        private void button1_Click(object sender, EventArgs e)// Коннект бд и проверка логина, пароля
        {
            if (textBox1.Text == "" && textBox2.Text == ""|| textBox1.Text =="Логин"  && textBox2.Text == "Пароль")
            {
                MessageBox.Show("Введите данные!");
            }
            else { if (textBox1.Text == "" || textBox1.Text == "Логин")
                { MessageBox.Show("Введите логин");
                } else {
                    if (textBox2.Text == ""|| textBox2.Text == "Пароль") { MessageBox.Show("Введите пароль"); }
                    else if (textBox1.Text == "admin")
                    {                        
                        SQ.Connect();
                        SQ.LoginA("select Password from Admin1", textBox1.Text, textBox2.Text);
                        if (SQ.Err() == 1) { MessageBox.Show("Неверный логин или пароль!", "Внимание!"); } else { if (SQ.Err() == 0) { Visible = false; } }
                    }
                    else
                    {                        
                        SQ.Connect();
                        SQ.LoginC("select Login,Password from Client where Login ='" + textBox1.Text + "' and Password = '" + textBox2.Text + "'", textBox1.Text, textBox2.Text);
                        if (SQ.Er21() == 2) { MessageBox.Show("Неверный логин или пароль!", "Внимание!"); } else { if (SQ.Err() == 0) { Visible = false; } }
                    }
                }
            }           
        }
    }
}
/* string s01 = textBox1.Text;
 string s11 = textBox2.Text;
 connection.Open();
 string zapros1 = "select Login,Password from Client where Login ='" + s01 + "' and Password = '" + s11 + "'";
 SqlCommand commmand = new SqlCommand(zapros1, connection);

 SqlDataReader sqlReader = commmand.ExecuteReader();
 while (sqlReader.Read())
 {
     if (s01 == sqlReader[0].ToString() && s11 == sqlReader[1].ToString())
     {
         ClientLK CLK = new ClientLK();
         CLK.Owner = this;
         CLK.Visible = true;
         Visible = false;

     }
     else
     {
         MessageBox.Show("Неверный логин или пароль!", "Внимание!");
         // Не срабатывает, хз поч
     }

 }
 sqlReader.Close();*/
