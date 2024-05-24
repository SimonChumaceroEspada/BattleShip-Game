using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class GameManager
    {
        private Player player;
        private Player computer;
        private Board playerBoard;
        private Board computerBoard;
        private int cellCount;

        public GameManager(int cellCount, Player player, Player computer)
        {
            this.cellCount = cellCount;
            this.player = player;
            this.computer = computer;
            playerBoard = new Board(cellCount);
            computerBoard = new Board(cellCount);
        }

        public void StartGame()
        {
            player.PlaceShip(cellCount);
            computer.PlaceShip(cellCount);

            while (true)
            {
                Console.Clear();
                ShowBoards();

                int playerMove = player.MakeMove(cellCount);
                player.AddMove(playerMove);
                if (playerMove == computer.ShipPosition)
                {
                    ShowBoards(playerMove, -1);
                    Console.WriteLine("Congratulations! You've sunk the computer's ship! You win!");
                    break;
                }
                computerBoard.MarkCell(playerMove, 'X');

                int computerMove = computer.MakeMove(cellCount);
                computer.AddMove(computerMove);
                if (computerMove == player.ShipPosition)
                {
                    ShowBoards(playerMove, computerMove);
                    Console.WriteLine("The computer has sunk your ship! You lose!");
                    break;
                }
                playerBoard.MarkCell(computerMove, 'X');

                ShowBoards(playerMove, computerMove);
            }
        }

        private void ShowBoards(int playerMove = -1, int computerMove = -1)
        {
            Console.WriteLine("Computer's Board:");
            computerBoard.Show();
            Console.WriteLine("Player's Board:");
            playerBoard.Show();

            if (playerMove != -1)
            {
                Console.WriteLine($"Player's last move: {playerMove}");
            }
            if (computerMove != -1)
            {
                Console.WriteLine($"Computer's last move: {computerMove}");
            }
        }
    }

}
