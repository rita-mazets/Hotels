using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels
{
    public class Person
    {
        public Client user;
        public Person(string name)
        {
            if (name == "admin")
                user = new Administrator();
            if (name == "user")
                user = new User();
        }

        public void ReserveNumber(int id, string begin, string end, int userId)
        {
            user.ReserveNumber(id, begin, end, userId);
        }

        public void RemoveReservation(int id)
        {
            user.RemoveReservation(id);
        }
    }
}
