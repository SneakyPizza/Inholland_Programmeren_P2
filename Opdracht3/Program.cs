using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht3
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Start();
        }

        private void Start()
        {
            YahtzeeGame yg = new YahtzeeGame();
            yg.Init();
            PlayYahtzee(yg);
        }

        private void PlayYahtzee(YahtzeeGame game)
        {
            int amountcount = 0;
            do
            {
                game.Throw();
                game.ShowValues();
                amountcount++;
            }
            while (!game.Yahtzee());

            Console.WriteLine("Aantal pogingen nodig voor yahtzee:{0}", amountcount);
        }
    }
}
