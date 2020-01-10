using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Week4Opdracht2._1
{
    public class HangmanGame
    {
        //private List<string> _wordList = new List<string> { "test", "eetlepel", "programmeren" };
        public string guessedWord = "";
        private string _secretword;
        public List<char> filledLetters = new List<char>();

        public void Init(string secretword)
        {
            //ShowWord(secretword);
            Console.WriteLine("Raad het woord: ");
            _secretword = secretword;
            foreach (char c in secretword)
            {

                guessedWord += ".";
            }
            Console.WriteLine(guessedWord);
            Console.Write("\n");
        }

        public bool PlayHangmanGame(HangmanGame game)
        {
            int tries = 8;
            do
            {
                char c = game.ReadChar(filledLetters);
                filledLetters.Add(c);
                if (!game.CheckChar(c))
                {
                    tries -= 1;
                }
                game.ShowFilledChar(filledLetters);
                game.ShowWord(game.guessedWord);
                Console.WriteLine("Aantal pogingen: " + tries);
            } while (!WordGuessed(game.guessedWord) && tries != 0);
            return game.WordGuessed(game.guessedWord);
        }

        public string RndWord(List<string> list)
        {
            Random r = new Random();
            int i = r.Next(0, list.Count);
            return list[i];
        }

        public void ShowWord(string word)
        {
            char[] chs = word.ToCharArray();
            foreach (char c in chs)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine("\n");
        }

        public bool CheckChar(char c)
        {
            bool b = false;
            char[] chararr = guessedWord.ToCharArray();


            for (int i = 0; i < _secretword.Length; i++)
            {
                if (_secretword[i] == c)
                {
                    b = true;
                    chararr[i] = c;
                }
            }
            guessedWord = new string(chararr);
            return b;
        }

        public bool GuessedWord()
        {
            if (_secretword == guessedWord)
            {
                return true;
            }
            return false;
        }

        public char ReadChar(List<char> bannedchars)
        {
            char c;
            do
            {
                Console.WriteLine("Geef letter: ");
                c = char.Parse(Console.ReadLine());

            } while (bannedchars.Contains(c));
            return c;
        }

        public void ShowFilledChar(List<char> filledchars)
        {
            string s = "";
            foreach (char c in filledchars)
            {
                s += (c + " ");
            }
            Console.WriteLine("Ingevoerde characters: " + s);
        }

        public bool WordGuessed(string gw)
        {
            if (_secretword.Equals(gw))
            {
                Console.WriteLine("Game gewonnen");
                Console.ReadKey();
                return true;
            }
            return false;
        }


    }
}
