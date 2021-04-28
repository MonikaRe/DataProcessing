using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing
{
    class SortingAndDividing
    {
        List<Student> failed = new List<Student>();
        List<Student> passed = new List<Student>();

        public void Sorting(List<Student> AllStudents, int name ,string path)
        {
            string fileNamePassed = Path.Combine(path,name.ToString()+ "passed.txt");
            string fileNameFailed = Path.Combine(path,name.ToString() + "failed.txt");
            using (StreamWriter fs = File.CreateText(fileNamePassed)) { };
            using (StreamWriter fs = File.CreateText(fileNameFailed)) { };
            StreamWriter outputFilePassed = new StreamWriter(fileNamePassed);
            StreamWriter outputFileFailed = new StreamWriter(fileNameFailed);
            foreach (Student s in AllStudents)
                {
                    double homeworks_average = s.Homeworks.Sum() / s.Homeworks.Count();
                    double final_points_average = 0.3 * homeworks_average + 0.7 * s.Exam;
                    if (final_points_average < 5)
                    {
                        failed.Add(s);
                        outputFileFailed.WriteLine(s.Name +" "+ s.Surname +" "+ final_points_average);
                    }
                    else
                    {
                        passed.Add(s);
                        outputFilePassed.WriteLine(s.Name + " " + s.Surname + " " + final_points_average);
                     }
            }
                
        }

    }
}
