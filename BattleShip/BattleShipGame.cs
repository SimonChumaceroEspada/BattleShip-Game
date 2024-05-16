using System;
using System.Collections.Generic;

namespace Battleship
{
    class BattleShipGame
    {
        static char[] playerCells;
        static char[] computerCells;
        static Random rnd = new Random();
        static int playerShip;
        static int computerShip;
        static List<int> playerMoves = new List<int>();
        static List<int> computerMoves = new List<int>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Battleship!");
            Console.WriteLine("Enter the number of cells for the game:");
            int cellCount;
            while (!int.TryParse(Console.ReadLine(), out cellCount) || cellCount < 2 || cellCount > 100)
            {
                Console.WriteLine("Please enter a valid number (greater than 1 and less or equal than 100):");
            }

            InitializeGame(cellCount);

            Console.WriteLine("Please choose a cell (1-" + cellCount + ") to hide your ship:");

            // Place players ship with verification if the cell is valid
            bool validPosition = false;
            while (!validPosition)
            {
                int.TryParse(Console.ReadLine(), out playerShip);
                if (playerShip >= 1 && playerShip <= cellCount)
                {
                    validPosition = true;
                }
                else
                {
                    Console.WriteLine("Please choose a valid cell (1-" + cellCount + "):");
                }
            }

            // Place computer's ship
            computerShip = rnd.Next(1, cellCount + 1);

            Console.Clear();

            // Start the game
            while (true)
            {
                ShowBoard(cellCount);
                Console.WriteLine("Your turn. Choose a cell (1-" + cellCount + "):");
                int playerAttempt;
                while (!int.TryParse(Console.ReadLine(), out playerAttempt) || playerAttempt < 1 || playerAttempt > cellCount)
                {
                    Console.WriteLine("Please enter a valid number (1-" + cellCount + "):");
                }

                playerMoves.Add(playerAttempt);

                // My Win Condition
                if (playerAttempt == computerShip)
                {
                    ShowBoard(cellCount);
                    Console.WriteLine("Congratulations! You've sunk the computer's ship! You win!");
                    break;
                }
                else
                {
                    computerCells[playerAttempt - 1] = 'X';
                }

                // Check if the move has already been made
                int computerAttempt;
                do
                {
                    computerAttempt = rnd.Next(1, cellCount + 1);
                } while (computerMoves.Contains(computerAttempt));

                computerMoves.Add(computerAttempt);

                if (computerAttempt == playerShip)
                {
                    ShowBoard(cellCount);
                    Console.WriteLine("The computer has sunk your ship! You lose!");
                    break;
                }
                else
                {
                    playerCells[computerAttempt - 1] = 'X';
                }

                Console.Clear();
            }
        }

        // Initialize the game with empty cells in vectors
        static void InitializeGame(int cellCount)
        {
            playerCells = new char[cellCount];
            computerCells = new char[cellCount];
            for (int i = 0; i < cellCount; i++)
            {
                playerCells[i] = '-';
                computerCells[i] = '-';
            }
        }

        static void ShowBoard(int cellCount)
        {
            Console.WriteLine("Computer's Cells:");
            foreach (var cell in computerCells)
            {
                Console.Write($"[{cell}]");
            }
            Console.WriteLine();
            Console.WriteLine("Player's Cells:");
            foreach (var cell in playerCells)
            {
                Console.Write($"[{cell}]");
            }
            Console.WriteLine();
            Console.WriteLine("Player's Moves:");
            foreach (var move in playerMoves)
            {
                Console.Write($"[{move}]");
            }
            Console.WriteLine();
            Console.WriteLine("Computer's Moves:");
            foreach (var move in computerMoves)
            {
                Console.Write($"[{move}]");
            }
            Console.WriteLine();
        }
    }
}
