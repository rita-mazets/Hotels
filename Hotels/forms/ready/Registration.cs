using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;
using System.Linq;

namespace Hotels
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*Form form = Application.OpenForms[0];
            form.Show();*/
        }

        private bool Check()
        {
            foreach (var element in panel1.Controls)
            {
                if (element is TextBox)
                    if (string.IsNullOrEmpty((element as TextBox).Text))
                    {
                        MessageBox.Show($"Поле \"{(element as TextBox).Name}\" является пустым", "Ошибка", MessageBoxButtons.OK);
                        return false;
                    }
            }
            if (password.Text != checkPassword.Text)
            {
                MessageBox.Show("Павторный пароль не совпадает с первоначальным!", "Ошибка", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void SetInformation(User user)
        {
            user.Login = login.Text;
            user.Surname = surname.Text;
            user.Name = name.Text;
            user.Middlename = middlename.Text;
            user.PassportSeries = series.Text;
            user.PassportNumber = number.Text;
            user.Telephone = telephone.Text;
            user.Email = email.Text;
            user.Password = password.Text;
        }

        async private void registr_Click(object sender, EventArgs e)
        {
            clk();
        }

        async private void clk()
        {
            User user = new User();
            if (Check() == false)
                return;
            SetInformation(user);
            int count = 0;
            using (SqlConnection connection = new SqlConnection(DBCommand.conecctionSring))
            {
                await connection.OpenAsync();

                SqlCommand selectUser = new SqlCommand(DBCommand.SelectLoginUser, connection);
                SqlParameter loginParam = new SqlParameter { ParameterName = "@login", Value = Encryptor.EncodeDecrypt(user.Login) };
                selectUser.Parameters.Add(loginParam);
                SqlParameter countParam = new SqlParameter { ParameterName = "@count", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
                selectUser.Parameters.Add(countParam);

                await selectUser.ExecuteNonQueryAsync();
                count = (int)selectUser.Parameters["@count"].Value;
            }

            if (count != 0)
            {
                MessageBox.Show("Такой логин уже есть((", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            user.AddDB();
            user.WriteFile();

            Hotel accaunt = new Hotel();
            accaunt.Width = this.Width;
            accaunt.Height = this.Height;
            accaunt.Left = this.Left;
            accaunt.Top = this.Top;
            accaunt.Show();
            Hide();
        }

        // переход
        private void login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                surname.Focus();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            login.Focus();
        }

        private void surname_KeyDown(object sender, KeyEventArgs e)
        {
           /* if (e.KeyData == Keys.Enter)
                name.Focus();*/
        }

        private void name_KeyDown(object sender, KeyEventArgs e)
        {
            /*if (e.KeyData == Keys.Enter)
                middlename.Focus();*/
        }

        private void middlename_KeyDown(object sender, KeyEventArgs e)
        {
           /* if (e.KeyData == Keys.Enter)
                series.Focus();*/
        }

        private void series_KeyDown(object sender, KeyEventArgs e)
        {
           /* if (e.KeyData == Keys.Enter)
                number.Focus();*/
        }

        private void number_KeyDown(object sender, KeyEventArgs e)
        {
            /*if (e.KeyData == Keys.Enter)
                telephone.Focus();*/
        }

        private void telephone_KeyDown(object sender, KeyEventArgs e)
        {
            /*if (e.KeyData == Keys.Enter)
                email.Focus();*/
        }

        private void email_KeyDown(object sender, KeyEventArgs e)
        {
            /*if (e.KeyData == Keys.Enter)
                password.Focus();
            email.Text = email.Text;*/
            
        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            /*if (e.KeyData == Keys.Enter)
                checkPassword.Focus();*/
        }

        private void checkPassword_KeyDown(object sender, KeyEventArgs e)
        {
            /*if (e.KeyData == Keys.Enter)
                registr.Focus();*/
        }

        private void registr_KeyDown(object sender, KeyEventArgs e)
        {
            /*if (e.KeyData == Keys.Enter)
                clk();*/
        }

        private void login_TextChanged(object sender, EventArgs e)
        {

        }

        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main entry = new Main();
            entry.Width = this.Width;
            entry.Height = this.Height;
            entry.Left = this.Left;
            entry.Top = this.Top;
            entry.Show();
            Hide();
        }
    }
}
