using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Week4Opdracht2._1
{
    class Program
    {
        //private List<string> _wordList = new List<string> { "test", "eetlepel", "programmeren" };

        private HangmanGame _hangmangame;

        static void Main(string[] args)
        {
            Program p = new Program();

            p.Start();
        }

        private void Start()
        {
            _hangmangame = new HangmanGame();
            _hangmangame.Init(_hangmangame.RndWord(WordList()));
            _hangmangame.PlayHangmanGame(_hangmangame);
        }

        private List<string> WordList()
        {
            List<string> list = new List<string>();
            string w;
            StreamReader sr = new StreamReader(@"..\\..\\words.txt");
            while ((w = sr.ReadLine()) != null)
            {
                if (w.Length >= 3)
                    list.Add(w);
            }

            sr.Close();

            return list;
        }
    }
}
