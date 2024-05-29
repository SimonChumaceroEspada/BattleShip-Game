namespace BattleShip.Models
{
    public class HumanPlayer : Player
    {
        public override void PlaceShip(int cellCount, int position = -1)
        {
            if (position == -1)
            {
                int chosenPosition;
                Console.WriteLine($"Please choose a cell (1-{cellCount}) to hide your ship:");
                while (!int.TryParse(Console.ReadLine(), out chosenPosition) || chosenPosition < 1 || chosenPosition > cellCount)
                {
                    Console.WriteLine($"Please choose a valid cell (1-{cellCount}):");
                }
                ShipPosition = chosenPosition;
            }
            else
            {
                ShipPosition = position;
            }
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
