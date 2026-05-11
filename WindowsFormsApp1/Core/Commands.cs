using System.Collections.Generic;

namespace WindowsFormsApp1.Core
{
    public interface ICommand
    {
        List<Cell> Execute();
        int Row { get; }
        int Col { get; }
    }

    // Команда відкриття клітинки
    public class RevealCommand : ICommand
    {
        private Game _game;
        public int Row { get; }
        public int Col { get; }

        public RevealCommand(Game game, int row, int col)
        {
            _game = game;
            Row = row;
            Col = col;
        }

        public List<Cell> Execute()
        {
            return _game.RevealCell(Row, Col);
        }
    }

    // Команда встановлення прапорця
    public class FlagCommand : ICommand
    {
        private Game _game;
        public int Row { get; }
        public int Col { get; }

        public FlagCommand(Game game, int row, int col)
        {
            _game = game;
            Row = row;
            Col = col;
        }

        public List<Cell> Execute()
        {
            _game.ToggleFlag(Row, Col);
            // Повернення зміненої клітинки для перемалювання
            return new List<Cell> { _game.Board.GetCell(Row, Col) };
        }
    }
}