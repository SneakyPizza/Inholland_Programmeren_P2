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
        private Random _rand = new Random();

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Start();
        }

        private void Start()
        {
            Console.WriteLine("Input size");
            int size = int.Parse(Console.ReadLine());
            _matrix = new int[size, size];
            InitMatrixLinear(_matrix);
            PrintMatrixWithCross(_matrix);
            Console.ReadKey();
        }

        private void InitMatrix(int[,] matrix)
        {
            int num = 1;
            for(int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = num++;
                }
            }
        }

        private void InitMatrixLinear(int[,] matrix)
        {
            int s = (matrix.GetLength(0) * matrix.GetLength(0));
            for(int i = 1; i <= s; i++)
            {
                matrix[(i - 1) / matrix.GetLength(0), (i - 1) % matrix.GetLength(0)] = i;
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

        private void PrintMatrixWithCross(int[,] matrix)
        {
            int l = matrix.GetLength(0);

            for (int r = 0; r < l; r++)
            {
                for (int c = 0; c < l; c++)
                {
                    Console.ResetColor();
                    if (r == c)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    if (c == (matrix.GetLength(0) - r - 1))
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }

                    Console.Write(matrix[r, c] + "\t");
                    
                }
                Console.WriteLine();
            }
        }
    }
}
