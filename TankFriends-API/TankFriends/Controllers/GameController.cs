using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TankFriends.Models;

namespace TankFriends.Controllers
{
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private readonly TankFriendsContext _context;

        public GameController(TankFriendsContext context)
        {
            _context = context;

            if (_context.Games.Count() == 0)
            {
                _context.Games.Add(new Game(new GameBoard(5, 5)));
                _context.SaveChanges();
            }
        }

        [HttpGet(Name = "GetGames")]
        public IEnumerable<Game> GetAllGames()
        {
            return _context.Games.ToList();
        }

        [HttpGet("{id}", Name = "GetGame")]
        public IActionResult GetGameById(string id)
        {
            Guid guid = new Guid(id);
            Game game = _context.Games.FirstOrDefault(t => t.Id == guid);
            if (game == null)
            {
                return NotFound();
            }
            return new ObjectResult(game);
        }

        [Authorize]
        [HttpPost("{gameId}/join", Name = "JoinGame")]
        public IActionResult JoinGame(string gameId)
        {
            ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
            Guid gameGuid = new Guid(gameId);
            Game game = _context.Games.FirstOrDefault(g => g.Id == gameGuid);
            if (game == null) { return NotFound(); }

            string playerId = string.Empty;
            var player = _context.Players.FirstOrDefault(p => p.Id == playerId);
            if (player == null) { return NotFound(); }

            if (game.Players.Contains(player))
            {
                return Ok("player already joined");
            }

            Tank tank = new Tank(3, 3, player);
            game.AddTank(tank);

            return new ObjectResult(game);
        }
    }
}
