namespace BattleShip.Models
{
    public abstract class Player
    {
        public int ShipPosition { get; protected set; }
        protected List<int> Moves = new List<int>();

        public abstract void PlaceShip(int cellCount, int position = -1);
        public abstract int MakeMove(int cellCount);

        public bool HasAlreadyMoved(int position) => Moves.Contains(position);

        public void AddMove(int position) => Moves.Add(position);
    }
}
