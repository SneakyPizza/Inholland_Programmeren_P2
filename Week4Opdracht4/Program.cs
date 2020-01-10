using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Week4Opdracht4
{
    class Program
    {
        private const int POINTSCORE = 3;
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Start();
        }

        private void Start()
        {
            RegularCandies[,] playfield = new RegularCandies[7, 7];
            InitCandies(playfield);
            PrintCandies(playfield);
            ScoreRowCheck(playfield);
            ReadPlayfield("Playfield");
            WritePlayfield(playfield, "Playfield");

            if (ScoreRowCheck(playfield))
            {
                Console.WriteLine("Score row found");
            }
            else
            {
                Console.WriteLine("Score row not found");
            }

            if (ScoreColumnCheck(playfield))
            {
                Console.WriteLine("Score column found");
            }
            else
            {
                Console.WriteLine("Score column not found");
            }

            Console.ReadKey();
        }

        private void WritePlayfield(RegularCandies[,] field, string filename)
        {
            StreamWriter sw = new StreamWriter(@"..\\..\\" + filename + ".txt");
            try
            {
                sw.WriteLine(field.GetLength(0));
                sw.WriteLine(field.GetLength(1));
                int w = field.GetLength(0);
                int h = field.GetLength(1);
                for (int i = 0; i < h; i++)
                {
                    string temp = "";
                    for (int b = 0; b < w; b++)
                    {
                        temp += (int)field[b, i] + " ";
                    }
                    sw.WriteLine(temp);
                }

            }
            finally
            {
                sw.Close();
            }
        }


        private RegularCandies[,] ReadPlayfield(string filename)
        {
            StreamReader sw = new System.IO.StreamReader(@"..\\..\\" + filename + ".txt");
            try
            {
                string[] line;
                RegularCandies[,] field = new RegularCandies[int.Parse(sw.ReadLine()), int.Parse(sw.ReadLine())];

                for (int i = 0; i < field.GetLength(1); i++)
                {
                    line = sw.ReadLine().Split(' ');
                    for (int b = 0; b < field.GetLength(0); b++)
                    {
                        field[b, i] = (RegularCandies)int.Parse(line[b]);
                    }
                }
                return field;
            }
            finally
            {
                sw.Close();
            }
        }
            private void InitCandies(RegularCandies[,] field)
            {
                Random rand = new Random();

                for (int r = 0; r < field.GetLength(0); r++)
                {
                    for (int c = 0; c < field.GetLength(1); c++)
                    {
                        field[r, c] = (RegularCandies)rand.Next(0, Enum.GetNames(typeof(RegularCandies)).Length);
                    }
                }
            }

            private void PrintCandies(RegularCandies[,] field)
            {

                for (int r = 0; r < field.GetLength(0); r++)
                {
                    for (int c = 0; c < field.GetLength(1); c++)
                    {
                        int v = (int)field[r, c];
                        switch (v)
                        {
                            case 0:
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case 1:
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case 4:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            case 5:
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                break;
                            default:
                                Console.ResetColor();
                                break;
                        }
                        Console.Write(" # ");
                        Console.ResetColor();
                    }
                    Console.WriteLine();
                }
            }

            private bool ScoreRowCheck(RegularCandies[,] field)
            {
                for (int r = 0; r < field.GetLength(0); r++)
                {
                    int curr = 1;
                    RegularCandies currcan = field[0, r];

                    for (int c = 1; c < field.GetLength(1); c++)
                    {
                        if (currcan == field[c, r])
                        {
                            curr++;
                            if (curr == POINTSCORE)
                            {
                                Console.WriteLine("On row {0} there {1} next to eachother.", r + 1, curr);
                                return true;
                            }
                        }
                        else
                        {
                            curr = 1;
                        }
                        currcan = field[c, r];
                    }
                }
                return false;
            }

            private bool ScoreColumnCheck(RegularCandies[,] field)
            {
                for (int r = 0; r < field.GetLength(0); r++)
                {
                    int curr = 1;
                    RegularCandies currcan = field[r, 0];

                    for (int c = 1; c < field.GetLength(1); c++)
                    {
                        if (currcan == field[r, c])
                        {
                            curr++;
                            if (curr == POINTSCORE)
                            {
                                Console.WriteLine("On column {0} there {1} next to eachother.", r + 1, curr);
                                return true;
                            }
                        }
                        else
                        {
                            curr = 1;
                        }
                        currcan = field[r, c];
                    }
                }
                return false;
            }
        }
    }
