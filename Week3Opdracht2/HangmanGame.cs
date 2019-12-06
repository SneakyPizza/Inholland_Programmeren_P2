using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Opdracht2
{
    public class HangmanGame
    {
        private string _secretWord;
        public string _guessedWord;

        public void Init(string secretword)
        {
            Console.WriteLine("Raad het woord: ");
            foreach (char c in secretword)
            {
                Console.Write(".");
            }
        }
    }
}
