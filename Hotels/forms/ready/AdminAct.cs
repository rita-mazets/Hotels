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
    public partial class AdminAct : Form
    {
        List<Number> numbers = new List<Number>();
        Number number = new Number();
        public Administrator admin=new Administrator();

        Person person = new Person("admin");

        int userId;
        public AdminAct()
        {
            InitializeComponent();

            Administrator administrator = new Administrator();
            administrator.ReadFile();

            userId = administrator.Id;
        }

        private void AdminAct_Load(object sender, EventArgs e)
        {
            textBox2.Text = DateTime.Now.ToString("yyyy-MM-dd");
            textBox3.Text = DateTime.Now.ToString("yyyy-MM-dd");
            number.SelectAllNumber(numbers, admin.IdHotel);
            for (int i = 0; i < numbers.Count; i++)
            {
                string type = number.GetType(numbers[i].Type);
                string capacity = number.GetCapacity(numbers[i].Capacity);
                string bedType = number.GetBedType(numbers[i].BedType);
                dataGridView1.Rows.Add(numbers[i].Name, numbers[i].Price, type, capacity, bedType);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void user_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            int name = (int)dataGridView1[0, index].Value;
            Number number = numbers.Find(item => item.Id == name);
            int id = number.Id;

            if (Convert.ToDateTime(textBox2.Text) > Convert.ToDateTime(textBox3.Text))
            {
                MessageBox.Show("Дата выезда должна быть больше даты заезда", "Успех!", MessageBoxButtons.OK);
                return;
            }

            Administrator admin = new Administrator();
            admin.ReadFile();

            using (SqlConnection connection = new SqlConnection(DBCommand.conecctionSring))
            {
                connection.Open();

                
                SqlCommand command1 = new SqlCommand(DBCommand.SelectDateId, connection);
                SqlParameter IdP = new SqlParameter("@id", number.Id);
                command1.Parameters.Add(IdP);

                SqlParameter beginP = new SqlParameter("@begin", textBox2.Text);
                command1.Parameters.Add(beginP);
                SqlParameter endP = new SqlParameter("@end", textBox3.Text);
                command1.Parameters.Add(endP);


                SqlDataReader reader1 = command1.ExecuteReader();
                if (reader1.HasRows)
                {
                    return;
                }
                reader1.Close();


                SqlCommand command2 = new SqlCommand(DBCommand.InsertDateAdmin, connection);
                SqlParameter userIdP = new SqlParameter("@userId", admin.Id);
                command2.Parameters.Add(userIdP);
                SqlParameter beginP1 = new SqlParameter("@begin", textBox2.Text);
                command2.Parameters.Add(beginP1);
                SqlParameter endP1 = new SqlParameter("@end", textBox3.Text);
                command2.Parameters.Add(endP1);
                SqlParameter numberIdP = new SqlParameter("@numberId", number.Id);
                command2.Parameters.Add(numberIdP);

                int i = command2.ExecuteNonQuery();

                if (i >= 1)
                {
                    MessageBox.Show("Номер забронирован", "Успех!", MessageBoxButtons.OK);
                }


            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
            dataGridView2.Rows.Clear();
            
            int index = dataGridView1.CurrentCell.RowIndex;
            int name = (int)dataGridView1[0, index].Value;
            Number number = numbers.Find(item => item.Id == name);
            int id = number.Id;

            using (SqlConnection connection = new SqlConnection(DBCommand.conecctionSring))
            {
                connection.Open();


                SqlCommand command1 = new SqlCommand(DBCommand.SelectAllDate, connection);
                SqlParameter IdP = new SqlParameter("@id", id);
                command1.Parameters.Add(IdP);

                SqlDataReader reader1 = command1.ExecuteReader();
                if (reader1.HasRows)
                {
                    while (reader1.Read())
                    {
                        dataGridView2.Rows.Add(reader1.GetValue(0), reader1.GetValue(1), reader1.GetValue(2), reader1.GetValue(3),reader1.GetValue(4) );
                    }
                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = dataGridView2.CurrentCell.RowIndex;
            int id=(int)dataGridView2.CurrentCell.Value;
            /*DataGridViewRow row = new DataGridViewRow();
            int id=(int)row.Cells[index].Value;*/
            //int id = (int)dataGridView1[0, index].Value;
            //Number number = numbers.Find(item => item.Id == name);
            //int id = number.Id;

            using (SqlConnection connection = new SqlConnection(DBCommand.conecctionSring))
            {
                connection.Open();


                SqlCommand command1 = new SqlCommand(DBCommand.DeleteDate, connection);
                SqlParameter IdP = new SqlParameter("@id", id);
                command1.Parameters.Add(IdP);

                command1.ExecuteNonQuery();
            }

        }

        private void AdminAct_FormClosing(object sender, FormClosingEventArgs e)
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

        private void AdminAct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Modifiers == Keys.Alt && e.KeyCode == Keys.D)
            {
                MessageBox.Show("Ну вот, злодей, ты и попался \nМайку украл и думал, что всё с рук сойдет \nА вот и нет \nХа-ха-ха-ха-ха", "Провал", MessageBoxButtons.OK);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ну вот, злодей, ты и попался \nМайку украл и думал, что всё с рук сойдет \nА вот и нет \nХа-ха-ха-ха-ха", "Провал", MessageBoxButtons.OK);
        }

        private void reserve_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            int name = (int)dataGridView1[0, index].Value;
            Number number = numbers.Find(item => item.Id == name);
            int id = number.Id;

            if (Convert.ToDateTime(textBox2.Text) > Convert.ToDateTime(textBox3.Text))
            {
                MessageBox.Show("Дата выезда должна быть больше даты заезда", "Успех!", MessageBoxButtons.OK);
                return;
            }
            
            person.ReserveNumber(id,textBox2.Text, textBox3.Text, userId);
        }
    }
    
}
