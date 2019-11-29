using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Opdracht1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Start();
        }

        private void Start()
        {
            ReadProfession("Fill in a profession: ");

            
        }

        PraticalGrade ReadPraticalGrade(string question)
        {

        }

        private void PrintPraticalGrade (PraticalGrade grade)
        {
            Console.WriteLine();
        }

        Profession ReadProfession(string question_name, string question_grade, string question_pgrade)
        {
            Profession p = new Profession();
            Console.WriteLine(question_name);
            p.name = Console.ReadLine();

            Console.WriteLine(question_grade);
            p.grade = int.Parse(Console.ReadLine());

            Console.WriteLine(question_pgrade);
            p.pgrade = (PraticalGrade)int.Parse(Console.ReadLine());
            return p;
            
        }

        private void PrintProfession(Profession prof)
        {
           
        }
    }
}
