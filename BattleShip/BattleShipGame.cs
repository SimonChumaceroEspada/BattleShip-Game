using System;
using System.Collections.Generic;

namespace Battleship
{
    class BattleShipGame
    {
        static char[] playerCells = new char[7];
        static char[] computerCells = new char[7];
        static Random rnd = new Random();
        static int playerShip;
        static int computerShip;
        static List<int> playerMoves = new List<int>();
        static List<int> computerMoves = new List<int>();

        static void Main(string[] args)
        {
            InitializeGame();

            Console.WriteLine("Welcome to Battleship!");
            Console.WriteLine("Please choose a cell (1-7) to hide your ship:");

            // Place players ship
            bool validPosition = false;
            while (!validPosition)
            {
                int.TryParse(Console.ReadLine(), out playerShip);
                if (playerShip >= 1 && playerShip <= 7)
                {
                    validPosition = true;
                }
                else
                {
                    Console.WriteLine("Please choose a valid cell (1-7):");
                }
            }

            // Place computer's ship
            computerShip = rnd.Next(1, 8);

            Console.Clear();

            // Start the game
            while (true)
            {
                ShowBoard();
                Console.WriteLine("Your turn. Choose a cell (1-7):");
                int playerAttempt;
                while (!int.TryParse(Console.ReadLine(), out playerAttempt) || playerAttempt < 1 || playerAttempt > 7)
                {
                    Console.WriteLine("Please enter a valid number (1-7):");
                }

                playerMoves.Add(playerAttempt);

                if (playerAttempt == computerShip)
                {
                    ShowBoard();
                    Console.WriteLine("Congratulations! You've sunk the computer's ship! You win!");
                    break;
                }
                else
                {
                    computerCells[playerAttempt - 1] = 'X';
                }

                int computerAttempt;
                do
                {
                    computerAttempt = rnd.Next(1, 8);
                } while (computerMoves.Contains(computerAttempt)); // Check if the move has already been made

                computerMoves.Add(computerAttempt);

                if (computerAttempt == playerShip)
                {
                    ShowBoard();
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

        static void InitializeGame()
        {
            for (int i = 0; i < 7; i++)
            {
                playerCells[i] = '-';
                computerCells[i] = '-';
            }
        }

        static void ShowBoard()
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
