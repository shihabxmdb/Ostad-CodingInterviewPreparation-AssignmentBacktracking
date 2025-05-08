class Program
{
    
    static int count = 0;
    
    public static void Main(string[] args)
    {
       
        int n = int.Parse(Console.ReadLine());
        int[,] board = new int[n, n];
        Call(0, n,board);
        Console.WriteLine("Total Solutions=" + count);

    }


    static void Call(int r, int n, int[,] board)
    {
        if (r == n)
        {
            count++;
            return;
        }

        for (int c = 0; c < n; c++)
        {
            if (IsSafe(r, c, n, board))
            {
                board[r, c] = 1;
                Call(r + 1, n,board);
                board[r, c] = 0; //  Backtrack
                //return;
            }

            
        }
         return;
    }

    static bool IsSafe(int r, int c, int n, int[,] board)
        {
            //down check
            int r1 = r;
            while (r1 >= 0)
            {
                if (board[r1, c] == 1)
                {
                    return false;
                }
                r1--;
            }
          
            //left diagonal check
            r1 = r;
            int c1 = c;
            while (r1 >= 0 && c1 >= 0)
            {
                if (board[r1, c1] == 1)
                {
                    return false;
                }
                r1--;
                c1--;
            }
            //right diagonal check
            r1 = r;
            c1 = c;
            while (r1 >= 0 && c1 < n)
            {
                if (board[r1, c1] == 1)
                {
                    return false;
                }
                r1--;
                c1++;
            }

            return true;
        }
    
}
