using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Threading.Tasks;

namespace KursovoyProekt_Zakazi_v._0._1
{
    public class SQLConnect
    {
        public string connectRow; 
        public string request;
        public string Luli;
        public SqlDataReader sqlReader;
        public int Error { get; set; }
        public int Er1 { get; set; }
        public SqlConnection connection;
        public SQLConnect()// konstruktor 
        {
            Er1 = 0;
            Error = 0;
            connectRow = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=G:\\Download\\Dev\\KursovoyProekt_Zakazi_v.0.2\\KursovoyProekt_Zakazi_v.0.1\\Database1.mdf;Integrated Security=True";
        }
        public void Connect()//MEtod prisoed k bd i vipolneniya zaprosa
        {
            connection = new SqlConnection(connectRow);
            connection.Open();
        }
        public void LoginA(string request, string s0, string s1)
        {
                SqlCommand commmand = new SqlCommand(request, connection);
                sqlReader = commmand.ExecuteReader();
                while (sqlReader.Read())
                {
                    if (s1 == sqlReader[0].ToString())
                    {
                    AdminLK ALK = new AdminLK();
                    ALK.Visible = true;
                    Error = 0;
                    }
                    else
                    {
                        Error = 1;
                    }
                }
                sqlReader.Close();            
        }
        public void LoginC(string request, string s0, string s1)
        {
            SqlCommand commmand = new SqlCommand(request, connection);
            sqlReader = commmand.ExecuteReader();

            while (sqlReader.Read())
            {                
                if (s0 == sqlReader[0].ToString() && s1 == sqlReader[1].ToString())
                {
                    ClientLK CLK = new ClientLK();                    
                    CLK.Visible = true;
                    CLK.label2.Text = s0;
                    CLK.label1.Text = "Личный кабинет ";
                    Er1 = 0;
                }
                else
                {
                    Er1 = 2;                   
                }
            }
            sqlReader.Close();
        }
        public int Err()// Отправка ошибки
        {
            return Error;
        }
        public int Er21()
        {
            return Er1;
        }
    }
}



/* Код коннекта и проверки
// Connect      
string s0 = textBox1.Text;
string s1 = textBox2.Text;
if (s0 == "admin")
{
    string zapros = "select Password from Admin1";
    SqlCommand commmand = new SqlCommand(zapros, connection);
    SqlDataReader sqlReader = commmand.ExecuteReader();
    while (sqlReader.Read())
    {
        if (s1 == sqlReader[0].ToString())
        {
            AdminLK ALK = new AdminLK();
            ALK.Owner = this;
            ALK.Visible = true;
            this.Visible = false;
        }
        else
        {
            MessageBox.Show("Неверный логин или пароль!", "Внимание!");
        }
    }
    sqlReader.Close();
}
else // Проверка логина и пароля пользователя 
{
    string s01 = textBox1.Text;
    string s11 = textBox2.Text;

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
    sqlReader.Close();
}
*/
