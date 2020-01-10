using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTools;

namespace MyToolsApplication
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
            int num = ReadTools.ReadInt("Voer getal in: ");
            Console.WriteLine("Ingevoerde getal = {0}", num);

            string s = ReadTools.ReadString("Voer een woord in: ");
            Console.WriteLine("Ingevoerde woord {0}", s);
        }
    }
}
