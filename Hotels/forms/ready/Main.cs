using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotels
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            
        }

        private void registr_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Width = this.Width;
            registration.Height = this.Height;
            registration.Left = this.Left;
            registration.Top = this.Top;
            registration.Show();
            Hide();
        }

        private void entry_Click(object sender, EventArgs e)
        {
            Entry entry = new Entry();
            entry.Width = this.Width;
            entry.Height = this.Height;
            entry.Left = this.Left;
            entry.Top = this.Top;
            entry.Show();
            Hide();
        }

        private void admin_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Width = this.Width;
            admin.Height = this.Height;
            admin.Left = this.Left;
            admin.Top = this.Top;
            admin.Show();
            Hide();
        }
    }
}
