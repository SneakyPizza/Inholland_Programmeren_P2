using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Opdracht2
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
            InitMatrixRandom(_matrix, 0,(size*size));
            PrintMatrix(_matrix);

            Console.WriteLine("Voer zoekgetal in: ");
            int num = int.Parse(Console.ReadLine());
            Position pos1 = FindNumber(_matrix, num);
            Console.WriteLine("Ingevoerde getal is {0}, deze is voor het eerst op [ row: {1}, column: {2} ]", num, pos1.row, pos1.column);
            Position pos2 = FindNumberBackwards(_matrix, num);
            Console.WriteLine("Het getal komt het laatst voor op [ row: {0}, column: {1} ]", pos2.row, pos2.column);
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

        private void InitMatrixRandom(int[,] matrix, int min, int max)
        {
            int size = matrix.GetLength(0);
            Random rand = new Random();
            
            for(int r =0; r < size; r++)
            {
                for(int c = 0; c < size; c++)
                {
                    matrix[r, c] = rand.Next(min, max);
                }
            }
        }

        private void PrintMatrix(int[,] matrix)
        {
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write(matrix[r, c] + "\t");
                }
                Console.WriteLine();
            }
        }

        Position FindNumber(int[,] matrix, int number)
        {
            Position pos = new Position();
            for(int r = 0; r < matrix.GetLength(0) -1; r++)
            {
                for(int c = 0; c < matrix.GetLength(1) -1 ; c++)
                {
                    if(number == matrix[r, c])
                    {
                        pos.row = r;
                        pos.column = c;
                        return pos;
                    }
                }
            }
            return pos;
        }
        //the -1 fixed the out of bound
        Position FindNumberBackwards(int[,] matrix, int number)
        {
            Position pos = new Position();
            for(int r = matrix.GetLength(0)-1; r >= 0; r--)
            {
                for(int c = matrix.GetLength(1)-1; c >= 0; c--)
                {
                    if(number == matrix[c, r])
                    {
                        pos.row = r;
                        pos.column = c;
                        return pos;
                    }
                }
            }
            return pos;
        }
    }
}
