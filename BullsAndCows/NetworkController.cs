using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    class NetworkController
    {
        public IGameUi Ui { get; private set; }
        public Queue<Socket> SocketQueue;
        public readonly Dictionary<string, Socket> ConnectionName;

        public NetworkController()
        {
            ConnectionName = new Dictionary<string, Socket>(); 
            var ipEndPoint = new IPEndPoint(IPAddress.Parse("10.113.116.137"), 8005);

            var sListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            sListener.Bind(ipEndPoint);
            sListener.Listen(2);
            SocketQueue = new Queue<Socket>();

            Console.WriteLine("start");
            var handlerOne = sListener.Accept();
            Console.Write(handlerOne);
            SocketQueue.Enqueue(handlerOne);

            Console.WriteLine("Priem");
            var handlerAnother = sListener.Accept();
            SocketQueue.Enqueue(handlerAnother);
        }

        public IPlayer CreatePlayer()
        {
            var currentHandler = SocketQueue.Dequeue();
            var msgName = Encoding.UTF8.GetBytes("Введите имя: \r\n");
            currentHandler.Send(msgName);
            var bytesName = new byte[1024];
            var answerName = currentHandler.Receive(bytesName);
            var name = Encoding.UTF8.GetString(bytesName, 0, answerName);


            var msgNumber = Encoding.UTF8.GetBytes("Введите ваше число: \r\n");
            currentHandler.Send(msgNumber);
            var bytesNumber = new byte[1024];
            var answerNumber = currentHandler.Receive(bytesNumber);
            var number = Encoding.UTF8.GetString(bytesNumber, 0, answerNumber);
            Console.WriteLine(number);
            ConnectionName.Add(name, currentHandler);
            return new Player(name, new GameNumber(number));
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
                var currentMsg = Encoding.UTF8.GetBytes("Введите число: \r\n");

                ConnectionName[game.CurrentPlayer.Name].Send(currentMsg, currentMsg.Length, 0);
                 
                var bytesNumber = new byte[1024];
                var answer = ConnectionName[game.CurrentPlayer.Name].Receive(bytesNumber);
                var currentNumber = new GameNumber(Encoding.UTF8.GetString(bytesNumber, 0, answer));

                var bullsAndCows = GameNumber.GetBullAndCows(game.NextPlayer.PlayerNumber, currentNumber);
                var numberToByte = Encoding.UTF8.GetBytes(bullsAndCows);
                ConnectionName[game.CurrentPlayer.Name].Send(numberToByte);

                game.NextStep(currentNumber);
            }
            var msgWinner = Encoding.UTF8.GetBytes("Вы победили");
            var msgLoose = Encoding.UTF8.GetBytes("Вы проиграли");

            ConnectionName[game.NextPlayer.Name].Send(msgWinner, msgWinner.Length, 0);
            ConnectionName[game.CurrentPlayer.Name].Send(msgLoose, msgLoose.Length, 0);
            
            foreach (var elem in ConnectionName.Values)
                elem.Close();

            Console.WriteLine(game.Winner.Name + "Выиграл");
        }
    }
}
