using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Week4Opdracht3
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Start();
        }
        void Start()
        {
            Console.WriteLine("\nAantal berichten gevonden: {0}", SearchWord("..\\..\\trumptweets2019.txt", ReadString("Welk woord wil je zoeken?: ")));

            Start();
        }


        private bool PutWordInSentence(string sentence, string word)
        {
            bool b = false;
            if (sentence.ToUpper().Contains(word.ToUpper()))
                b = true;
            return b;
        }

        private void ShowWordInSentence(string sentence, string word)
        {
            int index = sentence.ToUpper().IndexOf(word.ToUpper());
            Console.Write(sentence.Substring(0, index));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(sentence.Substring(index, word.Length));
            Console.ResetColor();
            if (PutWordInSentence(sentence.Substring(index + word.Length), word))
                ShowWordInSentence(sentence.Substring(index + word.Length), word);
            else
                Console.WriteLine(sentence.Substring(index + word.Length));
        }

        private int SearchWord(string filename, string word)
        {
            int num = 0;
            string line;
            StreamReader file = new StreamReader(@"..\\..\\trumptweets2019.txt");
            while ((line = file.ReadLine()) != null)
            {
                if (PutWordInSentence(line, word))
                {
                    Console.WriteLine();
                    ShowWordInSentence(line, word);
                    num++;
                }

            }
            return num;
        }

        private string ReadString(string vraag)
        {
            Console.Write(vraag);
            return Console.ReadLine();
        }
    }


}
