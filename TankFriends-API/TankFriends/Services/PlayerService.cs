using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TankFriends.Models;

namespace TankFriends.Services
{
    public class PlayerService
    {
        private UserManager<Player> userManager;
        private SignInManager<Player> signInManager;

        public PlayerService(PlayerContext context, UserManager<Player> userManager, SignInManager<Player> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<Player> GetPlayerByUsername(string userName)
        {
            return await userManager.FindByNameAsync(userName);
        }

        public async Task<IdentityResult> RegisterPlayer(Player user, string password)
        {
            return await userManager.CreateAsync(user, password);
        }

        public async Task<SignInResult> SignIn(string userName, string password)
        {
            return await signInManager.PasswordSignInAsync(userName, password, false, false);
        }
    }
}
