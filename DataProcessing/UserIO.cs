using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing
{
    class UserIO
    {
        string name;
        string surname;
        float exam_result = 0;
        double homeworks_average = 0;
        double homeworks_median = 0;
        double final_points = 0;
        int choice;
        Methods m = new Methods();

        public void UserInput()
        {
            Console.WriteLine("Enter name and surname");
            string input = Console.ReadLine();
            string[] c = input.Split(' ');
            try
            {
                name = c[0];
                surname = c[1];
            }
            catch
            {
                Console.WriteLine("Invalid number of arguments.");
                Console.ReadLine();
                Environment.Exit(1);
            }
            

            //As per task, student homework results are stored in either array or list. For that, there are different methods. Select which one. 

            /*//With list:
            
            List<double> homeworks = m.List();
            homeworks_average = homeworks.Sum() / homeworks.Count();
            homeworks_median = m.CalculateMedianFromList(homeworks);*/

            
            //With Simple array
            int[] homeworks = m.SimpleArray();
            homeworks_average = homeworks.Sum() / homeworks.Length;
            homeworks_median = m.CalculateMedianFromArray(homeworks);
            
            EXAM: Console.WriteLine("Enter the result of exam");
            try
            {
                exam_result = float.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid number");
                goto EXAM;
            }

            CHOICE:  Console.WriteLine("Would you like to view final points as average(0) or median(1)");
            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid choice");
                goto CHOICE;
            }
            if (choice == 0)
            {
                final_points = 0.3 * homeworks_average + 0.7 * exam_result;
            }
            else if(choice ==1)
            {
                final_points = 0.3 * homeworks_median + 0.7 * exam_result;
            }
            else
            {
                Console.WriteLine("Invalid choice");
                goto CHOICE;
            }

            PrintUserInput(choice,final_points);
        }

        public void PrintUserInput(int choice,double final_points)
        {
            int left = Console.CursorLeft;
            int top = Console.CursorTop;
            Console.Write("Surname");
            Console.SetCursorPosition(left + 10, top);
            Console.Write("Name");
            Console.SetCursorPosition(left + 20, top);
            if(choice == 0)
            {
                Console.WriteLine("Final points (Avg.)");
            }
            else
            {
                Console.WriteLine("Final points (Med.)");
            }
            Console.WriteLine("-----------------------------------------------------------");


            int left2 = Console.CursorLeft;
            int top2 = Console.CursorTop;
            Console.Write(surname);
            Console.SetCursorPosition(left2 + 10, top2);
            Console.Write(name);
            Console.SetCursorPosition(left2 + 30, top2);
            Console.Write(final_points);

        }



    }
}
