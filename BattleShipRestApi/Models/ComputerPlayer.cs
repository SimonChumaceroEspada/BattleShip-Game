namespace BattleShip.Models
{
    public class ComputerPlayer : Player
    {
        private Random rnd = new Random();

        public override void PlaceShip(int cellCount, int position = -1)
        {
            ShipPosition = rnd.Next(1, cellCount + 1);
        }

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
