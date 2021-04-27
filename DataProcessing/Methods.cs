using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing
{
    class Methods
    {
        List<Student> AllStudents = new List<Student>();
        //Method to read input from a file and save to a list of Student
        public void readFromFile()
        {
            string[] lines = System.IO.File.ReadAllLines("C:/Users/Monika/Desktop/C#/DataProcessing/Data.txt");
            foreach(string line in lines)
            {
                string[] columns = line.Split(' ');
                List<double> homeworks = new List<double>();
                for (int i=2;i<columns.Length-1;i++)
                {
                    homeworks.Add(Int32.Parse(columns[i]));
                }
                Student A = new Student(columns[0], columns[1], homeworks, float.Parse(columns[columns.Length-1]));
                AllStudents.Add(A);
            }
        }
        //Method to print top of the output
        public void PrintTop()
        {
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            Console.Write("Surname");
            Console.SetCursorPosition(left + 10, top);
            Console.Write("Name");
            Console.SetCursorPosition(left + 20, top);
            Console.Write("Final points (Avg.)");
            Console.SetCursorPosition(left + 40, top);
            Console.WriteLine("Final points (Med.)");
            Console.WriteLine("-----------------------------------------------------------");

        }

        public List<Student> SortList(List<Student> AllStudents)
        {
            AllStudents.Sort((p1, p2) => string.Compare(p1.Name, p2.Name, true));
            return AllStudents;
        }

        //Method to show input from a file on the screen
        public void fromFileToScreen()
        {
            PrintTop();
            SortList(AllStudents);
            foreach (Student s in AllStudents)
            {
                int left2 = Console.CursorLeft;
                int top2 = Console.CursorTop;
                Console.Write(s.Name);
                Console.SetCursorPosition(left2 + 10, top2);
                Console.Write(s.Surname);
                Console.SetCursorPosition(left2 + 30, top2);
                double homeworks_average = s.Homeworks.Sum() / s.Homeworks.Count();
                double final_points_average = 0.3 * homeworks_average + 0.7 * s.Exam;
                Console.Write(Math.Round(final_points_average,2));
                Console.SetCursorPosition(left2 + 50, top2);
                double homeworks_median = CalculateMedianFromList(s.Homeworks);
                double final_points_median = 0.3 * homeworks_median + 0.7 * s.Exam;
                Console.WriteLine(Math.Round(final_points_median,2));
            }

        } 


        
        //Method to store user input in a list
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
        //Method to store  user input in a simple array
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
        public double CalculateMedianFromList(List<double> homeworks)
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
