using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessing
{
    class RandomFileGenerator
    {
        public string CreateFile(int name, string path)
        {
            
            string fileName = Path.Combine(path, name.ToString() + ".txt");
            using (StreamWriter fs = File.CreateText(fileName)) { };
            return fileName;
        }

        public void GenerateEntries(int number, string fileName)
        {
            Random r = new Random();
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                for (int i = 1; i <= number; i++)
                {
                    outputFile.Write("Name" + i + " Surname" + i + " ");
                    for (int j = 0; j < 5; j++)
                    {
                        int rand = r.Next(1, 11);
                        outputFile.Write(rand + " ");
                    }
                    int random = r.Next(1, 11);
                    outputFile.WriteLine(random);
                }
            }
        }





    }
}
