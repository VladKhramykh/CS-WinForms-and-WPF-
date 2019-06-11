using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OOP_08
{
    public class DBHandler
    {
        static string connectionString = @"Data Source=LENOVOIDEAPAD51;Initial Catalog=lab8;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public SqlConnection getConnection() => connection;
        public void connOpen()
        {
            MessageBox.Show("Open conn");
            connection.Open();
        }
        public void connClose()
        {            
            connection.Close();
            MessageBox.Show("Close conn");
        }
    }
}
