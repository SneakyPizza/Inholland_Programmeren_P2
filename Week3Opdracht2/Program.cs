using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Opdracht2
{
    class Program
    {
        private List<string> _wordList = new List<string> { "Test", "Eetlepel", "Programmeren" };
        private List<char> _filledChars;
        private HangmanGame _hangmangame;

        static void Main(string[] args)
        {
            Program p = new Program();
          
            p.Start();
        }

        private void Start()
        {
            _hangmangame = new HangmanGame();
            _wordList = new List<string>();
            _hangmangame.Init(RndWord(_wordList));
            Console.ReadKey();
        }

        private string RndWord(List<string> list)
        {
            Random r = new Random();
            int i = r.Next(list.Count);
            return list[i];
        }

        private void CheckFilledChar(char c)
        {

        }
    }
}
