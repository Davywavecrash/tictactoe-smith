using System;
using System.Threading;
namespace TIC_TAC_TOE
{
    class Program
    {
        static char[] num = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player =1;
        static int plch;
        static int flag = 0;
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("player-1: X and player-2: O");
                Console.WriteLine("\n");
                if (player % 2 == 0)
                {
                    Console.WriteLine("player 2 turn");
                }
                else
                {
                    Console.WriteLine("player 1 turn");
                }
                Console.WriteLine("\n");
                Board();
                plch = int.Parse(Console.ReadLine());
                if (num[plch] != 'X' && num[plch] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        num[plch] = 'O';
                        player++;
                    }
                    else
                    {
                        num[plch] = 'X';
                        player++;
                    }
                }
                else
                {
                    Console.WriteLine("row {0} already marked with {1}", plch, num[plch]);
                    Console.WriteLine("\n");
                    Console.WriteLine("loading...please wait");
                    Thread.Sleep(2000);
                }
                flag = CheckWin();
            }
            while (flag != 1 && flag != -1);
            Console.Clear();
            Board();
            if (flag == 1)
            {
                Console.WriteLine("player {0} has won", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("Draw");
            }
            Console.ReadLine();
        }
        private static void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", num[1], num[2], num[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", num[4], num[5], num[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", num[7], num[8], num[9]);
            Console.WriteLine("     |     |      ");
        }
        private static int CheckWin()
        {
            #region Horizontal Win Condition
            //row one
            if (num[1] == num[2] && num[2] == num[3])
            {
                return 1;
            }
            //row two
            else if (num[4] == num[5] && num[5] == num[6])
            {
                return 1;
            }
            //row three
            else if (num[7] == num[8] && num[8] == num[9])
            {
                return 1;
            }
            #endregion
            #region Vertical Win Condition
            if (num[1] == num[4] && num[4] == num[7])
            {
                return 1;
            }
            //row two
            else if (num[2] == num[5] && num[5] == num[8])
            {
                return 1;
            }
            //row three
            else if (num[3] == num[6] && num[6] == num[9])
            {
                return 1;
            }
            #endregion
            #region Diagonal Win Condition
            else if (num[1] == num[5] && num[5] == num[9])
            {
                return 1;
            }
            else if (num[3] == num[5] && num[5] == num[7])
            {
                return 1;
            }
            #endregion
            #region Check Draw
            else if (num[1] != '1' && num[2] != '2' && num[3] != '3' && num[4] != '4' && num[5] != '5' && num[6] != '6' && num[7] != '7' && num[8] != '8' && num[9] != '9')
            {
                return -1;
            }
            #endregion
            else
            {
                return 0;
                Console.WriteLine("\n");
                Console.WriteLine("loading...please wait");
                Thread.Sleep(2000);
            }
        }
    }
}



//Partial inspiration was from https://www.c-sharpcorner.com/UploadFile/75a48f/tic-tac-toe-game-in-C-Sharp/
//However, I still typed this %95 by hand and added fucntionality for vertical win conditions, among many smaller differences
//I used the above website to correct some issues I was struggling with