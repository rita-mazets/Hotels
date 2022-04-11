using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotels
{
    interface People
    {
        string Login { get; set; }
        string Password { get; set; }

        void WriteFile();
        void ReadFile();
    }
}
