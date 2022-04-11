using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hotels
{
    public class WorkDB
    {
        string connectionString = "Server=DESKTOP-TNC55TL;Database=master;Trusted_Connection=True;";

        async public void Create()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();   // открываем подключение

                SqlCommand command = new SqlCommand();
                command.CommandText = "CREATE DATABASE Hotels";
                command.Connection = connection;
                await command.ExecuteNonQueryAsync();
                MessageBox.Show("База данных создана");
            }
        }
           

    }
}
