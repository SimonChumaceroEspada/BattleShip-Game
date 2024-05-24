using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Board
    {
        private char[] cells;

        // Initialize the Board with empty cells in vectors
        public Board(int cellCount)
        {
            cells = new char[cellCount];
            for (int i = 0; i < cellCount; i++)
            {
                cells[i] = '-';
            }
        }

        public void MarkCell(int position, char mark)
        {
            cells[position - 1] = mark;
        }

        public void Show()
        {
            foreach (var cell in cells)
            {
                Console.Write($"[{cell}]");
            }
            Console.WriteLine();
        }
    }
}
