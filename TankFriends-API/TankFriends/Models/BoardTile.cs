using System;

namespace TankFriends.Models
{
    public class BoardTile
    {
        public Guid Id { get; set; }

        public Tank OccupiedByTank { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public BoardTile() { }

        public BoardTile(int rowNum, int colNum)
        {
            Id = Guid.NewGuid();
            Row = rowNum;
            Column = colNum;
        }
    }
}
