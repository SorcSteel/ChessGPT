using ChessGPT.BL;
using ChessGPT.BL.Models;
using ChessGPT.PL.Data;
using ChessGPT.PL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KB.DVDCentral.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGameSPController : ControllerBase
    {
        private readonly ILogger<UserGameController> logger;
        private readonly DbContextOptions<ChessGPTEntities> options;

        public UserGameSPController(DbContextOptions<ChessGPTEntities> options)
        {
            this.options = options;
        }

        /// <summary>
        /// Retrieves all UserGames That are Open.
        /// </summary>

        [HttpGet]
        public IEnumerable<spGetOpenGames> GetOpenGames()
        {
            return new UserGameSPManager(options).LoadOpenGames();
        }

        /// <summary>
        /// Retrieves open games by User Id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>List</returns>

        [HttpGet("{userId}")]
        public IEnumerable<Game> GetOpenGamesByUserId(Guid userId)
        {
            return new GameManager(options).LoadOpenGamesByUserId(userId);
        }
    }
}