using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels
{
    public class Number
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public Capacity capacity = new Capacity();
        
        public int Type { get; set; }
        public int BedType { get; set; }
        public double Price { get; set; }
        public DateTime BeginD = new DateTime();
        public DateTime EndD = new DateTime();

        public string Getcapacity(int number)
        {
            string Capacity = "";
            if (number == 1)
                Capacity = capacity.GetOne();
            if (number == 2)
                Capacity = capacity.GetTwo();
            if (number == 3)
                Capacity = capacity.GetThree();
            if (number == 4)
                Capacity = capacity.GetFamily();
            return Capacity;
        }

        public string GetType(int type)
        {
            string Type = "";
            if (type == 1)
                Type = "Стандарт";
            if (type == 2)
                Type = "Студия";
            if (type == 3)
                Type = "Люкс";
            if (type == 4)
                Type = "Делюкс";
            if (type == 5)
                Type = "Бизнес";
            if (type == 6)
                Type = "Президент";
            return Type;
        }

        public int Capacity;
        public string GetCapacity(int capacity)
        {
            string Capacity = "";
            if (capacity == 1)
                Capacity = "Одноместный";
            if (capacity == 2)
                Capacity = "Двуместный";
            if (capacity == 3)
                Capacity = "Трехместный";
            if (capacity == 4)
                Capacity = "Семейный";
            return Capacity;
        }

        public string GetBedType(int bedType)
        {
            string BedType = "";
            if (bedType == 1)
                BedType = "Односпальная";
            if (bedType == 2)
                BedType = "Двуспальная";
            if (bedType == 3)
                BedType = "Двуспальная королевская";
            return BedType;
        }

        public void SelectAllNumber(List<Number> numbers, int id)
        {
            using (SqlConnection connection = new SqlConnection(DBCommand.conecctionSring))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(DBCommand.SearchAllNumber, connection);
                SqlParameter idP = new SqlParameter("@id", id);
                command.Parameters.Add(idP);


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
