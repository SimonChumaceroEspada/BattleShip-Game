using System;

namespace BattleShip.Models
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

        public char[] GetCells()
        {
            return cells;
        }
    }
}
