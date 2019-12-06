using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Opdracht1
{
    class Program
    {
        private int _amountofProfessions = 3;
        private string _question_name = "Fill in the profession name: ";
        private string _question_grade = "Fill in the given grade: ";
        private string _question_pgrade = "0. Geen, 1. Absent, 2. Onvoldoende, 3. Voldoende, 4. Goed";



        static void Main(string[] args)
        {
            Program p = new Program();
            p.Start();
        }

        private void Start()
        {
            List<Profession> professions = new List<Profession>();
            FillProfession(_amountofProfessions, _question_name, _question_grade, _question_pgrade, professions);
            Console.ReadKey();
            PostProfessions(professions);
            Console.ReadKey();
        }

        private void PostProfessions(List<Profession> list)
        {
            foreach(Profession p in list)
            {
                Console.WriteLine("Profession name: " + p.name);
                Console.WriteLine("Grade: " + p.grade);
                Console.WriteLine(" " + p.pgrade);
                if (p.CheckGradePositive())
                {
                    Console.WriteLine("Finished the Profession");
                    if (p.CheckGradeCumLaude())
                    {
                        Console.WriteLine("Profession Cum Laude");
                    }
                } else
                {
                    Console.WriteLine("Profession failed");
                }
            }
        }

        private void FillProfession(int amount, string question_name, string question_grade, string question_pgrade, List<Profession> list)
        {
            for(int i =0; i < amount; i++)
            {
                Profession p = new Profession();
                Console.WriteLine(question_name);
                p.name = Console.ReadLine();

                Console.WriteLine(question_grade);
                p.grade = int.Parse(Console.ReadLine());

                Console.WriteLine(question_pgrade);
                p.pgrade = (PraticalGrade)int.Parse(Console.ReadLine());
                list.Add(p);
            }
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
    }
}
