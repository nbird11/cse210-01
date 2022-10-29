using System;

namespace CSE210_01
{
    // <summary>
    // This is a solution to the tic tac toe assignment.
    // </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            //Positive numbers indicate squares that haven't been played in.
            //-1 indicates a move by X; -2 indicates a move by O
            int[] board = {1, 2, 3, 4, 5, 6, 7, 8, 9};
            displayBoard(board);

            // Game Loop
            gameLoop(board);
        }

        // <summary>
        // Displays the 3x3 board to the screen.
        // </summary>
        // <param name="board">The board</param>
        public static void displayBoard(int[] board)
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" X ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (board[i] == -2)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(" O ");
                    Console.ForegroundColor = ConsoleColor.White;
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
        public static void gameLoop(int[] board)
        {
            bool gameOver = false;
            string winner;
            int inputSquare;

            while (!(gameOver))
            {
                //X's turn
                do
                {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("X");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("'s turn to choose a square (1-9): ");
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
                winner = calculateWinner(board);
                gameOver = calculateEndGame(winner);
                if (gameOver)
                {
                    break;
                }

                //O's turn
                do
                {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("O");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("'s turn to choose a square (1-9): ");
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
                winner = calculateWinner(board);
                gameOver = calculateEndGame(winner);
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
        public static string calculateWinner(int[] board)
        {
            // Horizontal win
            // X
            if (
                board[0] == -1 && (board[0] == board[1] && board[1] == board[2])
                || board[3] == -1 && (board[3] == board[4] && board[4] == board[5])
                || board[6] == -1 && (board[6] == board[7] && board[7] == board[8])
                )
            {
                
                return "X";
            }
            // O
            else if (
                board[0] == -2 && (board[0] == board[1] && board[1] == board[2])
                || board[3] == -2 && (board[3] == board[4] && board[4] == board[5])
                || board[6] == -2 && (board[6] == board[7] && board[7] == board[8])
                )
            {
                return "O";
            }
            // Vertical win
            // X
            else if (
                    board[0] == -1 && (board[0] == board[3] && board[3] == board[6])
                    || board[1] == -1 && (board[1] == board[4] && board[4] == board[7])
                    || board[2] == -1 && (board[2] == board[5] && board[5] == board[8])
                    )
            {
                return "X";
            }
            // O
            else if (
                    board[0] == -2 && (board[0] == board[3] && board[3] == board[6])
                    || board[1] == -2 && (board[1] == board[4] && board[4] == board[7])
                    || board[2] == -2 && (board[2] == board[5] && board[5] == board[8])
                    )
            {
                return "O";
            }
            // Diagonal win
            // X
            else if (
                    board[0] == -1 && (board[0] == board[4] && board[4] == board[8])
                    || board[2] == -1 && (board[2] == board[4] && board[4] == board[6])
                    )
            {
                return "X";
            }
            // O
            else if (
                    board[0] == -2 && (board[0] == board[4] && board[4] == board[8])
                    || board[2] == -2 && (board[2] == board[4] && board[4] == board[6])
                    )
            {
                return "O";
            }
            else
            {
                // Board full, tie
                if (board[0] < 0 && board[1] < 0 && board[2] < 0
                    && board[3] < 0 && board[4] < 0 && board[5] < 0
                    && board[6] < 0 && board[7] < 0 && board[8] < 0
                    )
                {
                    return "tie";
                }
            }

            return "";
        }

        public static bool calculateEndGame(string winner)
        {
            if (winner == "tie")
            {
                Console.WriteLine("Tie game, no winner.");
                return true;
            }
            else if (winner == "X")
            {
                Console.Write("Player ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("X");
                Console.ForegroundColor = ConsoleColor.White; 
                Console.WriteLine(" is the winner!");
                return true;
            }
            else if (winner == "O")
            {
                Console.Write("Player ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("O");
                Console.ForegroundColor = ConsoleColor.White; 
                Console.WriteLine(" is the winner!");
                return true;
            }
            
            return false;
        }
    }
}