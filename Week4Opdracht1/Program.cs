﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Week4Opdracht1
{
    class Program
    {
        private string _name_question = "Wat is uw naam?";
        private string _place_question = "Waar woont u?";
        private string _age_question = "Wat is uw leeftijd?";
        private string _path = @"C:\School\Inholland\Haarlem\Programmeren2\Inholland_Programmeren_P2\Week4Opdracht1\";

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Start();
        }

        private void Start()
        {
            Person p = ReadPerson(_name_question, _age_question, _place_question);
            ShowPerson(p);
            WritePerson(p.name + ".txt", _path, p);
            Console.ReadKey();
        }

        private Person ReadPerson(string name_question, string age_question, string place_question)
        {
            Person p = new Person();
            Console.WriteLine(name_question);
            p.name = Console.ReadLine();

            Console.WriteLine(age_question);
            int.TryParse(Console.ReadLine(), out p.age);

            Console.WriteLine(place_question);
            p.place = Console.ReadLine();
            return p;
        }

        private void ShowPerson(Person p)
        {
            Console.WriteLine("Name: " + p.name);
            Console.WriteLine("Age: " + p.age);
            Console.WriteLine("Area: " + p.place);
        }

        private void WritePerson(string filename, string path, Person p)
        {
            try
            {
                if(!File.Exists(path + filename))
                {
                    StreamWriter sw = new StreamWriter(path + filename);
                    sw.WriteLine(p.name);
                    sw.WriteLine(p.age);
                    sw.WriteLine(p.place);
                    sw.Close();
                } else
                {
                    Console.WriteLine("Person already exists");
                }

            } catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            } finally
            {
                
            }
        }
    }
}
