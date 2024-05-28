using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public abstract class Player
    {
        public int ShipPosition { get; protected set; }
        protected List<int> Moves = new List<int>();

        public abstract void PlaceShip(int cellCount);
        public abstract int MakeMove(int cellCount);

        public bool HasAlreadyMoved(int position) => Moves.Contains(position);

        public void AddMove(int position) => Moves.Add(position);
    }
}
