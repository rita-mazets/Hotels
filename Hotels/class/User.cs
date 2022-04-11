using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotels
{
    public class User : Client,People
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Middlename { get; set; }
        public string PassportNumber { get; set; }
        public string PassportSeries { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }

        public User() { }
        public User(string login, string password, string name, string sur, string middle, string passport)
            : base(login, password)
        {
            Name = name;
            Surname = sur;
            Middlename = middle;
            PassportNumber = passport;
        }

        override public string Surprise()
        {
            return "Лучший КЛИЕНТ ГОДА";
        }

        public void Registration()
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(DBCommand.conecctionSring))
            {
                connection.Open();

                SqlCommand selectUser = new SqlCommand(DBCommand.SelectLoginUser, connection);
                SqlParameter loginParam = new SqlParameter { ParameterName = "@login", Value = Encryptor.EncodeDecrypt(Login) };
                selectUser.Parameters.Add(loginParam);
                SqlParameter countParam = new SqlParameter { ParameterName = "@count", SqlDbType = SqlDbType.Int, Direction = ParameterDirection.Output };
                selectUser.Parameters.Add(countParam);

                selectUser.ExecuteNonQuery();
                count = (int)selectUser.Parameters["@count"].Value;
            }

            if (count != 0)
            {
                MessageBox.Show("Такой логин уже есть((", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            AddDB();
            WriteFile();
        }

        async public void AddDB()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DBCommand.conecctionSring))
                {
                    await connection.OpenAsync();

                    SqlCommand insertUser = new SqlCommand(DBCommand.InsertUser, connection);
                    insertUser = SetParam(insertUser);

                    await insertUser.ExecuteNonQueryAsync();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        async public void UpdateDB()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DBCommand.conecctionSring))
                {
                    await connection.OpenAsync();

                    SqlCommand updateUser = new SqlCommand(DBCommand.UpdateUser, connection);
                    updateUser = SetParam(updateUser);

                    await updateUser.ExecuteNonQueryAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private SqlCommand SetParam(SqlCommand sqlCommand)
        {
            SqlParameter loginParam = new SqlParameter { ParameterName = "@login", Value = Encryptor.EncodeDecrypt(Login) };
            SqlParameter passwordParam = new SqlParameter { ParameterName = "@password", Value = Encryptor.EncodeDecrypt(Password) };
            SqlParameter nameParam = new SqlParameter { ParameterName = "@name", Value = Encryptor.EncodeDecrypt(Name) };
            SqlParameter surnameParam = new SqlParameter { ParameterName = "@surname", Value = Encryptor.EncodeDecrypt(Surname) };
            SqlParameter middlenameParam = new SqlParameter { ParameterName = "@middlename", Value = Encryptor.EncodeDecrypt(Middlename) };
            SqlParameter pSeriesParam = new SqlParameter { ParameterName = "@passportSeries", Value = Encryptor.EncodeDecrypt(PassportSeries) };
            SqlParameter pNumberParam = new SqlParameter { ParameterName = "@passportNumber", Value = Encryptor.EncodeDecrypt(PassportNumber) };
            SqlParameter telephoneParam = new SqlParameter { ParameterName = "@telephone", Value = Encryptor.EncodeDecrypt(Telephone) };
            SqlParameter emailParam = new SqlParameter { ParameterName = "@email", Value = Encryptor.EncodeDecrypt(Email) };


            sqlCommand.Parameters.Add(loginParam);
            sqlCommand.Parameters.Add(passwordParam);
            sqlCommand.Parameters.Add(nameParam);
            sqlCommand.Parameters.Add(surnameParam);
            sqlCommand.Parameters.Add(middlenameParam);
            sqlCommand.Parameters.Add(pSeriesParam);
            sqlCommand.Parameters.Add(pNumberParam);
            sqlCommand.Parameters.Add(telephoneParam);
            sqlCommand.Parameters.Add(emailParam);

            return sqlCommand;
        }

        public void ReadFile()
        {
            string[] lines = File.ReadAllLines("user.txt");
            Login = lines[0];
            Password = lines[1];
            Surname = lines[3];
            Name = lines[2];
            Middlename = lines[4];
            PassportSeries = lines[5];
            PassportNumber = lines[6];
            Telephone = lines[7];
            Email = lines[8];
        }

        public void WriteFile()
        {
            string[] lines = new string[] { Login,Password, Name, Surname,
               Middlename, PassportSeries, PassportNumber, Telephone, Email };
            File.WriteAllLines("user.txt", lines);
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
