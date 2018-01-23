using System;
using System.Collections.Generic;
using System.Linq;

namespace TankFriends.Models
{
    public class GameBoard
    {
        public Guid Id { get; set; }
        public List<BoardTile> Tiles { get; set; }

        private BoardTile[,] tileGrid;

        public GameBoard()
        {
        }

        public GameBoard(int rows, int columns)
        {
            Id = Guid.NewGuid();
            tileGrid = new BoardTile[rows, columns];
            foreach (int rowNum in Enumerable.Range(0, rows))
            {
                foreach (int colNum in Enumerable.Range(0, columns))
                {
                    BoardTile tile = new BoardTile(rowNum, colNum);
                    tileGrid[rowNum, colNum] = tile;
                }
            }
        }

        public BoardTile GetTileAt(int row, int col)
        {
            return tileGrid[row, col];
        }

        public BoardTile[,] GetTilesBetween(int topLeftRow, int topLeftCol, int bottomRightRow, int bottomRightCol)
        {
            return null;
        }

        public BoardTile GetRandomEmptyTile()
        {
            var emptyTiles = Tiles.Where(t => t.OccupiedByTank == null).ToArray();
            if(emptyTiles.Length == 0) { return null; }

            Random rng = new Random();
            return emptyTiles[rng.Next(emptyTiles.Length)];
        }
    }
}
