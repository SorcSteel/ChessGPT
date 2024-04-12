using ChessGPT.BL;
using ChessGPT.BL.Models;
using ChessGPT.PL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KB.DVDCentral.API.Controllers
{
    [Route("api/[controller]")]
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
        /// Returns a List of Movies
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IEnumerable<Game> Get()
        {
            return new GameManager(logger, options).Load();
        }

        [HttpGet("{id}")]
        public Game Get(Guid id)
        {
            return new GameManager(logger, options).LoadById(id);
        }

        [HttpPost("{rollback?}")]
        public int post([FromBody] Game game, bool rollback = false)
        {
            try
            {
                return new GameManager(logger, options).Insert(game, rollback);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("{id}/{rollback?}")]
        public int put(Guid id, [FromBody] Game game, bool rollback = false)
        {
            try
            {
                return new GameManager(logger, options).Update(game, rollback);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}/{rollback?}")]
        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                return new GameManager(logger, options).Delete(id, rollback);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}