using System;

namespace CandyCrushLogica
{
    public class CandyCrusher
    {
        public static bool ScoreRowCheck(RegularCandies[,] field)
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
                        if (curr == 3)
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

        public static bool ScoreColumnCheck(RegularCandies[,] field)
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
                        if (curr == 3)
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
