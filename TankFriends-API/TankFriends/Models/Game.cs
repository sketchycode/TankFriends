using System;
using System.Collections.Generic;
using System.Linq;

namespace TankFriends.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public IList<Tank> Tanks { get { return tanks.AsReadOnly(); } }
        public IList<Player> Players { get { return Tanks.Select(t => t.OwnedByPlayer).ToList(); } }
        public GameBoard Board { get; set; }

        public GameState CurrentState { get; set; }

        private List<Tank> tanks = new List<Tank>();

        public Game() { }

        public Game(GameBoard Board)
        {
            Id = Guid.NewGuid();
            this.Board = Board;
        }

        public void AddTank(Tank tank)
        {
            BoardTile tile = Board.GetRandomEmptyTile();
            tile.OccupiedByTank = tank;
            tanks.Add(tank);
        }
    }
}
