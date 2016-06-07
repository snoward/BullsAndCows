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

        public GameController()
        {
            Ui = new ConsoleUi();
            
        }

        public IPlayer CreatePlayer() 
        {
            var name = Ui.GetPlayerName();
            var number = new GameNumber(Ui.GetPlayerNumber());
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
            //Ui = new ConsoleUi(game);
            while (!game.IsOver)
            {
                Ui.UpdateView(game);
                var currentNumber = new GameNumber(Ui.GetNumber());
                var bullsCows = game.CheckNumber(currentNumber); 
                Ui.PrintBullsCows(bullsCows);

                game.NextStep(currentNumber);
            }
            Ui.PrintWinner(game.Winner.Name);
        }
    }
}
