using System;

// <summary>
// This is a solution to the tic tac toe assignment.
// </summary>
class Program
{
    static void Main(string[] args)
    {
        //Positive numbers indicate squares that haven't been played in.
        //-1 indicates a move by X; -2 indicates a move by O
        int[] board = {1, 2, 3, 4, 5, 6, 7, 8, 9};
        displayBoard(board);

        // Game Loop
        gameLoop(board);

        Console.WriteLine("Good game. Thanks for playing!\n");
    }

    // <summary>
    // Displays the 3x3 board to the screen.
    // </summary>
    // <param name="board">The board</param>
    static void displayBoard(int[] board)
    {
        Console.WriteLine();
        for (int i = 0; i < board.Length; i++)
        {
            if (board[i] > 0)
            {
                Console.Write($" {board[i]} ");
            }
            else if (board[i] == -1)
            {
                Console.Write(" X ");
            }
            else if (board[i] == -2)
            {
                Console.Write(" O ");
            }

            if (!((i+1) % 3 == 0))
            {
                Console.Write("|");
            }
            else if (i == board.Length-1)
            {
                Console.WriteLine("\n");
            }
            else
            {
                Console.WriteLine("\n---+---+---");
            }
        }
    }

    // <summary>
    // Runs the game loop until the game board is full or somebody wins.
    // </summary>
    // <param name="board">The board</param>
    static void gameLoop(int[] board)
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
            else if (board[inputSquare-1] < 0)
            {
                Console.WriteLine("That square has already been taken. Please choose a different one.\n");
            }
            } while ((inputSquare < 1 || inputSquare > 9) || board[inputSquare-1] < 0);
            
            board[inputSquare-1] = -1;

            displayBoard(board);
            gameOver = calculateEndGame(board);
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
            else if (board[inputSquare-1] < 0)
            {
                Console.WriteLine("That square has already been taken. Please choose a different one.\n");
            }
            } while ((inputSquare < 1 || inputSquare > 9) || (inputSquare > 0 && board[inputSquare-1] < 0));
            
            board[inputSquare-1] = -2;

            displayBoard(board);
            gameOver = calculateEndGame(board);
            if (gameOver)
            {
                break;
            }
        }
    }

    // <summary>
    // Determines if the game has ended, either through a win or a tie.
    // </summary>
    // <param name="board">The board</param>
    // <returns>True if the game should end</returns>
    static bool calculateEndGame(int[] board)
    {
        // Horizontal win
        if ((board[0] == board[1] && board[1] == board[2])
            || (board[3] == board[4] && board[4] == board[5])
            || (board[6] == board[7] && board[7] == board[8])
            )
        {
            return true;
        }
        // Vertical win
        else if ((board[0] == board[3] && board[3] == board[6])
                 || (board[1] == board[4] && board[4] == board[7])
                 || (board[2] == board[5] && board[5] == board[8])
                 )
        {
            return true;
        }
        // Diagonal win
        else if ((board[0] == board[4] && board[4] == board[8])
                 || (board[2] == board[4] && board[4] == board[6])
                 )
        {
            return true;
        }
        else
        {
            // Board full, tie
            if (board[0] < 0 && board[1] < 0 && board[2] < 0
                && board[3] < 0 && board[4] < 0 && board[5] < 0
                && board[6] < 0 && board[7] < 0 && board[8] < 0
                )
            {
                return true;
            }
        }

        return false;
    }
}
