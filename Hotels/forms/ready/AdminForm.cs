using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotels
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Administrator admin = new Administrator();
            if (Check() == false)
                return;
            bool flag = true;
            flag=ReadDB(admin);
            if (!flag)
                return;

            if (CheckLog(admin) == false)
                return;


            AdminAct accaunt = new AdminAct();
            accaunt.admin = admin;
            accaunt.Width = this.Width;
            accaunt.Height = this.Height;
            accaunt.Left = this.Left;
            accaunt.Top = this.Top;
            accaunt.Show();
            Hide();
        }

        private bool CheckLog(Administrator user)
        {

            user.Login = File.ReadAllText("admin.txt");
            if (user.Login == null || user.Login == "")
            {
                MessageBox.Show($"Такого логина нет!", "Ошибка!", MessageBoxButtons.OK);
                return false;
            }
            return true;
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

        private bool ReadDB(Administrator user)
        {
            using (SqlConnection connection = new SqlConnection(DBCommand.conecctionSring))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(DBCommand.SearchAdmin, connection);
                SqlParameter loginParam = new SqlParameter("@login", Encryptor.EncodeDecrypt(Login.Text));
                SqlParameter passwordParam = new SqlParameter("@password", Encryptor.EncodeDecrypt(Password.Text));
                SqlParameter keyParam = new SqlParameter("@key", Encryptor.EncodeDecrypt(key.Text));
                command.Parameters.Add(loginParam);
                command.Parameters.Add(passwordParam);
                command.Parameters.Add(keyParam);
                command.ExecuteScalar();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user.Id = (int)reader.GetValue(0);
                        user.Login = (string)reader.GetValue(1);
                        user.Password = (string)reader.GetValue(2);
                        user.Key = (string)reader.GetValue(3);
                        user.IdHotel = (int)reader.GetValue(4);
                    }
                }
                else {
                    MessageBox.Show($"Кажется здесь шпион \nИли Джин))", "Ошибка", MessageBoxButtons.OK);
                    return false;
                }
                user.WriteFile();
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Administrator admin = new Administrator();
            if (Check() == false)
                if (CheckPassword.Text == "" || CheckPassword == null)
                {
                    MessageBox.Show($"Поле \"подтверждение пароля\" является пустым", "Ошибка", MessageBoxButtons.OK);
                    return;
                }


            admin.Login = Login.Text;
            admin.Password = Password.Text;
            admin.Key = key.Text;
            AddDB(admin);

            if (CheckLog(admin) == false)
                return;


            AdminAct accaunt = new AdminAct();
            accaunt.admin = admin;
            accaunt.Width = this.Width;
            accaunt.Height = this.Height;
            accaunt.Left = this.Left;
            accaunt.Top = this.Top;
            accaunt.Show();
            Hide();
        }

        void AddDB(Administrator admin)
        {
            using (SqlConnection connection = new SqlConnection(DBCommand.conecctionSring))
            {
                connection.Open();

                admin.IdHotel = 0;
                SqlCommand command1 = new SqlCommand(DBCommand.SearchKey, connection);
                SqlParameter keyParam1 = new SqlParameter("@key", Encryptor.EncodeDecrypt(admin.Key));
                command1.Parameters.Add(keyParam1);
                SqlDataReader reader1 = command1.ExecuteReader();
                if (reader1.HasRows)
                {
                    while (reader1.Read())
                    {
                        admin.IdHotel = (int)reader1.GetValue(0);
                    }
                }
                if (admin.IdHotel == 0)
                {
                    MessageBox.Show($"Неверное ключевок слово!\nВы шпион? А может Джин?", "Ошибка", MessageBoxButtons.OK);
                    return;
                }
                reader1.Close();


                SqlCommand command = new SqlCommand(DBCommand.InsertAdmin, connection);
                SqlParameter loginParam = new SqlParameter("@login", Encryptor.EncodeDecrypt(Login.Text));
                SqlParameter passwordParam = new SqlParameter("@password", Encryptor.EncodeDecrypt(Password.Text));
                SqlParameter keyParam = new SqlParameter("@key", Encryptor.EncodeDecrypt(key.Text));
                command.Parameters.Add(loginParam);
                command.Parameters.Add(passwordParam);
                command.Parameters.Add(keyParam);
                command.ExecuteNonQuery();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main entry= new Main();
            entry.Width = this.Width;
            entry.Height = this.Height;
            entry.Left = this.Left;
            entry.Top = this.Top;
            entry.Show();
            Hide();
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

       

        private void registration_Click(object sender, EventArgs e)
        {
            
        }

     
    }
}
