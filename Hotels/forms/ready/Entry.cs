using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace Hotels
{
    public partial class Entry : Form
    {
        public Entry()
        {
            InitializeComponent();
            
        }

       

        private void Entry_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*Form form = Application.OpenForms[0];
            form.Show();*/
        }

        private bool Check()
        {
            foreach (var element in panel2.Controls)
            {
                if (element is TextBox)
                    if (string.IsNullOrEmpty((element as TextBox).Text))
                    {
                        MessageBox.Show($"Поле \"{(element as TextBox).Name}\" является пустым", "Ошибка", MessageBoxButtons.OK);
                        return false;
                    }
            }
            return true;
        }

        async private void ReadDB(User user)
        {
            using (SqlConnection connection = new SqlConnection(DBCommand.conecctionSring))
            {
                await connection.OpenAsync();

                SqlCommand selectUser = new SqlCommand(DBCommand.SelectUser, connection);
                SqlParameter loginParam = new SqlParameter("@login", Encryptor.EncodeDecrypt(login.Text));
                SqlParameter passwordParam = new SqlParameter("@password", Encryptor.EncodeDecrypt(password.Text));
                selectUser.Parameters.Add(loginParam);
                selectUser.Parameters.Add(passwordParam);
                await selectUser.ExecuteScalarAsync();
                SqlDataReader reader = await selectUser.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        user.Login= (string)reader.GetValue(0);
                        user.Password= (string)reader.GetValue(1);
                        user.Name = (string)reader.GetValue(2);
                        user.Surname = (string)reader.GetValue(3);
                        user.Middlename = (string)reader.GetValue(4);
                        user.PassportSeries = (string)reader.GetValue(5);
                        user.PassportNumber = (string)reader.GetValue(6);
                        user.Telephone = (string)reader.GetValue(7);
                        user.Email = (string)reader.GetValue(8);
                    }
                }
                user.WriteFile(); 
            }
        }

        private bool CheckLog(User user)
        {

            user.Login=File.ReadAllText("user.txt");
            if (user.Login == null || user.Login== "")
            {
                MessageBox.Show($"Такого логина нет!", "Ошибка!", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            User user = new User();
            if (Check() == false)
                return;

            ReadDB(user);

            if (CheckLog(user) == false)
                return;

            Hotel accaunt = new Hotel();
            accaunt.Width = this.Width;
            accaunt.Height = this.Height;
            accaunt.Left = this.Left;
            accaunt.Top = this.Top;
            accaunt.Show();
            Hide();
        }

        private void Entry_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main entry = new Main();
            entry.Width = this.Width;
            entry.Height = this.Height;
            entry.Left = this.Left;
            entry.Top = this.Top;
            entry.Show();
            Hide();
        }

        private void Entry_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
