using Microsoft.EntityFrameworkCore;

namespace TankFriends.Models
{
    public class TankFriendsContext: DbContext
    {
        public TankFriendsContext(DbContextOptions<TankFriendsContext> options): base(options)
        {
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }
    }
}
