using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace WindowsFormsApp1.Core
{
    public class GameRenderer
    {
        private Panel panel;
        private Game game;
        private int cellSize;
        private int maxHighlights;
        private int highlightCount = 0;
        private Dictionary<string, Image> cellImages;
        private List<Cell> highlightedCells = new List<Cell>();

        public GameRenderer(Panel panel, Game game, int cellSize, Dictionary<string, Image> cellImages)
        {
            this.panel = panel;
            this.game = game;
            this.cellSize = cellSize;
            this.cellImages = cellImages;

            maxHighlights = game.Difficulty switch
            {
                Difficulty.Easy => 3,
                Difficulty.Medium => 5,
                Difficulty.Hard => 7,
                _ => 0
            };
        }

        public void DrawBoard(MouseEventHandler cellClickHandler)
        {
            panel.Controls.Clear();
            int rows = game.Board.Rows;
            int cols = game.Board.Columns;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Cell cell = game.Board.GetCell(row, col);
                    PictureBox pic = new PictureBox
                    {
                        Width = cellSize,
                        Height = cellSize,
                        Left = col * cellSize,
                        Top = row * cellSize,
                        Tag = new Point(row, col),
                        Margin = new Padding(0),
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };

                    pic.Paint += PictureBox_Paint;
                    UpdateCellAppearance(pic, cell);
                    pic.MouseUp += cellClickHandler;

                    panel.Controls.Add(pic);
                }
            }
        }

        public void RedrawBoard()
        {
            foreach (Control control in panel.Controls)
            {
                if (control is PictureBox pic)
                {
                    Point p = (Point)pic.Tag;
                    Cell cell = game.Board.GetCell(p.X, p.Y);
                    UpdateCellAppearance(pic, cell);
                    pic.Invalidate();
                }
            }
        }

        public void RedrawCells(List<Cell> cells)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is PictureBox pic && pic.Tag is Point p)
                {
                    Cell cell = cells.FirstOrDefault(c => c.X == p.X && c.Y == p.Y);
                    if (cell != null)
                    {
                        UpdateCellAppearance(pic, cell);
                        pic.Invalidate();
                    }
                }
            }
        }

        private void UpdateCellAppearance(PictureBox pictureBox, Cell cell)
        {
            if (cell.IsRevealed)
            {
                if (cell.IsMine)
                {
                    pictureBox.Image = cellImages["mine"];
                }
                else if (cell.NeighborMineCount > 0)
                {
                    pictureBox.Image = cellImages[$"field_{cell.NeighborMineCount}"];
                }
                else
                {
                    pictureBox.Image = cellImages["ground"];
                }
            }
            else if (cell.IsFlagged)
            {
                pictureBox.Image = cellImages["flag"];
            }
            else
            {
                pictureBox.Image = cellImages["field_0"];
            }
        }

        public void HighlightCell(Cell cell)
        {
            if (highlightCount >= maxHighlights)
            {
                MessageBox.Show($"Ви використали всі {maxHighlights} підсвічування для цього рівня складності.", "Увага", MessageBoxButtons.OK);
                return;
            }

            if (!highlightedCells.Contains(cell))
            {
                highlightedCells.Add(cell);
                highlightCount++;

                foreach (Control ctrl in panel.Controls)
                {
                    if (ctrl is PictureBox pic && pic.Tag is Point p)
                    {
                        if (p.X == cell.X && p.Y == cell.Y)
                        {
                            pic.Invalidate();
                            break;
                        }
                    }
                }
            }
        }

        public string GetRemainingHighlights()
        {
            return $"{maxHighlights - highlightCount}/{maxHighlights}";
        }

        public bool IsHighlightsLimitReached()
        {
            return highlightCount >= maxHighlights;
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (sender is PictureBox pic && pic.Tag is Point p)
            {
                Cell cell = game.Board.GetCell(p.X, p.Y);
                if (highlightedCells.Contains(cell))
                {
                    using (Pen pen = new Pen(Color.LimeGreen, 2))
                    {
                        e.Graphics.DrawRectangle(pen, 0, 0, pic.Width - 1, pic.Height - 1);
                    }
                }
            }
        }
    }
}
