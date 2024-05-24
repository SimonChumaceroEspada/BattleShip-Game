using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class ComputerPlayer : Player
    {
        private Random rnd = new Random();

        public override void PlaceShip(int cellCount)
        {
            ShipPosition = rnd.Next(1, cellCount + 1);
        }

        // Check if the move has already been made
        public override int MakeMove(int cellCount)
        {
            int move;
            do
            {
                move = rnd.Next(1, cellCount + 1);
            } while (HasAlreadyMoved(move));
            return move;
        }
    }
}
