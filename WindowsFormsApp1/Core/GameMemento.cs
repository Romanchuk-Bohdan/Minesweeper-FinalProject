using System.Collections.Generic;

namespace WindowsFormsApp1.Core
{
    // Клас для збереження стану однієї клітинки
    public class CellMemento
    {
        public bool IsRevealed { get; set; }
        public bool IsMine { get; set; }
        public bool IsFlagged { get; set; }
        public int NeighborMineCount { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }

    // Клас для збереження всього стану гри
    public class GameMemento
    {
        public string PlayerName { get; set; }
        public Difficulty GameDifficulty { get; set; }
        public int ElapsedSeconds { get; set; }
        public bool IsFirstClick { get; set; }
        public GameState CurrentState { get; set; }
        public List<CellMemento> Cells { get; set; }

        public GameMemento()
        {
            Cells = new List<CellMemento>();
        }
    }
}