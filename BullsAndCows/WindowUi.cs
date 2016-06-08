using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BullsAndCows;

namespace BullsAndCows
{
    public class WindowUi : Form, IGameUi
    {
        public WindowUi()
        {
        }

        public string GetPlayerName()
        {
            MessageBox.Show(@"Введите имя игрока");
            return "Misha";
        }

        public string GetPlayerNumber()
        {
            throw new NotImplementedException();
        }

        public string GetNumber()
        {
            throw new NotImplementedException();
        }

        public void PrintBullsCows(string bullsCows)
        {
            throw new NotImplementedException();
        }

        public void PrintWinner(string winner)
        {
            throw new NotImplementedException();
        }

        public void UpdateView(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
