internal class Program
{
    public static void putBoard(int[] squares)
    {
        Console.WriteLine();
        for (int i = 0; i < squares.Length; i++)
        {
            if (squares[i] > 0)
            {
                Console.Write($" {squares[i]} ");
            }
            else if (squares[i] == -1)
            {
                Console.Write(" X ");
            }
            else if (squares[i] == -2)
            {
                Console.Write(" O ");
            }

            if (!((i+1) % 3 == 0))
            {
                Console.Write("|");
            }
            else if (i == squares.Length-1)
            {
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("\n---+---+---");
            }
        }
    }

    public static bool calculateEndGame(int[] squares)
    {
        // Horizontal win
        if (squares[0] == squares[1] && squares[1] == squares[2])
        {
            return true;
        }
        else if (squares[3] == squares[4] && squares[4] == squares[5])
        {
            return true;
        }
        else if (squares[6] == squares[7] && squares[7] == squares[8])
        {
            return true;
        }
        // Vertical win
        else if (squares[0] == squares[3] && squares[3] == squares[6])
        {
            return true;
        }
        else if (squares[1] == squares[4] && squares[4] == squares[7])
        {
            return true;
        }
        else if (squares[2] == squares[5] && squares[5] == squares[8])
        {
            return true;
        }
        // Diagonal win
        else if (squares[0] == squares[4] && squares[4] == squares[8])
        {
            return true;
        }
        else if (squares[2] == squares[4] && squares[4] == squares[6])
        {
            return true;
        }
        else
        {
            if (squares[0] < 0 && squares[1] < 0 && squares[2] < 0
                    && squares[3] < 0 && squares[4] < 0 && squares[5] < 0
                    && squares[6] < 0 && squares[7] < 0 && squares[8] < 0)
            {
                return true;
            }
        }

        return false;
    }

    public static void gameLoop(int[] squares)
    {
        bool gameOver = false;
        int inputSquare;

        while (!(gameOver))
        {
            //X's turn
            do
            {
            Console.Write("X's turn to choose a square (1-9): ");
            inputSquare = Convert.ToInt32(Console.ReadLine());
            if (inputSquare < 1 || inputSquare > 9)
            {
                Console.WriteLine("Please enter a valid square number (1-9).");
            }
            else if (squares[inputSquare-1] < 0)
            {
                Console.WriteLine("That square has already been taken. Please choose a different one.\n");
            }
            } while ((inputSquare < 1 || inputSquare > 9) || squares[inputSquare-1] < 0);
            
            squares[inputSquare-1] = -1;

            putBoard(squares);
            gameOver = calculateEndGame(squares);
            if (gameOver)
            {
                break;
            }

            //O's turn
            do
            {
            Console.Write("O's turn to choose a square (1-9): ");
            inputSquare = Convert.ToInt32(Console.ReadLine());
            if (inputSquare < 1 || inputSquare > 9)
            {
                Console.WriteLine("Please enter a valid square number (1-9).");
            }
            else if (squares[inputSquare-1] < 0)
            {
                Console.WriteLine("That square has already been taken. Please choose a different one.\n");
            }
            } while ((inputSquare < 1 || inputSquare > 9) || (inputSquare > 0 && squares[inputSquare-1] < 0));
            
            squares[inputSquare-1] = -2;

            putBoard(squares);
            gameOver = calculateEndGame(squares);
            if (gameOver)
            {
                break;
            }
        }
    }
    private static void Main(string[] args)
    {
        //Positive numbers indicate squares that haven't been played in.
        //-1 indicates a move by X; -2 indicates a move by O
        int[] squares = {1, 2, 3, 4, 5, 6, 7, 8, 9};
        putBoard(squares);

        // Game Loop
        gameLoop(squares);

        Console.WriteLine("Good game. Thanks for playing!\n");
    }
}