using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class HumanPlayer : Player
    {
        public override void PlaceShip(int cellCount)
        {
            int position;
            Console.WriteLine($"Please choose a cell (1-{cellCount}) to hide your ship:");
            while (!int.TryParse(Console.ReadLine(), out position) || position < 1 || position > cellCount)
            {
                Console.WriteLine($"Please choose a valid cell (1-{cellCount}):");
            }
            ShipPosition = position;
        }

        public override int MakeMove(int cellCount)
        {
            int move;
            Console.WriteLine($"Your turn. Choose a cell (1-{cellCount}):");
            while (!int.TryParse(Console.ReadLine(), out move) || move < 1 || move > cellCount)
            {
                Console.WriteLine($"Please enter a valid number (1-{cellCount}):");
            }
            return move;
        }
    }

}
