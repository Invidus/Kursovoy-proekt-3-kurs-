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
    public partial class UpdateInfoC : Form
    {
        public string s0, s1, s2, s3, s4, s5, s6;
        public string Zapros;
        public int o1;
        UpdateInfoClass UICC = new UpdateInfoClass();
        public UpdateInfoC()
        {
            InitializeComponent();
        }
        public void ChInfo()
        {
            ClientLK a12 = Owner as ClientLK;
            if (a12 != null)
            {
                string ss = a12.label2.Text;
                UICC.CheInfo(textBox1.Text, textBox2.Text, textBox9.Text, textBox8.Text, textBox7.Text, textBox6.Text, textBox5.Text,ss);
                if (UICC.GetN() == 1) { MessageBox.Show("Данные успешно изменены!"); }
            }

        }
        private void UpdateInfoC_Load(object sender, EventArgs e)
        {
            
                textBox1.Text = "Оставьте поле нетронутым, если не хотите его менять";
            textBox1.ForeColor = SystemColors.ButtonShadow;
            textBox2.Text = "Оставьте поле нетронутым, если не хотите его менять";
            textBox2.ForeColor = SystemColors.ButtonShadow;
            textBox8.Text = "Оставьте поле нетронутым, если не хотите его менять";
            textBox8.ForeColor = SystemColors.ButtonShadow;
            textBox7.Text = "Оставьте поле нетронутым, если не хотите его менять";
            textBox7.ForeColor = SystemColors.ButtonShadow;
            textBox5.Text = "Оставьте поле нетронутым, если не хотите его менять";
            textBox5.ForeColor = SystemColors.ButtonShadow;
            textBox6.Text = "Оставьте поле нетронутым, если не хотите его менять";
            textBox6.ForeColor = SystemColors.ButtonShadow;
            textBox9.Text = "Оставьте поле нетронутым, если не хотите его менять";
            textBox9.ForeColor = SystemColors.ButtonShadow;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            // смена текста
            textBox1.ForeColor = SystemColors.WindowText;
            textBox1.Text = null;
            s0 = textBox1.Text;
            //
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.ForeColor = SystemColors.WindowText;
            textBox2.Text = null;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            s0 = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            s1 = textBox2.Text;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            s2 = textBox9.Text;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            s3 = textBox8.Text;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            s4 = textBox7.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            s5 = textBox6.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            s6 = textBox5.Text;
        }

        private void textBox9_Click(object sender, EventArgs e)
        {
            textBox9.ForeColor = SystemColors.WindowText;
            textBox9.Text = null;
           
        }

        private void textBox8_Click(object sender, EventArgs e)
        {
            textBox8.ForeColor = SystemColors.WindowText;
            textBox8.Text = null;
           
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            textBox7.ForeColor = SystemColors.WindowText;
            textBox7.Text = null;
           

        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            textBox6.ForeColor = SystemColors.WindowText;
            textBox6.Text = null;
           
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            textBox5.ForeColor = SystemColors.WindowText;
            textBox5.Text = null;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {// ПРОВЕРКА ПО ЛОГИНУ
            ChInfo();
            Close();
        }
    }
}
/*

           if (s0 != "Оставьте поле нетронутым, если не хотите его менять")
           {
               ClientLK a12 = this.Owner as ClientLK;
               if (a12 != null)
               {
                   s0 = textBox1.Text;
                   ss = a12.label2.Text;
                   connection.Open();
                   string Zapros = "UPDATE Client SET First_name ='" + s0 + "' where Login ='" + ss + "'";
                   SqlCommand commmand = new SqlCommand(Zapros, connection);
                   SqlDataReader sqlReader = commmand.ExecuteReader();
                   sqlReader.Close();
                   connection.Close();
               }

           }
           if (s1 != "Оставьте поле нетронутым, если не хотите его менять")
           {
               ClientLK a12 = this.Owner as ClientLK;
               if (a12 != null)
               {
                   s1 = textBox2.Text;
                   ss = a12.label2.Text;
                   connection.Open();
                   string Zapros = "UPDATE Client SET Surname ='" + s1 + "' where Login ='" + ss + "'";
                   SqlCommand commmand = new SqlCommand(Zapros, connection);
                   SqlDataReader sqlReader = commmand.ExecuteReader();
                   sqlReader.Close();
                   connection.Close();
               }
           }
           if (s2 != "Оставьте поле нетронутым, если не хотите его менять")
           {
               ClientLK a12 = this.Owner as ClientLK;
               if (a12 != null)
               {
                   s2 = textBox9.Text;
                   ss = a12.label2.Text;
                   connection.Open();
                   string Zapros = "UPDATE Client SET Last_name ='" + s2 + "' where Login ='" + ss + "'";
                   SqlCommand commmand = new SqlCommand(Zapros, connection);
                   SqlDataReader sqlReader = commmand.ExecuteReader();
                   sqlReader.Close();
                   connection.Close();
               }
           }
           if (s3 != "Оставьте поле нетронутым, если не хотите его менять")
           {
               ClientLK a12 = this.Owner as ClientLK;
               if (a12 != null)
               {
                   s3 = textBox8.Text;
                   ss = a12.label2.Text;
                   connection.Open();
                   string Zapros = "UPDATE Client SET Phone ='" + s3 + "' where Login ='" + ss + "'";
                   SqlCommand commmand = new SqlCommand(Zapros, connection);
                   SqlDataReader sqlReader = commmand.ExecuteReader();
                   sqlReader.Close();
                   connection.Close();
               }
           }
           if (s4 != "Оставьте поле нетронутым, если не хотите его менять")
           {
               ClientLK a12 = this.Owner as ClientLK;
               if (a12 != null)
               {
                   s4 = textBox7.Text;
                   ss = a12.label2.Text;
                   connection.Open();
                   string Zapros = "UPDATE Client SET Login ='" + s4 + "' where Login ='" + ss + "'";
                   SqlCommand commmand = new SqlCommand(Zapros, connection);
                   SqlDataReader sqlReader = commmand.ExecuteReader();
                   sqlReader.Close();
                   connection.Close();
               }
           }
           if (s5 != "Оставьте поле нетронутым, если не хотите его менять")
           {
               ClientLK a12 = this.Owner as ClientLK;
               if (a12 != null)
               {
                   s5 = textBox6.Text;
                   ss = a12.label2.Text;
                   connection.Open();
                   string Zapros = "UPDATE Client SET Password ='" + s5 + "' where Login ='" + ss + "'";
                   SqlCommand commmand = new SqlCommand(Zapros, connection);
                   SqlDataReader sqlReader = commmand.ExecuteReader();
                   sqlReader.Close();
                   connection.Close();
               }
           }
           if (s6 != "Оставьте поле нетронутым, если не хотите его менять")
           {
               ClientLK a12 = this.Owner as ClientLK;
               if (a12 != null)
               {
                   s6 = textBox5.Text;
                   ss = a12.label2.Text;
                   connection.Open();
                   string Zapros = "UPDATE Client SET Client_address ='" + s6 + "' where Login ='" + ss + "'";
                   SqlCommand commmand = new SqlCommand(Zapros, connection);
                   SqlDataReader sqlReader = commmand.ExecuteReader();
                   sqlReader.Close();
                   connection.Close();
               }
           }MessageBox.Show("Данные успешно изменены!");*/
