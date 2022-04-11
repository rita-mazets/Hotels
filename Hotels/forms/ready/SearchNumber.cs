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
    public partial class SearchNumber : Form
    {
        public List<Number> numbers = new List<Number>();
        Number number = new Number();
        public DateTime begin ;
        public DateTime end ;
        public SearchNumber()
        {
            InitializeComponent();
        }

        private void SearchNumber_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                string type = number.GetType(numbers[i].Type);
                string capacity = number.GetCapacity(numbers[i].Capacity);
                string bedType = number.GetBedType(numbers[i].BedType);
                dataGridView1.Rows.Add(numbers[i].Name, numbers[i].Price, type, capacity, bedType);
            }
        }


        private void user_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            int name = (int)dataGridView1[0, index].Value;
            Number number=numbers.Find(item=>item.Id==name);
            int id = number.Id;

            User user = new User();
            user.ReadFile();
            int userId=0;

            using (SqlConnection connection = new SqlConnection(DBCommand.conecctionSring))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(DBCommand.SelecIdtUser, connection);
                SqlParameter loginP = new SqlParameter("@login", user.Login);
                command.Parameters.Add(loginP);


                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        userId = (int)reader.GetValue(0);
                    }
                }
                reader.Close();

                SqlCommand command1 = new SqlCommand(DBCommand.SelectDateId, connection);
                SqlParameter IdP = new SqlParameter("@id", number.Id);
                command1.Parameters.Add(IdP);

                SqlParameter beginP = new SqlParameter("@begin", begin);
                command1.Parameters.Add(beginP);
                SqlParameter endP = new SqlParameter("@end", end);
                command1.Parameters.Add(endP);


                SqlDataReader reader1 = command1.ExecuteReader();
                if (reader1.HasRows)
                {
                    return;
                }
                reader1.Close();


                SqlCommand command2 = new SqlCommand(DBCommand.InsertDate, connection);
                SqlParameter userIdP = new SqlParameter("@userId", userId);
                command2.Parameters.Add(userIdP);
                SqlParameter beginP1 = new SqlParameter("@begin", begin);
                command2.Parameters.Add(beginP1);
                SqlParameter endP1 = new SqlParameter("@end", end);
                command2.Parameters.Add(endP1);
                SqlParameter numberIdP = new SqlParameter("@numberId", number.Id);
                command2.Parameters.Add(numberIdP);

                int i=command2.ExecuteNonQuery();

                if (i >= 1)
                {
                    MessageBox.Show("Номер забронирован", "Успех!", MessageBoxButtons.OK);
                }


            }


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

        private void SearchNumber_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
