using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels
{
    [Serializable]
    abstract public class Client
    {
        public Client() { }
        public Client(string login, string password)
        {
            Login = login;
            Password = password;
        }
        public string Login { get; set; }
        public string Password { get; set; }


        public abstract string Surprise();
        public abstract void ReserveNumber(int id, string begin, string end, int userId);

        public abstract void RemoveReservation(int id);
       
    }
}
