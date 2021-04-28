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
            RandomFileGenerator r = new RandomFileGenerator();
            SortingAndDividing s = new SortingAndDividing();
            string initialPath = "C:/Users/Monika/Desktop/C#/DataProcessing/Data.txt";
            string generalPath = "C:/Users/Monika/Desktop/C#/DataProcessing/";
            List<Student> AllStudents = new List<Student>();
            //User input:
            //u.UserInput();



            int n1 = 10000;
            int n2 = 100000;
            int n3 = 1000000;
            int n4 = 10000000;
            string fileName;

            fileName = r.CreateFile(n1, generalPath);
            r.GenerateEntries(n1, fileName);

            //Reading from file and printing to the screen
            AllStudents = m.readFromFile(fileName);
            //m.fromFileToScreen(AllStudents);

            s.Sorting(AllStudents, n1, generalPath);
            //s.DividePassed(n1, generalPath);

            Console.ReadLine();
        }
    }
}
