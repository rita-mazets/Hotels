using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels
{
    public class Address
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Home { get; set; }

        public Address() { }
        public Address(string country, string city, string street, string home)
        {
            Country = country;
            City = city;
            Street = street;
            Home = home;
        }
    }
}
