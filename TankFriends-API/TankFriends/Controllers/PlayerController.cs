using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TankFriends.Models;
using TankFriends.Services;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace TankFriends.Controllers
{
    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        private PlayerService playerService;

        public PlayerController(PlayerService playerService)
        {
            this.playerService = playerService;
        }

        [HttpPost("create", Name = "CreatePlayer")]
        public async Task<IActionResult> CreatePlayer([FromBody] Login loginModel)
        {
            if (String.IsNullOrEmpty(loginModel.UserName) || String.IsNullOrEmpty(loginModel.Password))
            {
                return BadRequest();
            }
            
            try
            {
                Player newPlayer = new Player(loginModel.UserName);
                IdentityResult createdUser = await playerService.RegisterPlayer(newPlayer, loginModel.Password);

                if (createdUser != null && createdUser.Succeeded)
                {
                    return Ok(new { message = "registered player " + newPlayer.UserName });
                }
                else
                {
                    return StatusCode(409, new { message = createdUser.Errors.First().Description });
                }
            }
            catch (Exception ex)
            {
                // TODO: log the exception
                return StatusCode(500, new { message = "no clue, sorry" });
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] Login loginModel)
        {
            SignInResult result = await playerService.SignIn(loginModel.UserName, loginModel.Password);

            if (result.Succeeded)
                return Ok();

            return BadRequest("invalid login");
        }
    }
}