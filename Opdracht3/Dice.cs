using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht3
{
    class Dice
    {
        public int value;
        static Random rnd = new Random();

        public void ThrowDice()
        {
            value = rnd.Next(1, 6);
        }

        public void ShowValue()
        {
            Console.Write(value + " ");
        }
    }
}
