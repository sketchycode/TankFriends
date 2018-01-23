using Microsoft.AspNetCore.Identity;

namespace TankFriends.Models
{
    public class Player: IdentityUser
    {
        public Player() { }

        public Player(string userName) : base(userName) { }
    }
}
