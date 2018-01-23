using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TankFriends.Models
{
    public class PlayerContext: IdentityDbContext<Player>
    {
        public PlayerContext(DbContextOptions<PlayerContext> options): base(options) { }
    }
}
