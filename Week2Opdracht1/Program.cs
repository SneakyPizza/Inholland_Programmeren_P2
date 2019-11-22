using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Opdracht1
{
    class Program
    {
        private int[,] _matrix;
        private int _col;
        private int _row;
        private Random _rand = new Random();

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Start();
        }

        private void Start()
        {
            Console.WriteLine("Amount of Cols");
            _col = int.Parse(Console.ReadLine());
            Console.WriteLine("Amount of Rows");
            _row = int.Parse(Console.ReadLine());
            _matrix = new int[_row, _col];
            InitMatrix(_matrix);
            PrintMatrix(_matrix);
            Console.ReadKey();
        }

        private void InitMatrix(int[,] matrix)
        {
            int num = 1;
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = num++;
                }
            }
        }

        private void PrintMatrix(int[,] matrix)
        {
            for(int r = 0; r < matrix.GetLength(0); r++)
            {
                for(int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
