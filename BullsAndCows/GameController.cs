using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    public class GameController
    {
        public IGameUi Ui { get; private set; }

        public GameController(IGameUi ui)
        {
            Ui = ui;
        }

        public IPlayer CreatePlayer() 
        {
            var name = Ui.SnowGetPlayerNameDialog();
            var number = new GameNumber(Ui.SnowGetPlayerNumberDialog());
            return new Player(name, number);
        }

        public Game CreateGame()
        {
            var one = CreatePlayer();
            var another = CreatePlayer(); 

            return new Game(one, another);
        }


        public void Run()
        {
            var game = CreateGame();
            while (!game.IsOver)
            {
                Ui.UpdateView(game);
                var currentNumber = new GameNumber(Ui.SnowGetNumberDialog());
                game = game.NextStep(currentNumber);
            }
            Ui.SnowWinnerName(game.Winner.Name);
        }
    }
}
