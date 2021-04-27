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
            string name;
            string surname;
            float exam_result = 0;
            double homeworks_average = 0;
            double homeworks_median = 0;
            double final_points = 0;
            int choice;

            Methods m = new Methods();

            Console.WriteLine("Enter name and surname");
            string input = Console.ReadLine();
            string[] c = input.Split(' ');
            name = c[0];
            surname = c[1];

            //As per task, student homework results are stored in either array or list. For that, there are different methods. Select which one.

            //With list:

            List<int> homeworks = m.List();
            homeworks_average = homeworks.Sum() / homeworks.Count();
            homeworks_median = m.CalculateMedianFromList(homeworks);


            //With Simple array
            /*int[] homeworks = m.SimpleArray();
            homeworks_average = homeworks.Sum() / homeworks.Length;
            homeworks_median = m.CalculateMedianFromArray(homeworks);
            */


            Console.WriteLine("Enter the result of exam");
            string input2 = Console.ReadLine();
            float.TryParse(input2, out exam_result);

            Console.WriteLine("Would you like to view final points as average(0) or median(1)");
            int.TryParse(Console.ReadLine(), out choice);
            if (choice == 0)
            {
                final_points = 0.3 * homeworks_average + 0.7 * exam_result;
            }
            else
            {
                final_points = 0.3 * homeworks_median + 0.7 * exam_result;
            }
            Console.Write(surname + " " + name + " " + final_points);

            Console.ReadLine();
        }
    }
}
