using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing
{
    class Student
    {
        private string name;
        private string surname;
        private List<double> homeworks;
        private float exam;

        //Empty constructor
        public Student()
        { }

        //Constructor with properties
        public Student(string studentName, string studentSurname, List<double> studentHomeworks, float studentExam)
        {
            name = studentName;
            surname = studentSurname;
            homeworks = studentHomeworks;
            exam = studentExam;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;

            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;

            }
        }
        public List<double> Homeworks
        {
            get
            {
                return homeworks;
            }
            set
            {
                homeworks = value;

            }
        }
        public float Exam
        {
            get
            {
                return exam;
            }
            set
            {
                exam = value;

            }
        }

        /*public override String ToString()
        {
            return "Student: " + name + " " + surname + " Group: " + group + " Evaluation: " + average;
        }*/

    }
}
