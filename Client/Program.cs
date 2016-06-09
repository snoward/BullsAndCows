using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    class Program
    {
        // адрес и порт сервера, к которому будем подключаться
        static int port = 8005; // порт сервера
        static string address = "10.113.116.137"; // адрес сервера
        static void Main(string[] args)
        {
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // подключаемся к удаленному хосту
            socket.Connect(ipPoint);

            while (true)
            {
                StringBuilder builder = new StringBuilder();
                var data = new byte[1024]; // буфер для ответа


                var bytes = socket.Receive(data, data.Length, 0);

                builder.Append(Encoding.UTF8.GetString(data, 0, bytes));
                Console.WriteLine("ответ сервера: " + builder.ToString());

                var msg = Console.ReadLine();
                var toMsg = Encoding.UTF8.GetBytes(msg);
                socket.Send(toMsg);
            }

        }
    }
}