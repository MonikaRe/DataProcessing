using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing
{
    class Methods
    {
        //Method to store input in a list
        public List<int> List()
        {
            List<int> homeworks = new List<int>();
            string[] marks;
            int temp;
            Console.WriteLine("Enter homework marks, separated by space");
            string input = Console.ReadLine();
            marks = input.Split(' ');
            foreach (string i in marks)
            {
                temp = int.Parse(i);
                homeworks.Add(temp);
            }
            return homeworks;
        }
        //Method to store input in a simple array
        public int[] SimpleArray()
        {
            string[] marks;
            Console.WriteLine("Enter homework marks, separated by space");
            string input = Console.ReadLine();
            marks = input.Split(' ');
            int n = marks.Length;
            int[] homeworks = new int[n];
            for (int i = 0; i < n; i++)
            {
                homeworks[i] = int.Parse(marks[i]);
            }
            return homeworks;

        }
        //Method to calculate median from a list
        public double CalculateMedianFromList(List<int> homeworks)
        {
            double median = 0;
            homeworks.Sort();
            int n = homeworks.Count();
            if (n % 2 != 0)
            {
                median = homeworks[n / 2];
            }
            else
            {
                median = (homeworks[(n - 1) / 2] + homeworks[n / 2]) / 2.0;
            }
            return median;
        }
        //Method to calculate median from an array
        public double CalculateMedianFromArray(int[] homeworks)
        {
            double median = 0;
            Array.Sort(homeworks);
            int n = homeworks.Length;
            if (n % 2 != 0)
            {
                median = homeworks[n / 2];
            }
            else
            {
                median = (homeworks[(n - 1) / 2] + homeworks[n / 2]) / 2.0;
            }
            return median;
        }

        //Random number generator
        public int RandomNumber()
        {
            Random r = new Random();
            int num = r.Next(11);
            return num;
        }
    }
}
