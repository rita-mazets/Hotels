using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotels
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            User user = new User();

            /*user.Name = File.ReadAllText("user.txt");

            if (user.Name == "" || user.Name == null)
            {*/
                Application.Run(new Main());
           /* }
            else
            {
                user.ReadFile();
                Application.Run(new Hotel());
            }   */       
        }
    }
}
