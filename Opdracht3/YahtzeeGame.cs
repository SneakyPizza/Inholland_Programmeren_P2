using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht3
{
    class YahtzeeGame
    {
        private Dice[] _dices = new Dice[5];

        public void Init()
        {
            for(int i = 0; i < _dices.Length; i++)
            {
                _dices[i] = new Dice();
            }
        }

        public void Throw()
        {
            for(int i = 0; i < _dices.Length; i++)
            {
                _dices[i].ThrowDice();
            }
            
        }

        public void ShowValues()
        {
            foreach( Dice d in _dices)
            {
                d.ShowValue();
            }
            Console.Write("\n");
        }

        public bool Yahtzee()
        {
            int firstvalue = _dices.First().value;

            for(int i = 0; i < _dices.Length - 1; i++)
            {
                if(_dices[i].value != firstvalue)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
