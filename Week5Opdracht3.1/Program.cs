using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MyTools;


namespace Week5Opdracht3._1
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
            TranslateWords(ReadWords("young"));
        }

        private Dictionary<string, string> ReadWords(string filename)
        {
            string l;
            string[] ls = new string[2];
            Dictionary<string, string> dict = new Dictionary<string, string>();
            StreamReader sr = new StreamReader(@"..\\..\\dictionary.csv");
            while((l = sr.ReadLine()) != null)
            {
                ls = l.Split(';');
                dict.Add(ls[0], ls[1]);
            }
            return dict;
        }

        void TranslateWords(Dictionary<string, string> words)
        {
            string temp = ReadTools.ReadString("Enter a word: ");
            if (temp == "stop")
                return;
            if (temp == "listall")
            {
                ListAllWords(words);
            }
            else if (words.ContainsKey(temp))
            {
                Console.WriteLine("{0} => {1}", temp, words[temp]);
            }
            else
                Console.WriteLine("Woord niet gevonden");
            TranslateWords(words);
        }

        void ListAllWords(Dictionary<string, string> words)
        {
            foreach (KeyValuePair<string, string> w in words)
            {
                Console.WriteLine("{0} => {1}", w.Key, w.Value);
            }
        }
    }
}
