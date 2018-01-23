using System;

namespace TankFriends.Models
{
    public class Tank
    {
        public Guid Id { get; set; }
        public Player OwnedByPlayer { get; set; }
        public int Health { get; set; }
        public int ActionPoints { get; set; }

        public Tank()
        {

        }

        public Tank(int startingHealth, int startingActionPoints, Player owningPlayer)
        {
            Id = Guid.NewGuid();
            OwnedByPlayer = owningPlayer;
            Health = startingHealth;
            ActionPoints = startingActionPoints;
        }
    }
}
