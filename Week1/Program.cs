using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1
{
    class Program
    {
        private string _question1 = "tik een getal: ";

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Start();
        }

        void Start()
        {

            Console.WriteLine(AskMonth("Voer maand in: "));
            Console.WriteLine(_question1);
            int n = ReadInt(_question1);
            Console.WriteLine("Je hebt {0} ingetikt.", n);

            int age = ReadInt("Hoe oud ben je ? ", 0, 120);
            Console.WriteLine("Je bent {0} jaar oud.", age);

            string name = ReadString("Hoe heet je ?");
            Console.WriteLine("Aangenaam kennis met je te maken, {0}.", name);
            Console.ReadKey();
        }

        private int ReadInt(string question)
        {
            int num = int.Parse(Console.ReadLine());
            return num;
        }


        private int ReadInt(string question, int min, int max)
        {
            int num = int.Parse(Console.ReadLine());
            if(num >= min && num <= max)
            {
                return num;
            } else
            {
                //opnieuw invoeren
                return num;
            }
        }

        private string ReadString(string question)
        {
            string n = Console.ReadLine();
            return n;
        }

        private void PrintMonth(Months month)
        {
            Console.WriteLine(month.ToString());
        }

        private void PrintMonths()
        {
            foreach(Months month in Enum.GetValues(typeof(Months)))
            {
                int num = (int)month;
                Console.WriteLine("{0}. {1}", num, month);
            }
        }

        private Months? AskMonth(string question)
        {
            Console.WriteLine(question);
            int num = int.Parse(Console.ReadLine());
            Months m = (Months)Enum.Parse(typeof(Months), num.ToString());
            if (Enum.IsDefined(typeof(Months), num) == true)
            {
                return m;
            }
            else
            {
                Console.WriteLine("Invalide maand  {0}", num);

                return null;
            }
        }
    }
}
