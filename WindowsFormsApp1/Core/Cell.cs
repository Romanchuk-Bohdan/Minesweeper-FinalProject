using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1.Core
{
    public class Cell
    {
        public bool IsRevealed { get; set; }
        public bool IsMine { get; set; }
        public bool IsFlagged { get; set; }
        public int NeighborMineCount { get; set; }
        public int X { get; set; }
        public int Y { get; set; }


        public Point Position { get; set; }

        public Cell(int x, int y)
        {
            Position = new Point(x, y);
            X = x; Y = y;
            IsRevealed = false;
            IsMine = false;
            IsFlagged = false;
            NeighborMineCount = 0;
        }
    }
}
