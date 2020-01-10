using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6Opdracht1
{
    class Program
    {
        private char[] _letters = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' };
        private ChessPiece[,] chessboard = new ChessPiece[8,8];

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Start();
        }

        private void Start()
        {
            InitChessboard(chessboard);
            DisplayChessboard(chessboard);
            PlayChess(chessboard);
            Console.ReadKey();
        }

        private void InitChessboard(ChessPiece[,] cb)
        {
            for(int r = 0; r < cb.GetLength(0); r++)
            {
                for(int c = 0; c < cb.GetLength(1); c++)
                {
                    cb[r, c] = null;
                }
            }
            PutChessPieces(cb);
        }

        private void DisplayChessboard(ChessPiece[,] cb)
        {
           Console.Write("   " + " A "+ " B " + " C " + " D " + " E " + " F " + " G " + " H " + "\n");

            for (int r = 0; r < chessboard.GetLength(0); r++)
            {
                Console.Write(r + 1 + "  ");
                for (int c = 0; c < chessboard.GetLength(1); c++)
                {
                    if ((r + c ) %2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                    } else
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }
                    ChessPiece cp = chessboard[r, c];
                    DisplayChessPiece(cp);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
           /* for (int c = 0; c < cb.GetLength(0);c++)
            {
                for(int r = -1; r < cb.GetLength(1); r++)
                {
                    if (r == -1)
                    {
                        Console.Write((c + 1) + "  ");
                    } else
                    {
                        if ((r+c)%2==0)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                        }
                    }
                    
                    
                    if(r >= 0)
                    {
                        DisplayChessPiece(cb[r, c]);
                    }
                }
                Console.WriteLine();
                Console.ResetColor();
            } */

            
        }

        private void PlayChess(ChessPiece[,] cb)
        {
            do
            {
                Position frompos = ReadPosition("Select chesspiece");
                Position topos = ReadPosition("Select a target location");
                CheckMove(cb, frompos, topos);
                DisplayChessboard(chessboard);
                Console.ReadKey();
            }
            while (KingAlive());
           
        }

        private void PutChessPieces(ChessPiece[,] cb)
        {
            ChessPieceType[] order = { ChessPieceType.Rook, ChessPieceType.Knight, ChessPieceType.Bishop, ChessPieceType.King,
                                       ChessPieceType.Queen, ChessPieceType.Bishop, ChessPieceType.Knight, ChessPieceType.Rook };
            ChessPiece cp;
            int num = 0;
           for(int c = 0; c < cb.GetLength(1); c++)
           {   
                for(int r = 0; r < cb.GetLength(0); r++)
                {
                    if(num > 6)
                    {
                        num = 0;
                    }
                    cp = new ChessPiece();
                    if (c == 0 || c == 1)
                    {
                        cp.cpColor = ChessPieceColor.White;

                    } else if(c == 6 || c == 7)
                    {
                        cp.cpColor = ChessPieceColor.Black;
                    }

                    if (c == 0 || c == 7)
                    {
                        cp.cpType = order[num];
                        cb[r, c] = cp;
                    } else if (c == 1 || c == 6)
                    {
                        cp.cpType = ChessPieceType.Pawn;
                        cb[r, c] = cp;
                    }
                }
                num++;
           }
        }

        private void DisplayChessPiece(ChessPiece cp)
        {
            string l = "   ";
            if(cp != null)
            {
                if (cp.cpColor == ChessPieceColor.Black)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                l = cp.cpType.ToString();
                l.ToLower();
                l = " " + l[0] + " ";
                if (cp.cpType == ChessPieceType.Queen || cp.cpType == ChessPieceType.King)
                {
                    l.ToUpper();
                } else
                {
                    l = char.ToLower( l[1]) + " ";
                    l = " " + l;
                }

            } 

            Console.Write(l);
        }

        Position ReadPosition(string question)
        {
            Position p = new Position();
            Console.WriteLine(question);
            string input = Console.ReadLine().ToUpper();
            int col = 0;
            int row = 0;

            int c = input[0] - 'A';
            int r = int.Parse(input[1].ToString()) -1;
            

           /* if (ValidateString(input))
            {
                char[] chars = input.ToCharArray();
                try
                {
                    char r = input[0];
                    string s = input[1] + "";
                    int.TryParse(s, out row);

                    for (int i = 0; i < _letters.Length; i++)
                    {
                        if (input[0] == _letters[i])
                        {
                            col = i;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }*/
                p.column = c;
                p.row = r;
            
            return p;
        }

        private void DoMove(ChessPiece[,] cb, Position from, Position to)
        {
            /* Console.WriteLine("test");
             cb[to.column, to.row] = cb[from.column, from.row];
             cb[from.column, from.row] = null;
             Console.WriteLine("Succesfull move," + cb[to.column, to.row].cpType.ToString() + " Moved");
             Console.ReadKey();
             DisplayChessboard(cb);*/

            chessboard[to.row, to.column] = chessboard[from.row, from.column];
            chessboard[from.row, from.column] = null;
        }

        private void CheckMove(ChessPiece[,] cb, Position from, Position to)
        {
            /* 
            -the from-position contains a chess piece;
            -the to-position does not contain a chess piece;
            -the move is valid for the specific chess piece (at the from-position); to check this, call method ValidMove, see next;
            */
            try
            {
                if (cb[from.column, from.row] != null)
                {
                    if(cb[to.column, to.row] == null)
                    {
                        ValidMove(cb[from.column, from.row], from, to);
                        
                    }
                    
                }
                DoMove(chessboard, from, to);
            }
            catch(Exception e)
            {
                if(e != null)
                {
                    Console.WriteLine("Invalid move");
                    Console.WriteLine("From: " + from.column + " " + from.row);
                    Console.WriteLine("To:   " + to.column + " " + to.row);
                }
                Console.ReadKey();
            }

        }

        private bool ValidMove(ChessPiece cp, Position from, Position to)
        {
            /*  rook    hor * ver = 0
                knight  hor * ver = 2
                bishop  hor = ver
                king    hor = 1 and/or ver = 1
                queen   hor * ver = 0 or hor = ver
                pawn   hor = 0 and ver = 1 
            */

            int hor = Math.Abs(from.row - to.row);
            int ver = Math.Abs(from.column - to.column);
            if(hor == 0  && ver == 0)
            {
                return false;
            }
            switch (cp.cpType)
                {
                    case (ChessPieceType.Rook):
                        if (hor * ver == 0)
                            return true;
                        break;
                    case (ChessPieceType.Knight):
                        if (hor * ver == 2)
                            return true;
                        break;
                    case (ChessPieceType.Bishop):
                        if (hor == ver)
                            return true;
                        break;
                    case (ChessPieceType.King):
                        if (hor == 1 || ver == 1)
                            return true;
                        break;
                    case (ChessPieceType.Queen):
                        if (hor * ver == 0 || hor == ver)
                            return true;
                        break;
                    case (ChessPieceType.Pawn):
                        if ((ver == 0) && (hor == 1))
                            return true;
                        break;
                    default:
                        Console.WriteLine("The piece cant walk there");
                        return false;
                        
                }
            PlayChess(chessboard);
            return false;
        }

       private bool ValidateString(string input)
        {
            try
            {
                char[] chars = input.ToCharArray();
                if(chars.Length > 2) { return false; }
            
                for(int i = 0; i < _letters.Length; i++)
                {
                    if(chars[0] == _letters[i])
                    {
                        return true;
                    }
                }
            
                int num;
                string s = chars[1].ToString();
                bool succes = int.TryParse(s, out num);
                if (!succes)
                {
                    return false;
                } else if(num > 8)
                {
                    return false;
                }
                
            } catch (IndexOutOfRangeException IndexEx)
            {
                Console.WriteLine(IndexEx.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }

        private bool KingAlive()
        {
            return true;
        }
    }
}
