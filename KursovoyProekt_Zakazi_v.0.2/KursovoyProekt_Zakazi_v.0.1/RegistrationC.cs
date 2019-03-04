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
    public class RegistrationC
    {
        public string s;
        public int p;
        SqlCommand commmand = new SqlCommand();
        SqlConnection SQQ = new SqlConnection();
        Registration R = new Registration();
        public RegistrationC()// konstruktor 
        {
            p = 0;
            s = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=G:\\Download\\Dev\\KursovoyProekt_Zakazi_v.0.2\\KursovoyProekt_Zakazi_v.0.1\\Database1.mdf;Integrated Security=True";
        }
        public void Request(string req, string name, string fam, string otch, string phone, string login,string pass,string address)
        {
            SQQ = new SqlConnection(s);
            SQQ.Open();
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name) &&
            !string.IsNullOrEmpty(fam) && !string.IsNullOrWhiteSpace(fam) &&
            !string.IsNullOrEmpty(otch) && !string.IsNullOrWhiteSpace(otch) &&
            !string.IsNullOrEmpty(phone) && !string.IsNullOrWhiteSpace(phone) &&
            !string.IsNullOrEmpty(login) && !string.IsNullOrWhiteSpace(login) &&
            !string.IsNullOrEmpty(address) && !string.IsNullOrWhiteSpace(address) &&
            !string.IsNullOrEmpty(pass) && !string.IsNullOrWhiteSpace(pass))
            {
                SqlCommand command1 = new SqlCommand("INSERT INTO [Client](Surname,First_name,Last_name,Phone,Client_address,Login,Password)values(@Surname,@First_name,@Last_name,@Phone,@Client_address,@Login,@Password)");
                command1.Connection = SQQ;
                command1.Parameters.AddWithValue("@Surname", fam);
                command1.Parameters.AddWithValue("@First_name", name);
                command1.Parameters.AddWithValue("@Last_name", otch);
                command1.Parameters.AddWithValue("@Phone", phone);
                command1.Parameters.AddWithValue("@Client_address", address);
                command1.Parameters.AddWithValue("@Login", login);
                command1.Parameters.AddWithValue("@Password", pass);
                command1.ExecuteNonQuery();
                p = 1;
                R.Close();
            }
            else { p = 0; }
        }
        public int Acc()
        {
            return p;
        }
    }
}
