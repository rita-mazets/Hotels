using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotels
{
   
    public partial class Accaunt : Form
    {
        User user = new User();
        public Accaunt()
        {
            InitializeComponent();
        }
                
        private void Accaunt_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*Form form = Application.OpenForms[0];
            form.Show();*/
        }

        private void Accaunt_Load(object sender, EventArgs e)
        {
            user.ReadFile();
            SetInformation();

        }

        private void SetInformation()
        {
            login.Text = user.Login;
            name.Text = user.Name;
            surname.Text = user.Surname;
            middlename.Text = user.Middlename;
            passSeries.Text = user.PassportSeries;
            passnumber.Text = user.PassportNumber;
            telephon.Text = user.Telephone;
            email.Text = user.Email;
        }

        private void back_Click(object sender, EventArgs e)
        {
            List<Form> list = new List<Form>();

            list.Add(this);
            Invoker invoker = new Invoker();
            invoker.SetOnStart(new PrevCommand(list));
            invoker.DoSomethingImportant();
            /*Hotel hotel = new Hotel();
            hotel.Width = this.Width;
            hotel.Height = this.Height;
            hotel.Left = this.Left;
            hotel.Top = this.Top;
            hotel.Show();
            this.Hide();*/
        }

        private void change_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            list.Add(login.Text);
            list.Add(surname.Text);

            list.Add(name.Text);
            list.Add(middlename.Text);
            list.Add(passSeries.Text);
            list.Add(passnumber.Text);
            list.Add(telephon.Text);
            list.Add(email.Text);

            Invoker invoker = new Invoker();
            invoker.SetOnStart(new ChangeCommand(list));
            invoker.DoSomethingImportant();
           /*
            user.Login = login.Text;
            user.Surname = surname.Text;
            user.Name = name.Text;
            user.Middlename = middlename.Text;
            user.PassportSeries = passSeries.Text;
            user.PassportNumber = passnumber.Text;
            user.Telephone = telephon.Text;
            user.Email = email.Text;

            user.UpdateDB();
            user.WriteFile();*/
        }

        

        private void poka_Click(object sender, EventArgs e)
        {
            //Main main = new Main();

            List<Form> list = new List<Form>();

            list.Add(this);
            Invoker invoker = new Invoker();
            invoker.SetOnStart(new ExitCommand(list));
            invoker.DoSomethingImportant();

            /*main.Width = this.Width;
            main.Height = this.Height;
            main.Left = this.Left;
            main.Top = this.Top;
            main.Show();
            Hide();
            string[] s = { "" };
            File.WriteAllLines("user.txt", s);*/
        }

        private void Accaunt_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
