using ChessGPT.BL;
using ChessGPT.BL.Models;
using ChessGPT.PL.Data;
using ChessGPT.PL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KB.DVDCentral.API.Controllers
{
    [Route("api/[controller]/Hi")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> logger;
        private readonly DbContextOptions<ChessGPTEntities> options;

        public GameController(DbContextOptions<ChessGPTEntities> options)
        {
            this.options = options;
        }


        /// <summary>
        /// Retrieves all Games.
        /// </summary>
        [HttpGet]
        public IEnumerable<Game> Get()
        {
            return new GameManager(options).Load();
        }


        /// <summary>
        /// Retrieves a Game By Id.
        /// </summary>
        [HttpGet("{id}")]
        public Game Get(Guid id)
        {
            return new GameManager(options).LoadById(id);
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

        /// <summary>
        /// Creates a Game.
        /// </summary>
        [HttpPost("{rollback?}")]
        public int post([FromBody] Game game, bool rollback = false)
        {
            try
            {
                return new GameManager(options).Insert(game, rollback);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Updates a Game By Id.
        /// </summary>
        [HttpPut("{id}/{rollback?}")]
        public int put(Guid id, [FromBody] Game game, bool rollback = false)
        {
            try
            {
                return new GameManager(options).Update(game, rollback);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Deletes a Game By Id.
        /// </summary>
        [HttpDelete("{id}/{rollback?}")]
        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                return new GameManager(options).Delete(id, rollback);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}