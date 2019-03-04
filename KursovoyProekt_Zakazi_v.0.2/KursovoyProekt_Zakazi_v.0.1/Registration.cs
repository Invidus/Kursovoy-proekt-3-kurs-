using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursovoyProekt_Zakazi_v._0._1
{
    public partial class Registration : Form
    {
        Form1 f1 = new Form1();
        public Registration()
        {
            InitializeComponent();
        }
        private void Registration_Load(object sender, EventArgs e)
        {
            SQLConnect SQLC = new SQLConnect();
            SQLC.Connect();
        }
        public void Reg()
        {
                RegistrationC RC = new RegistrationC();
                RC.Request("INSERT INTO [Client](Surname,First_name,Last_name,Phone,Client_address,Login,Password)values(@Surname,@First_name,@Last_name,@Phone,@Client_address,@Login,@Password)", textBox1.Text,textBox2.Text, textBox9.Text, textBox8.Text, textBox7.Text, textBox6.Text, textBox5.Text);
                if (RC.Acc() == 1)
                {
                    MessageBox.Show("Вы успешно зарегистрировались в системе");
                    Close();
                }
                else
                {
                    if (RC.Acc() == 0)
                    {
                        label9.Visible = true;
                        label9.Text = "Все поля должны быть заполнены.";
                    }
                }          
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Reg();
        }
        private void button1_Click(object sender, EventArgs e)// Закрытие окошка регистрации
        {
            if (!string.IsNullOrEmpty(textBox2.Text) || !string.IsNullOrWhiteSpace(textBox2.Text) ||
                !string.IsNullOrEmpty(textBox1.Text) || !string.IsNullOrWhiteSpace(textBox1.Text) ||
                !string.IsNullOrEmpty(textBox9.Text) || !string.IsNullOrWhiteSpace(textBox9.Text) ||
                !string.IsNullOrEmpty(textBox8.Text) || !string.IsNullOrWhiteSpace(textBox8.Text) ||
                !string.IsNullOrEmpty(textBox7.Text) || !string.IsNullOrWhiteSpace(textBox7.Text) ||
                !string.IsNullOrEmpty(textBox6.Text) || !string.IsNullOrWhiteSpace(textBox6.Text))
            {
                if (MessageBox.Show("Вы точно хотите выйти из системы?", "Предупреждение",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Close();
                }                
            }Close();
        }
    }
}
/*
               SqlCommand command1 = new SqlCommand("INSERT INTO [Client](Surname,First_name,Last_name,Phone,Client_address,Login,Password)values(@Surname,@First_name,@Last_name,@Phone,@Client_address,@Login,@Password)");
               command1.Connection = connection;
               command1.Parameters.AddWithValue("@Surname", textBox2.Text);
               command1.Parameters.AddWithValue("@First_name", textBox1.Text);
               command1.Parameters.AddWithValue("@Last_name", textBox9.Text);
               command1.Parameters.AddWithValue("@Phone", textBox8.Text);
               command1.Parameters.AddWithValue("@Client_address", textBox5.Text);
               command1.Parameters.AddWithValue("@Login", textBox7.Text);
               command1.Parameters.AddWithValue("@Password", textBox6.Text);
               command1.ExecuteNonQuery();
               MessageBox.Show("Вы успешно зарегистрировались в системе");
               this.Close();
           }
           else
           {
               label9.Visible = true;
               label9.Text = "Все поля должны быть заполнены.";
           }*/
