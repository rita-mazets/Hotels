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
    public partial class HotelAccaunt : Form
    {
        DateTime dateB, dateE;
        public string name;
        private int id = 0;
        private string[] files;
        private static string imagePath = "D:\\учеба\\4 семестр\\oop\\Hotels\\Hotels\\imageHotel\\Number\\";
        List<Bitmap> bitmaps = new List<Bitmap>();
        private int type1 = 0, type2 = 0, type3 = 0, type4 = 0, type5 = 0, type6 = 0;
        private int ctype1 = 0, ctype2 = 0, ctype3 = 0, ctype4 = 0;
        private int btype1 = 0, btype2 = 0, btype3 = 0;
        List<Number> numbers = new List<Number>();

        public HotelAccaunt()
        {
            InitializeComponent();
        }

        public HotelAccaunt(string name)
        {
            this.name = name;
        }

        new private void Show()
        {
        }
        private void HotelAccaunt_Load(object sender, EventArgs e)
        {
            GetHotels();
            GetImagePath();
            GetImage();
            SetImage();
            textBox2.Text = DateTime.Now.ToString("yyyy-MM-dd");
            textBox3.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ListPrev();
            SetImage();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ListNext();
            SetImage();
        }
        void GetHotels()
        {
            using (SqlConnection connection = new SqlConnection(DBCommand.conecctionSring))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(DBCommand.HotelAccauntId, connection);
                SqlParameter Param = new SqlParameter("@name", name);
                command.Parameters.Add(Param);


                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                        id = (int)reader.GetValue(0);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hotel hotel = new Hotel();
            hotel.Width = this.Width;
            hotel.Height = this.Height;
            hotel.Show();
            this.Hide();
        }

        private void HotelAccaunt_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            Hotel hotel = new Hotel();
            hotel.Width = this.Width;
            hotel.Height = this.Height;
            hotel.Left = this.Left;
            hotel.Top = this.Top;
            hotel.Show();
            this.Hide();
        }

        void GetImagePath()
        {
            imagePath += Convert.ToString(id);
        }
        void GetImage()
        {
            if (Directory.Exists(imagePath))
            {
                files = Directory.GetFiles(imagePath);
                foreach (string s in files)
                {
                    Bitmap image = new Bitmap(s);
                    bitmaps.Add(image);
                }
            }
        }
        void ListNext()
        {
            Bitmap b = new Bitmap(bitmaps[0]);
            bitmaps.Add(b);
            bitmaps.RemoveAt(0);
        }
        void ListPrev()
        {
            bitmaps.Reverse();
            ListNext();
            bitmaps.Reverse();
        }
        void SetImage()
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            pictureBox1.Image = bitmaps[0];
        }
        bool CheckBox(CheckedListBox checkedListBox)
        {
            bool isc = false;
            foreach (int indexChecked in checkedListBox.CheckedIndices)
            {
                isc = true;
            }
            return isc;
        }
        bool Check()
        {
            if (CheckBox(checkedListBox8) == false)
            {
                MessageBox.Show("Выберите тип комнаты", "Ошибка", MessageBoxButtons.OK);
                return false;
            }
            if (CheckBox(checkedListBox9) == false)
            {
                MessageBox.Show("Выберите вместимость комнаты", "Ошибка", MessageBoxButtons.OK);
                return false;
            }
            if (CheckBox(checkedListBox10) == false)
            {
                MessageBox.Show("Выберите тип кровати", "Ошибка", MessageBoxButtons.OK);
                return false;
            }
            if (textBox2.Text == null || textBox2.Text == "")
            {
                MessageBox.Show("Укажите дату прибытия", "Ошибка", MessageBoxButtons.OK);
                return false;
            }
            if (textBox3.Text == null || textBox3.Text == "")
            {
                MessageBox.Show("Укажите дату выезда", "Ошибка", MessageBoxButtons.OK);
                return false;
            }
            try
            {
                dateB = DateTime.ParseExact(textBox2.Text, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Укажите дату прибытия", "Ошибка", MessageBoxButtons.OK);
                return false;
            }
            try
            {
                dateE = DateTime.ParseExact(textBox3.Text, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Укажите дату выезда", "Ошибка", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void serch_Click(object sender, EventArgs e)
        {
            Number number = new Number();
            dateB = Convert.ToDateTime(textBox2.Text);
            dateE = Convert.ToDateTime(textBox3.Text);
            if (checkBox1.Checked)
                number.SelectAllNumber(numbers, id);
            else
            {
                if (!Check())
                    return;

                foreach (object itemChecked in checkedListBox8.CheckedItems)
                {
                    if (itemChecked.ToString() == "Стандарт")
                        type1 = 1;
                    if (itemChecked.ToString() == "Студия")
                        type2 = 2;
                    if (itemChecked.ToString() == "Люкс")
                        type3 = 3;
                    if (itemChecked.ToString() == "Делюкс")
                        type4 = 4;
                    if (itemChecked.ToString() == "Бизнес")
                        type5 = 5;
                    if (itemChecked.ToString() == "Президент")
                        type6 = 6;
                }

                foreach (object itemChecked in checkedListBox9.CheckedItems)
                {
                    if (itemChecked.ToString() == "Одноместный")
                        ctype1 = 1;
                    if (itemChecked.ToString() == "Двухместный")
                        ctype2 = 2;
                    if (itemChecked.ToString() == "Трехместный")
                        ctype3 = 3;
                    if (itemChecked.ToString() == "Семейный")
                        ctype4 = 4;
                }

                foreach (object itemChecked in checkedListBox10.CheckedItems)
                {
                    if (itemChecked.ToString() == "Односпальная")
                        btype1 = 1;
                    if (itemChecked.ToString() == "Двуспальная")
                        btype2 = 2;
                    if (itemChecked.ToString() == "Двуспальная королевская")
                        btype3 = 3;
                }

                ReadDB();
            }

            SearchNumber searchNumber = new SearchNumber();
            searchNumber.numbers = numbers;
            searchNumber.begin = dateB;
            searchNumber.end = dateE;
            searchNumber.Width = this.Width;
            searchNumber.Height = this.Height;
            searchNumber.Left = this.Left;
            searchNumber.Top = this.Top;
            searchNumber.Show();
            Hide();

        }

        private void checkedListBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        void ReadDB()
        {
            using (SqlConnection connection = new SqlConnection(DBCommand.conecctionSring))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(DBCommand.SearchNumber, connection);
                SqlParameter idP = new SqlParameter("@id", id);
                command.Parameters.Add(idP);

                SqlParameter typeP1 = new SqlParameter("@type1", type1);
                command.Parameters.Add(typeP1);
                SqlParameter typeP2 = new SqlParameter("@type2", type2);
                command.Parameters.Add(typeP2);
                SqlParameter typeP3 = new SqlParameter("@type3", type3);
                command.Parameters.Add(typeP3);
                SqlParameter typeP4 = new SqlParameter("@type4", type4);
                command.Parameters.Add(typeP4);
                SqlParameter typeP5 = new SqlParameter("@type5", type5);
                command.Parameters.Add(typeP5);
                SqlParameter typeP6 = new SqlParameter("@type6", type6);
                command.Parameters.Add(typeP6);


                SqlParameter ctypeP1 = new SqlParameter("@ctype1", ctype1);
                command.Parameters.Add(ctypeP1);
                SqlParameter ctypeP2 = new SqlParameter("@ctype2", ctype2);
                command.Parameters.Add(ctypeP2);
                SqlParameter ctypeP3 = new SqlParameter("@ctype3", ctype3);
                command.Parameters.Add(ctypeP3);
                SqlParameter ctypeP4 = new SqlParameter("@ctype4", ctype4);
                command.Parameters.Add(ctypeP4);

                SqlParameter btypeP1 = new SqlParameter("@btype1", btype1);
                command.Parameters.Add(btypeP1);
                SqlParameter btypeP2 = new SqlParameter("@btype2", btype2);
                command.Parameters.Add(btypeP2);
                SqlParameter btypeP3 = new SqlParameter("@btype3", btype3);
                command.Parameters.Add(btypeP3);

                SqlParameter dateBP = new SqlParameter("@beginD", dateB);
                command.Parameters.Add(dateBP);
                SqlParameter dateEP = new SqlParameter("@endD", dateE);
                command.Parameters.Add(dateEP);


                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Number number = new Number();
                        number.Name = (int)reader.GetValue(0);
                        number.Price = Convert.ToDouble(reader.GetValue(1));
                        number.Type = (int)reader.GetValue(2);
                        number.Capacity = (int)reader.GetValue(3);
                        number.BedType = (int)reader.GetValue(4);
                        number.Id = (int)reader.GetValue(5);

                        numbers.Add(number);
                    }
                }
            }
        }

    }
}

