using System;
using System.Threading;


namespace XOBoard
{
    class Program
    {

        static string[] boardArr = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " " };
        static int player = 1;
        static int row;
        static int column;
        static string status= "None";
        static bool flag;
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to XOBoard Game!");
                Console.WriteLine("You have to enter row and column number whan it's your turn");
                Console.WriteLine("Player1: X   Player2: O");
                Console.WriteLine("\n");
                flag = false;

                if (player % 2 == 0)
                {
                    Console.WriteLine("Player2, your turn!");
                }
                else
                {
                    Console.WriteLine("Player1, your turn!");
                }

                

                Console.WriteLine("\n");
                Display();

                Console.WriteLine("Enter row number: ");
                row = int.Parse(Console.ReadLine()) -1;
                if (row < 0 || row > 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter valid number between 1 and 3");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    continue;
                }
                Console.WriteLine("Enter column number: ");
                column = int.Parse(Console.ReadLine()) - 1;
                if (column < 0 || column > 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter valid number between 1 and 3");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    Console.ResetColor();
                    continue;
                }

                Put(row, column);

                status = Status();

                if (!(flag))
                {
                    if (player % 2 == 0)
                        player = 1;
                    else
                        player = 2;
                }
                    
            } while (status.Equals("None"));

            if (status.Equals("Draw"))
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(50, 10);
                Console.WriteLine("It's a draw!");
                Console.ResetColor();
            }
                
            else
            {
                if (player % 2 == 0)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(40, 10);
                    Console.WriteLine("Congratulations Player2, you won!");
                    Console.ResetColor();
                }

                else
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(40, 10);
                    Console.WriteLine("Congratulations Player1, you won!");
                    Console.ResetColor();
                }
            }
                
                    
        }


        public static void Put(int row, int col)
        {
            if (row == 0)
                if (string.IsNullOrWhiteSpace(boardArr[row + col]))
                    if (player % 2 == 0)
                        boardArr[row + col] = "O";
                    else
                        boardArr[row + col] = "X";
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please choose empty cell!");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    flag = true;
                    return;
                }
                    
            if (row == 1)
                if (string.IsNullOrWhiteSpace(boardArr[row+col+2]))
                    if (player % 2 == 0)
                        boardArr[row+col+2] = "O";
                    else
                        boardArr[row+col+2] = "X";
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please choose empty cell!"); 
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    flag = true;
                    return;
                }
            if (row == 2)
                if (string.IsNullOrWhiteSpace(boardArr[row + col + 4]))
                    if (player % 2 == 0)
                        boardArr[row + col + 4] = "O";
                    else
                        boardArr[row + col + 4] = "X";
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please choose empty cell!");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    flag = true;
                    return;
                }

        }

        public static string Status()
        {

            if (boardArr[0] == boardArr[3] && boardArr[3] == boardArr[6] && !(string.IsNullOrWhiteSpace(boardArr[0])))
            {
                flag = true;
                return boardArr[0];
            }      
            
            else if (boardArr[1] == boardArr[4] && boardArr[4] == boardArr[7] && !(string.IsNullOrWhiteSpace(boardArr[1])))
            {
                flag = true;
                return boardArr[1];
            }

            else if (boardArr[2] == boardArr[5] && boardArr[5] == boardArr[8] && !(string.IsNullOrWhiteSpace(boardArr[2])))
            {
                flag = true;
                return boardArr[2];
            }

            else if (boardArr[0] == boardArr[1] && boardArr[1] == boardArr[2] && !(string.IsNullOrWhiteSpace(boardArr[0])))
            {
                flag = true;
                return boardArr[0];
            }

            else if (boardArr[3] == boardArr[4] && boardArr[4] == boardArr[5] && !(string.IsNullOrWhiteSpace(boardArr[3])))
            {
                flag = true;
                return boardArr[3];
            }

            else if (boardArr[6] == boardArr[7] && boardArr[7] == boardArr[8] && !(string.IsNullOrWhiteSpace(boardArr[6])))
            {
                flag = true;
                return boardArr[6];
            }

            else if (boardArr[0] == boardArr[4] && boardArr[4] == boardArr[8] && !(string.IsNullOrWhiteSpace(boardArr[0])))
            {
                flag = true;
                return boardArr[0];
            }

            else if (boardArr[2] == boardArr[4] && boardArr[4] == boardArr[6] && !(string.IsNullOrWhiteSpace(boardArr[2])))
            {
                flag = true;
                return boardArr[2];
            }
            else
            {
                foreach (string str in boardArr)
                {
                    if (string.IsNullOrWhiteSpace(str))
                        return "None";
                }
                return "Draw";
            }
        }

        public static void Display()
        {
            Console.WriteLine("     {0}     {1}    {2}  ", "1", "2", "3");
            for (int i = 0, j = 0; i < 3; i++)
            {
                //Console.WriteLine("{0}", i);
                Console.WriteLine("        |     |     ");
                Console.WriteLine("{0}    {1}  |  {2}  |  {3}  ", i+1, boardArr[j], boardArr[j + 1], boardArr[j + 2]);
                if (j < 6)
                {
                    Console.WriteLine("   _____|_____|_____");
                }
                else
                {
                    Console.WriteLine("        |     |     ");
                }
                j = j + 3;
            }
        }
    }
}
