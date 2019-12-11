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

        private HangmanGame _hangmangame;

        static void Main(string[] args)
        {
            Program p = new Program();
          
            p.Start();
        }

        private void Start()
        {
            _hangmangame = new HangmanGame();
            _hangmangame.Init(_hangmangame.RndWord(_wordList));
            _hangmangame.PlayHangmanGame(_hangmangame);
        }


    }
}
