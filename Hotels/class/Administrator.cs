using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotels
{
    public class Administrator : Client, People
    {
        public int Id { get; set; }
        public int IdHotel { get; set; }
        public string Key { get; set; }

        public Administrator() { }
        public Administrator(string login, string password, string key)
            : base(login, password)
        {
            Key = key;
        }
        override public string Surprise()
        {
            return "Лучший Администратор";
        }



        public void Registration()
        {
            using (SqlConnection connection = new SqlConnection(DBCommand.conecctionSring))
            {
                connection.Open();

                IdHotel = 0;
                SqlCommand command1 = new SqlCommand(DBCommand.SearchKey, connection);
                SqlParameter keyParam1 = new SqlParameter("@key", Encryptor.EncodeDecrypt(Key));
                command1.Parameters.Add(keyParam1);
                SqlDataReader reader1 = command1.ExecuteReader();
                if (reader1.HasRows)
                {
                    while (reader1.Read())
                    {
                        IdHotel = (int)reader1.GetValue(0);
                    }
                }
                if (IdHotel == 0)
                {
                    MessageBox.Show($"Неверное ключевок слово!\nВы шпион? А может Джин?", "Ошибка", MessageBoxButtons.OK);
                    return;
                }
                reader1.Close();


                SqlCommand command = new SqlCommand(DBCommand.InsertAdmin, connection);
                SqlParameter loginParam = new SqlParameter("@login", Encryptor.EncodeDecrypt(Login));
                SqlParameter passwordParam = new SqlParameter("@password", Encryptor.EncodeDecrypt(Password));
                SqlParameter keyParam = new SqlParameter("@key", Encryptor.EncodeDecrypt(Key));
                command.Parameters.Add(loginParam);
                command.Parameters.Add(passwordParam);
                command.Parameters.Add(keyParam);
                command.ExecuteNonQuery();

            }
        }

        public void ReadFile()
        {
            string[] lines = File.ReadAllLines("admin.txt");
            Login = lines[0];
            Password = lines[1];
            Key = lines[2];
            Id = Convert.ToInt32(lines[3]);
            IdHotel = Convert.ToInt32(lines[3]);

        }

        public void WriteFile()
        {
            string[] lines = new string[] { Login, Password, Key, Id.ToString(), IdHotel.ToString() };
            File.WriteAllLines("admin.txt", lines);
        }

        override public void ReserveNumber(int id, string begin, string end, int userId)
        {
            using (SqlConnection connection = new SqlConnection(DBCommand.conecctionSring))
            {
                connection.Open();


                SqlCommand command1 = new SqlCommand(DBCommand.SelectDateId, connection);
                SqlParameter IdP = new SqlParameter("@id", id);
                command1.Parameters.Add(IdP);

                SqlParameter beginP = new SqlParameter("@begin", begin);
                command1.Parameters.Add(beginP);
                SqlParameter endP = new SqlParameter("@end", begin);
                command1.Parameters.Add(endP);


                SqlDataReader reader1 = command1.ExecuteReader();
                if (reader1.HasRows)
                {
                    return;
                }
                reader1.Close();


                SqlCommand command2 = new SqlCommand(DBCommand.InsertDateAdmin, connection);
                SqlParameter userIdP = new SqlParameter("@userId", userId);
                command2.Parameters.Add(userIdP);
                SqlParameter beginP1 = new SqlParameter("@begin", begin);
                command2.Parameters.Add(beginP1);
                SqlParameter endP1 = new SqlParameter("@end", end);
                command2.Parameters.Add(endP1);
                SqlParameter numberIdP = new SqlParameter("@numberId", id);
                command2.Parameters.Add(numberIdP);

                int i = command2.ExecuteNonQuery();

                if (i >= 1)
                {
                    MessageBox.Show("Номер забронирован", "Успех!", MessageBoxButtons.OK);
                }

            }
        }

        override public void RemoveReservation(int id)
        {
            using (SqlConnection connection = new SqlConnection(DBCommand.conecctionSring))
            {
                connection.Open();


                SqlCommand command1 = new SqlCommand(DBCommand.DeleteDate, connection);
                SqlParameter IdP = new SqlParameter("@id", id);
                command1.Parameters.Add(IdP);

                command1.ExecuteNonQuery();
            }
        }
    }
}
