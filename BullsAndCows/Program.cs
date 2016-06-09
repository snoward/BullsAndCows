using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows
{
    class Program
    {
        public static void Main(string[] args)
        {
            var controller = new NetworkController();
            controller.Run();
        }
    }
}
