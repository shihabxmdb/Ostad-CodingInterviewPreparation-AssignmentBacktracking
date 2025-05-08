using System;

class Program
{
    static int maxCount = 0;
    static void Main()
    {
        Console.Write("Enter  size : ");
        int n = int.Parse(Console.ReadLine());
        int result = MaxKnights(n);
        Console.WriteLine("Maximum knights : " + result);
    }
    static int MaxKnights(int n)
    {
        int[,] board = new int[n, n];
        maxCount = 0;
        Solve(board, n, 0, 0, 0);
        return maxCount;
    }

    static void Solve(int[,] board, int n, int row, int col, int count)
    {
        if (row == n)
        {
            maxCount = Math.Max(maxCount, count);
            return;
        }

        int nextRow = (col + 1 == n) ? row + 1 : row;
        int nextCol = (col + 1) % n;

        // Try placing a knight
        if (IsSafe(board, row, col, n))
        {
            board[row, col] = 1;
            Solve(board, n, nextRow, nextCol, count + 1);
            board[row, col] = 0; 
        }

        //W
        //ithout placing a knight
        Solve(board, n, nextRow, nextCol, count);
    }

    static bool IsSafe(int[,] board, int row, int col, int n)
    {
      
        if (row + 2 < n && col - 1 >= 0 && board[row + 2,col - 1] == 1) return false;
        if (row + 2 < n && col +1 < n && board[row + 2, col + 1] == 1) return false;

        if (row - 2 >=0 && col - 1 >=0 && board[row - 2, col - 1] == 1) return false;
        if (row - 2 >=0 && col + 1 < n && board[row - 2, col + 1] == 1) return false;
     
        if (col - 2 >=0 && row - 1 >= 0 && board[row - 1, col - 2] == 1) return false;
        if (col - 2 >=0 && row + 1 < n && board[row + 1, col - 2] == 1) return false;

        if (row - 1 >= 0 && col + 2 < n && board[row - 1, col + 2] == 1) return false;
        if (row + 1 < n && col + 2 < n && board[row +1, col + 2] == 1) return false;
        return true;
    }




}
