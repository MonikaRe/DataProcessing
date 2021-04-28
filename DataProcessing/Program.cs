using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            Methods m = new Methods();
            UserIO u = new UserIO();

            //User input:
            u.UserInput();

            //Reading from file and printing to the screen
            //m.readFromFile();

            Console.ReadLine();
        }
    }
}
