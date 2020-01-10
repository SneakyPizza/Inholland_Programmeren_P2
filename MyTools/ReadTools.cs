using System;
using System.Collections.Generic;
using System.Text;

namespace MyTools
{
    public class ReadTools
    {
        public static int ReadInt(string question)
        {
            int num = int.Parse(Console.ReadLine());
            return num;
        }

        public static string ReadString(string question)
        {
            string n = Console.ReadLine();
            return n;
        }
    }
}
