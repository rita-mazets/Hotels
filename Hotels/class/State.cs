using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotels
{
    public interface ICommand
    {
        void Execute();
    }

    class ChangeCommand : ICommand
    {
        private User user;

        public ChangeCommand(List<string> list)
        {
            user = new User();
            user.Login = list[0];
            user.Surname = list[1];
            user.Name = list[2];
            user.Middlename = list[3];
            user.PassportSeries = list[4];
            user.PassportNumber = list[5];
            user.Telephone = list[6];
            user.Email = list[7];
        }

        public void Execute()
        {
            user.UpdateDB();
            user.WriteFile();
        }
    }

    class ExitCommand : ICommand
    {
        private Main main;
        private Form cur;

        public ExitCommand(List<Form> list)
        {
            main = new Main();
            cur = list[0];
        }

        public void Execute()
        {
            main.Width = cur.Width;
            main.Height = cur.Height;
            main.Left = cur.Left;
            main.Top = cur.Top;
            main.Show();
            cur.Hide();
            string[] s = { "" };
            File.WriteAllLines("user.txt", s);
        }
    }

    class PrevCommand : ICommand
    {
        private Hotel main;
        private Form cur;

        public PrevCommand(List<Form> list)
        {
            main = new Hotel();
            cur = list[0];
        }

        public void Execute()
        {
            main.Width = cur.Width;
            main.Height = cur.Height;
            main.Left = cur.Left;
            main.Top = cur.Top;
            main.Show();
            cur.Hide();
        }
    }

    class Invoker
    {
        private ICommand _onStart;


        public void SetOnStart(ICommand command)
        {
            this._onStart = command;
        }


        // Отправитель не зависит от классов конкретных команд и получателей.
        // Отправитель передаёт запрос получателю косвенно, выполняя команду.
        public void DoSomethingImportant()
        {
            if (this._onStart is ICommand)
            {
                this._onStart.Execute();
            }
            
        }
    }
}
