using BattleShip;
using BattleShip.Models;

namespace BattleShip.Services
{
    public class GameManager
    {
        private Player player;
        private Player computer;
        private Board playerBoard;
        private Board computerBoard;
        private int cellCount;
        private int? lastPlayerMove;
        private int? lastComputerMove;

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
        }

        public string MakeMove(int playerMove)
        {
            player.AddMove(playerMove);
            lastPlayerMove = playerMove;
            if (playerMove == computer.ShipPosition)
            {
                computerBoard.MarkCell(playerMove, 'X');
                return "Congratulations! You've sunk the computer's ship! You win!";
            }
            computerBoard.MarkCell(playerMove, 'X');

            int computerMove = computer.MakeMove(cellCount);
            computer.AddMove(computerMove);
            lastComputerMove = computerMove;
            if (computerMove == player.ShipPosition)
            {
                playerBoard.MarkCell(computerMove, 'X');
                return "The computer has sunk your ship! You lose!";
            }
            playerBoard.MarkCell(computerMove, 'X');

            return $"Player moved to {playerMove}. Computer moved to {computerMove}.";
        }

        public (Board playerBoard, Board computerBoard, int? lastPlayerMove, int? lastComputerMove) GetGameStatus()
        {
            return (playerBoard, computerBoard, lastPlayerMove, lastComputerMove);
        }
    }
}
