using BattleShip;
using System;
using System.Collections.Generic;

namespace Battleship
{
    class BattleShipGame
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Battleship!");
            Console.WriteLine("Enter the number of cells for the game:");
            int cellCount;
            while (!int.TryParse(Console.ReadLine(), out cellCount) || cellCount < 2 || cellCount > 100)
            {
                Console.WriteLine("Please enter a valid number (greater than 1 and less or equal to 100):");
            }

            Player humanPlayer = new HumanPlayer();
            Player computerPlayer = new ComputerPlayer();
            GameManager gameManager = new GameManager(cellCount, humanPlayer, computerPlayer);
            gameManager.StartGame();
        }
    }
}
// Test for the pull request