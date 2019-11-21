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
            _matrix = new int[_col, _row];
            InitMatrix(_matrix);
            PrintMatrix(_matrix);
            Console.ReadKey();
        }

        private void InitMatrix(int[,] matrix)
        {
            int value = 1;
            for (int r = 1; r < matrix.GetLength(0); r++)
            {
                for (int c = 1; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = r * c + 1;
                }
            }
        }

        private void PrintMatrix(int[,] matrix)
        {
            for(int r = 1; r < matrix.GetLength(0); r++)
            {
                for(int c = 1; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
