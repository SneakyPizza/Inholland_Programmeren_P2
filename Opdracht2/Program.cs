using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht2
{
    class Program
    {
        private Person[] _peopleCollection;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Start();
        }

        private void Start()
        {
            _peopleCollection = new Person[3];
            int i = GetRandom(0, 2);
            AddToArray(_peopleCollection);
            PrintCollection(_peopleCollection);
            Console.ReadKey();
            CelebrateBirthday(_peopleCollection[i]);
            PrintPerson(_peopleCollection[i]);
            Console.ReadKey();
        }

        private void AddToArray(Person[] collection)
        {
            for(int i = 0; i < collection.Length; i++)
            {
                Console.WriteLine("Voer persoon {0} in", i);
                collection[i] = FillPerson();
            }
        }

        private void PrintCollection(Person[] collection)
        {
            for(int i = 0; i < collection.Length; i++)
            {
                PrintPerson(collection[i]);
            }
        }

        private void CelebrateBirthday(Person p)
        {
            p.age += 1;
            Console.ReadKey();
        }

        private Person FillPerson()
        {
            Person p = new Person();
            p.surname = ReadString("Voer voornaam in: ");
            p.lastname = ReadString("Voer Achternaam in: ");
            p.age = ReadInt("Voer leeftijd in: ");
            p.location = ReadString("Voer Woonplaats in: ");
            p.sex = ReadSex("Voer geslacht in(M/V): ");
            return p;
        }

        private SexType ReadSex(string question)
        {
            Console.WriteLine(question);
            string a = Console.ReadLine();
            if(a == "man" || a == "m")
            {
                return SexType.Male;
            } else if(a == "vrouw" || a == "v")
            {
                return SexType.Female;
            } else
            {
                return SexType.Other;
            }
        }

        private void PrintSex(SexType sex)
        {
            Console.WriteLine("is een {0}", sex);
        }

        private void PrintPerson(Person p)
        {
            Console.WriteLine("Persoon is {0} {1}, ({2}) {3} jaar oud en komt uit {4}", p.surname, p.lastname, p.sex, p.age, p.location);
        }

        private int ReadInt(string question)
        {
            Console.WriteLine(question);
            int num = int.Parse(Console.ReadLine());
            return num;
        }


        private int ReadInt(string question, int min, int max)
        {
            int num = int.Parse(Console.ReadLine());
            if (num >= min && num <= max)
            {
                return num;
            }
            else
            {
                //opnieuw invoeren
                return num;
            }
        }

        private string ReadString(string question)
        {
            Console.WriteLine(question);
            string n = Console.ReadLine();
            return n;
        }

        private int GetRandom(int min, int max)
        {
            Random r = new Random();
            int v = r.Next(min, max);
            return v;
        }
    }
}
