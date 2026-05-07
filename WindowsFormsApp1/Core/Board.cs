using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace WindowsFormsApp1.Core
{
    public class Board
    {
        public int Rows { get; }
        public int Columns { get; }
        public int TotalMines { get; }
        public Cell[,] Cells { get; }

        private static readonly Random random = new Random();

        public Board(int rows, int columns, int totalMines)
        {
            Rows = rows;
            Columns = columns;
            TotalMines = totalMines;
            Cells = new Cell[rows, columns];

            InitializeCells();
        }

        private void InitializeCells()
        {
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Columns; c++)
                    Cells[r, c] = new Cell(r, c);
        }

        public void CalculateNeighborMineCounts()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    if (Cells[r, c].IsMine) continue;

                    int count = GetNeighbors(r, c).Count(n => n.IsMine);
                    Cells[r, c].NeighborMineCount = count;
                }
            }
        }

        public int CountFlagged()
        {
            int count = 0;
            foreach (var cell in Cells)
            {
                if (cell.IsFlagged)
                    count++;
            }
            return count;
        }

        public void PlaceMinesAvoiding(int startRow, int startCol)
        {

            foreach (var cell in Cells)
                cell.IsMine = false;

            List<Point> validPositions = new List<Point>();
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Columns; c++)
                {
                    if (Math.Abs(r - startRow) <= 1 && Math.Abs(c - startCol) <= 1)
                        continue;

                    validPositions.Add(new Point(r, c));
                }
            }

            for (int i = 0; i < TotalMines; i++)
            {
                int index = random.Next(i, validPositions.Count);
                (validPositions[i], validPositions[index]) = (validPositions[index], validPositions[i]);

                Point minePos = validPositions[i];
                Cells[minePos.X, minePos.Y].IsMine = true;
            }


            CalculateNeighborMineCounts();
        }

        public List<Cell> GetNeighbors(int x, int y)
        {
            List<Cell> neighbors = new List<Cell>();

            for (int dr = -1; dr <= 1; dr++)
            {
                for (int dc = -1; dc <= 1; dc++)
                {
                    int nr = x + dr;
                    int nc = y + dc;

                    if (nr >= 0 && nr < Rows && nc >= 0 && nc < Columns && !(dr == 0 && dc == 0))
                    {
                        neighbors.Add(Cells[nr, nc]);
                    }
                }
            }

            return neighbors;
        }

        public bool IsInBounds(int row, int col)
        {
            return row >= 0 && row < Rows && col >= 0 && col < Columns;
        }

        public List<Cell> RevealEmptyArea(int startRow, int startCol)
        {
            var revealedCells = new List<Cell>();
            var queue = new Queue<Cell>();
            var visited = new HashSet<Cell>();

            var startCell = Cells[startRow, startCol];
            queue.Enqueue(startCell);
            visited.Add(startCell);

            while (queue.Count > 0)
            {
                var cell = queue.Dequeue();

                if (!cell.IsRevealed && !cell.IsFlagged)
                {
                    cell.IsRevealed = true;
                    revealedCells.Add(cell);

                    if (cell.NeighborMineCount == 0)
                    {
                        foreach (var neighbor in GetNeighbors(cell.X, cell.Y))
                        {
                            if (!visited.Contains(neighbor))
                            {
                                queue.Enqueue(neighbor);
                                visited.Add(neighbor);
                            }
                        }
                    }
                }
            }

            return revealedCells;
        }

        public Cell GetCell(int row, int col)
        {
            return Cells[row, col];
        }
    }
}
