using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing
{
    class Methods
    {
        //List<Student> AllStudents = new List<Student>();
        //Method to read input from a file and save to a list of Student
        public List<Student> readFromFile(string path)
        {
            List<Student> AllStudents = new List<Student>();
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] columns = line.Split(' ');
                    List<double> homeworks = new List<double>();
                    for (int i = 2; i < columns.Length - 1; i++)
                    {
                        try
                        { homeworks.Add(Int32.Parse(columns[i])); }
                        catch //(FormatException)
                        {
                            Console.WriteLine("One of the marks is invalid in line " + line);
                        }
                    }
                    try
                    {
                        Student A = new Student(columns[0], columns[1], homeworks, float.Parse(columns[columns.Length - 1]));
                        AllStudents.Add(A);
                    }
                    catch 
                    {
                        Console.WriteLine("One of the marks is missing/is invalid in line " + line);
                    }
                    
                }
                
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file was not found");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The directory was not found");
            }
            catch (IOException)
            {
                Console.WriteLine("The file could not be opened");
            }
            return AllStudents;
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
        //Method to sort the list of students by name 
        public List<Student> SortList(List<Student> AllStudents)
        {
            AllStudents.Sort((p1, p2) => string.Compare(p1.Name, p2.Name, true));
            return AllStudents;
        }

        //Method to show input from a file on the screen
        public void fromFileToScreen(List<Student> AllStudents)
        {
            PrintTop();
            //SortList(AllStudents);
            foreach (Student s in AllStudents)
            {
                int left2 = Console.CursorLeft;
                int top2 = Console.CursorTop;
                Console.Write(s.Surname);
                Console.SetCursorPosition(left2 + 20, top2);
                Console.Write(s.Name);
                Console.SetCursorPosition(left2 + 40, top2);
                double homeworks_average = s.Homeworks.Sum() / s.Homeworks.Count();
                double final_points_average = 0.3 * homeworks_average + 0.7 * s.Exam;
                Console.Write(Math.Round(final_points_average,2));
                Console.SetCursorPosition(left2 + 60, top2);
                double homeworks_median = CalculateMedianFromList(s.Homeworks);
                double final_points_median = 0.3 * homeworks_median + 0.7 * s.Exam;
                Console.WriteLine(Math.Round(final_points_median,2));
            }
        } 
        
        //Method to store user input in a list
        public List<double> List()
        {
            List<double> homeworks = new List<double>();
            string[] marks;
            int temp;
            Console.WriteLine("Enter homework marks, separated by space");
            string input = Console.ReadLine();
            marks = input.Split(' ');
            foreach (string i in marks)
            {
                try
                {
                    temp = int.Parse(i);
                    homeworks.Add(temp);
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please check if you separated marks by space or if one of the marks is invalid");
                    Console.ReadLine();
                    Environment.Exit(1);
                }
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
                try
                {
                    homeworks[i] = int.Parse(marks[i]);
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please check if you separated marks by space or if one of the marks is invalid");
                    Console.ReadLine();
                    Environment.Exit(1);
                }
                
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


    }
}
