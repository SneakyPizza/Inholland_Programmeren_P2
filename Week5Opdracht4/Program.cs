using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MyTools;

namespace Week5Opdracht4
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            List<string> words = ReadWords();
            string lingoWord = ChooseWord(words);
            PlayLingo(lingoWord);
            Start();
        }

        private List<string> ReadWords()
        {
            List<string> list = new List<string>();
            string l;
            StreamReader sr = new StreamReader(@"..\\..\\words.txt");
            while ((l = sr.ReadLine()) != null)
            {
                if (l.Length >= 3)
                    list.Add(l);
            }
            sr.Close();
            return list;
        }

        private string ChooseWord(List<string> words)
        {
            Random r = new Random();
            return words[r.Next(0, words.Capacity)];
        }

        private void PlayLingo(string lingoWord)
        {
            int tries = 5;
            bool guessed = false;
            do
            {
                string temp = ReadPlayerWord(lingoWord);
                DisplayResult(temp, EvaluateWord(temp, lingoWord));
                if (temp == lingoWord)
                    guessed = true;
                tries--;
            }
            while (!guessed && tries > 0);
            if (guessed)
                Console.WriteLine("Congratulations");
            else
                Console.WriteLine("Too bad! the correct word was:  {0}", lingoWord);
        }

        private LetterState[] EvaluateWord(string playerWord, string lingoWord)
        {
            LetterState[] outcome = new LetterState[lingoWord.Length];
            char[] pWord = playerWord.ToCharArray();
            char[] lWord = lingoWord.ToCharArray();
            for (int x = 0; x < lingoWord.Length; x++)
            {
                if (pWord[x] == lWord[x])
                    outcome[x] = LetterState.Correct;
                else if
                    (lWord.Contains(pWord[x]))
                    outcome[x] = LetterState.WrongPosition;
                else
                    outcome[x] = LetterState.Wrong;
            }
            return outcome;
        }

        private void DisplayResult(string playerWord, LetterState[] result)
        {
            char[] pWord = playerWord.ToCharArray();
            for (int i = 0; i < pWord.Length; i++)
            {

                switch (result[i])
                {
                    case LetterState.Correct:
                        Console.BackgroundColor = ConsoleColor.Green;
                        break;
                    case LetterState.WrongPosition:
                        Console.BackgroundColor = ConsoleColor.Red;
                        break;
                    case LetterState.Wrong:
                        break;
                    default:
                        break;
                }
                Console.Write(pWord[i]);
                Console.ResetColor();
            }
            Console.WriteLine();


        }

        private string ReadPlayerWord(string word)
        {
            string s;
            
            s = ReadTools.ReadString("Fill in a word with " + word.Length + " letters: ");
            if (s.Length == word.Length)
                return s;
            else
                return ReadPlayerWord(word);
        }
    }

}
