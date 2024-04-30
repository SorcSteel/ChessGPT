using ChessGPT.BL;
using ChessGPT.BL.Models;
using ChessGPT.PL.Data;
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
        public IEnumerable<UserGame> GetOpenGames()
        {
            return (IEnumerable<UserGame>)new UserGameSPManager(options).Load();
        }
    }
}