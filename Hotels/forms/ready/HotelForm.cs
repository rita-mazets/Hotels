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

namespace Hotels
{
    public partial class Hotel : Form
    {

        List<Panel> panels = new List<Panel>();
        List<int> hotelsId = new List<int>();
        List<int> next = new List<int>();
        List<int> prev = new List<int>();
        private int nextId;
        bool isSearch = false;



        public Hotel()
        {
            InitializeComponent();
        }



        private void Hotel_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*Form form = Application.OpenForms[0];
            form.Show();*/
        }

        private void Hotel_Load(object sender, EventArgs e)
        {
            panel3.Click += new EventHandler(tb_Click);
            panel4.Click += new EventHandler(tb_Click);
            panel5.Click += new EventHandler(tb_Click);
            panel6.Click += new EventHandler(tb_Click);
            ReadId();
            ReadDB();

        }
        public void ReadId()
        {
            using (SqlConnection connection = new SqlConnection(DBCommand.conecctionSring))
            {
                connection.Open();
                SqlCommand readHotel = new SqlCommand(DBCommand.ReadHotelsId, connection);
                readHotel.ExecuteNonQuery();
                SqlDataReader reader = readHotel.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                        hotelsId.Add((int)reader.GetValue(0));
            }
        }


        async public void ReadDB()
        {
            using (SqlConnection connection = new SqlConnection(DBCommand.conecctionSring))
            {
                await connection.OpenAsync();

                int id1 = 0, id2 = 0, id3 = 0, id4 = 0;
                if (hotelsId.Count == 0) return;
                if (hotelsId.Count >= 1)
                {
                    id1 = hotelsId[0];
                    if (hotelsId.Count >= 2)
                    {
                        id2 = hotelsId[1];
                        if (hotelsId.Count >= 3)
                        {
                            id3 = hotelsId[2];
                            if (hotelsId.Count >= 4)
                            {
                                id4 = hotelsId[3];
                            }
                        }
                    }
                }

                SqlCommand readHotel = new SqlCommand(DBCommand.ReadHotel, connection);
                SqlParameter idParam1 = new SqlParameter("@id1", id1);
                readHotel.Parameters.Add(idParam1);
                SqlParameter idParam2 = new SqlParameter("@id2", id2);
                readHotel.Parameters.Add(idParam2);
                SqlParameter idParam3 = new SqlParameter("@id3", id3);
                readHotel.Parameters.Add(idParam3);
                SqlParameter idParam4 = new SqlParameter("@id4", id4);
                readHotel.Parameters.Add(idParam4);

                await readHotel.ExecuteNonQueryAsync();

                SqlDataReader reader = await readHotel.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    int id = 1;
                    while (await reader.ReadAsync())
                    {

                        if (id % 4 == 1)
                            panel(reader, nameLabel1, telephone1, address1, pictureBox1);
                        if (id % 4 == 2)
                            panel(reader, nameLabel2, telephone2, address2, pictureBox2);
                        if (id % 4 == 3)
                            panel(reader, nameLabel3, telephone3, address3, pictureBox3);
                        if (id % 4 == 0)
                            panel(reader, nameLabel4, telephone4, address4, pictureBox4);
                        id++;
                    }
                }
            }
        }

        private void panel(SqlDataReader reader, Label name, Label tel, Label address, PictureBox pictureBox)
        {
            name.Text = (string)reader.GetValue(1);
            tel.Text = (string)reader.GetValue(2);
            address.Text = (string)reader.GetValue(6) + ", " + (string)reader.GetValue(7) + ", " +
                               (string)reader.GetValue(8) + ", " + (string)reader.GetValue(9);
            string pathImage = (string)reader.GetValue(4);
            Bitmap image1 = new Bitmap(pathImage);


            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.BorderStyle = BorderStyle.Fixed3D;
            pictureBox.Image = image1;
        }

        private void panelZero(Label name, Label tel, Label address, PictureBox pictureBox)
        {
            name.Text = "";
            tel.Text = "";
            address.Text = "";
            pictureBox.Image = null;

        }

        void tb_Click(object sender, EventArgs e)
        {
            string name = "";
            if (sender.Equals(panel3))
                name = nameLabel1.Text;
            if (sender.Equals(panel4))
                name = nameLabel2.Text;
            if (sender.Equals(panel5))
                name = nameLabel3.Text;
            if (sender.Equals(panel6))
                name = nameLabel4.Text;

            HotelAccaunt hotelAccaunt = new HotelAccaunt();
            hotelAccaunt.name = name;
            hotelAccaunt.Width = this.Width;
            hotelAccaunt.Height = this.Height;
            hotelAccaunt.Left = this.Left;
            hotelAccaunt.Top = this.Top;
            hotelAccaunt.Show();
            Hide();
        }

        private void tableLayoutPanel1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < panels.Count; i++)
            {
                tableLayoutPanel1.Controls.Add(panels[i]);
                panels[i].Click += new EventHandler(tb_Click);
            }

        }



        private void user_Click(object sender, EventArgs e)
        {
            Accaunt accaunt = new Accaunt();
            accaunt.Width = this.Width;
            accaunt.Height = this.Height;
            accaunt.Left = this.Left;
            accaunt.Top = this.Top;
            accaunt.Show();
            Hide();
        }

        private void tableLayoutPanel2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < panels.Count; i++)
            {
                tableLayoutPanel1.Controls.Add(panels[i]);
                panels[i].Click += new EventHandler(tb_Click);
            }
        }



        private void perehod()
        {
            HotelAccaunt hotelAccaunt = new HotelAccaunt();
            hotelAccaunt.Width = this.Width;
            hotelAccaunt.Height = this.Height;
            hotelAccaunt.Left = this.Left;
            hotelAccaunt.Top = this.Top;
            hotelAccaunt.Show();
            Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (isSearch == false)
            {

                if (hotelsId.Count == 0) return;
                for (int i = 0; i < 4; i++)
                {
                    if (hotelsId.Count >= 1)
                    {
                        next.Add(hotelsId[0]);
                        hotelsId.RemoveAt(0);
                    }
                }
                ReadDB();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (isSearch == false)
            {
                if (next.Count == 0) return;
                for (int i = 0; i < 4; i++)
                {
                    if (next.Count >= 1)
                    {
                        hotelsId.Add(next[0]);
                        next.RemoveAt(0);
                    }
                }
                ReadDB();
            }
        }

        bool CheckListBox()
        {
            bool isc = false;
            foreach (int indexChecked in checkedListBox7.CheckedIndices)
            {
                isc = true;
            }
            return isc;
        }

        async private void serch_Click(object sender, EventArgs e)
        {
            isSearch = true;
            panelZero(nameLabel1, telephone1, address1, pictureBox1);
            panelZero(nameLabel2, telephone2, address2, pictureBox2);
            panelZero(nameLabel3, telephone3, address3, pictureBox3);
            panelZero(nameLabel4, telephone4, address4, pictureBox4);

            label13.Text = "";
            label15.Text = "";
            label20.Text = "";
            label25.Text = "";
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;


            if (countryT.Text != "" && cityT.Text != "" && textBox5.Text != "" && CheckListBox() == true)
            {
                using (SqlConnection connection = new SqlConnection(DBCommand.conecctionSring))
                {
                    await connection.OpenAsync();

                    List<bool> mass = new List<bool>(11);
                    foreach (int indexChecked in checkedListBox7.CheckedIndices)
                    {
                        MessageBox.Show("Index#: " + indexChecked.ToString() + ", is checked. Checked state is:" +
                       checkedListBox1.GetItemCheckState(indexChecked).ToString() + ".");
                    }

                    SqlCommand command = new SqlCommand(DBCommand.Command3, connection);
                    SqlParameter countryParam = new SqlParameter("@country", countryT.Text);
                    command.Parameters.Add(countryParam);
                    SqlParameter cityParam = new SqlParameter("@city", cityT.Text);
                    command.Parameters.Add(cityParam);
                    SqlParameter priceParam = new SqlParameter("@begin", textBox5.Text);
                    command.Parameters.Add(priceParam);

                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        int id = 1;
                        while (await reader.ReadAsync())
                        {

                            if (id % 4 == 1)
                            {
                                panel(reader, nameLabel1, telephone1, address1, pictureBox1);
                                label13.Text = "Телефон";
                                pictureBox1.Visible = true;
                            }
                            if (id % 4 == 2)
                            {
                                panel(reader, nameLabel2, telephone2, address2, pictureBox2);
                                label15.Text = "Телефон";
                                pictureBox2.Visible = true;
                            }
                            if (id % 4 == 3)
                            {
                                panel(reader, nameLabel3, telephone3, address3, pictureBox3);
                                label20.Text = "Телефон";
                                pictureBox3.Visible = true;
                            }
                            if (id % 4 == 0)
                            {
                                panel(reader, nameLabel4, telephone4, address4, pictureBox4);
                                label25.Text = "Телефон";
                                pictureBox4.Visible = true;
                            }
                            id++;
                        }
                    }
                }
            }
            else if (countryT.Text != "" && cityT.Text != "" && textBox5.Text != "")
            {
                using (SqlConnection connection = new SqlConnection(DBCommand.conecctionSring))
                {
                    await connection.OpenAsync();

                    SqlCommand command = new SqlCommand(DBCommand.Command3, connection);
                    SqlParameter countryParam = new SqlParameter("@country", countryT.Text);
                    command.Parameters.Add(countryParam);
                    SqlParameter cityParam = new SqlParameter("@city", cityT.Text);
                    command.Parameters.Add(cityParam);
                    SqlParameter priceParam = new SqlParameter("@begin", textBox5.Text);
                    command.Parameters.Add(priceParam);

                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        int id = 1;
                        while (await reader.ReadAsync())
                        {

                            if (id % 4 == 1)
                            {
                                panel(reader, nameLabel1, telephone1, address1, pictureBox1);
                                label13.Text = "Телефон";
                                pictureBox1.Visible = true;
                            }
                            if (id % 4 == 2)
                            {
                                panel(reader, nameLabel2, telephone2, address2, pictureBox2);
                                label15.Text = "Телефон";
                                pictureBox2.Visible = true;
                            }
                            if (id % 4 == 3)
                            {
                                panel(reader, nameLabel3, telephone3, address3, pictureBox3);
                                label20.Text = "Телефон";
                                pictureBox3.Visible = true;
                            }
                            if (id % 4 == 0)
                            {
                                panel(reader, nameLabel4, telephone4, address4, pictureBox4);
                                label25.Text = "Телефон";
                                pictureBox4.Visible = true;
                            }
                            id++;
                        }
                    }
                }
            }
            else if (countryT.Text != "" && cityT.Text != "")
            {
                using (SqlConnection connection = new SqlConnection(DBCommand.conecctionSring))
                {
                    await connection.OpenAsync();

                    SqlCommand command = new SqlCommand(DBCommand.Command2, connection);
                    SqlParameter countryParam = new SqlParameter("@country", countryT.Text);
                    command.Parameters.Add(countryParam);
                    SqlParameter cityParam = new SqlParameter("@city", cityT.Text);
                    command.Parameters.Add(cityParam);

                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        int id = 1;
                        while (await reader.ReadAsync())
                        {

                            
                                if (id % 4 == 1)
                                {
                                    pictureBox1.Visible = true;
                                    panel(reader, nameLabel1, telephone1, address1, pictureBox1);
                                    label13.Text = "Телефон";
                                    
                                }
                                if (id % 4 == 2)
                                {
                                    pictureBox2.Visible = true;
                                    panel(reader, nameLabel2, telephone2, address2, pictureBox2);
                                    label15.Text = "Телефон";
                                    
                                }
                                if (id % 4 == 3)
                                {
                                    pictureBox3.Visible = true;
                                    panel(reader, nameLabel3, telephone3, address3, pictureBox3);
                                    label20.Text = "Телефон";
                                    
                                }
                                if (id % 4 == 0)
                                {
                                    pictureBox4.Visible = true;
                                    panel(reader, nameLabel4, telephone4, address4, pictureBox4);
                                    label25.Text = "Телефон";
                                    
                                }
                                id++;
                            
                        }
                    }
                }
            }
            else if (countryT.Text != "")
            {
                using (SqlConnection connection = new SqlConnection(DBCommand.conecctionSring))
                {
                    await connection.OpenAsync();

                    SqlCommand command = new SqlCommand(DBCommand.Command1, connection);
                    SqlParameter countryParam = new SqlParameter("@country", countryT.Text);
                    command.Parameters.Add(countryParam);

                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    if (reader.HasRows)
                    {
                        int id = 1;
                        while (await reader.ReadAsync())
                        {

                            if (id % 4 == 1)
                            {
                                panel(reader, nameLabel1, telephone1, address1, pictureBox1);
                                label13.Text = "Телефон";
                                pictureBox1.Visible = true;
                            }
                            if (id % 4 == 2)
                            {
                                panel(reader, nameLabel2, telephone2, address2, pictureBox2);
                                label15.Text = "Телефон";
                                pictureBox2.Visible = true;
                            }
                            if (id % 4 == 3)
                            {
                                panel(reader, nameLabel3, telephone3, address3, pictureBox3);
                                label20.Text = "Телефон";
                                pictureBox3.Visible = true;
                            }
                            if (id % 4 == 0)
                            {
                                panel(reader, nameLabel4, telephone4, address4, pictureBox4);
                                label25.Text = "Телефон";
                                pictureBox4.Visible = true;
                            }
                            id++;
                        }
                    }
                }
            }

            }


            List<int> checklist()
            {
                List<int> mass = new List<int>();
                for (int i = 0; i < checkedListBox7.Items.Count; i++)
                {
                    if (checkedListBox7.GetItemChecked(i) == true)
                        mass.Add(i);
                }
                return mass;
            }










            async void db()
            {

            }

            private void Hotel_FormClosing(object sender, FormClosingEventArgs e)
            {
                Application.Exit();
            }

            private void Hotel_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.S && e.Modifiers == Keys.Alt && e.KeyCode == Keys.A)
                {
                    MessageBox.Show("Не обещаем миллионы, но номер выбирай любой \nДжин все оплатит", "Провал", MessageBoxButtons.OK);
                }
            }

            private void panel7_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Не обещаем миллионы, но номер выбирай любой \nДжин все оплатит", "Провал", MessageBoxButtons.OK);
            }

            private void telephone1_TextChanged(object sender, EventArgs e)
            {
                if (telephone1.Text != "" || telephone1.Text != null)
                    return;
                else if (telephone1.Text == "" || telephone1.Text == null)
                {
                    label13.Text = "";
                    pictureBox1.Visible = false;
                }
            }

            private void telephone2_TextChanged(object sender, EventArgs e)
            {
                if (telephone2.Text != "" || telephone2.Text != null)
                    return;
                else if (telephone2.Text == "" || telephone2.Text == null)
                {
                    label15.Text = "";
                    pictureBox2.Visible = false;
                }
            }

            private void telephone3_TextChanged(object sender, EventArgs e)
            {
                if (telephone3.Text != "" || telephone3.Text != null)
                    return;
                else if (telephone3.Text == "" || telephone3.Text == null)
                {
                    label20.Text = "";
                    pictureBox3.Visible = false;
                }
            }

            private void telephone4_TextChanged(object sender, EventArgs e)
            {
                if (telephone4.Text != "" || telephone4.Text != null)
                    return;
                if (telephone4.Text == "" || telephone4.Text == null)
                {
                    label25.Text = "";
                    pictureBox4.Visible = false;
                }
            }
        }
    }


