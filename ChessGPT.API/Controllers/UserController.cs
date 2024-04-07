using ChessGPT.BL;
using ChessGPT.BL.Models;
using ChessGPT.PL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KB.DVDCentral.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;
        private readonly DbContextOptions<ChessGPTEntities> options;

        public UserController(DbContextOptions<ChessGPTEntities> options)
        {
            this.options = options;
        }

        /// <summary>
        /// Returns a List of Movies
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return new UserManager(options).Load();
        }

        [HttpGet("{id}")]
        public User Get(Guid id)
        {
            return new UserManager(options).LoadById(id);
        }

        [HttpGet("{username}/{password}")]
        public User Get(string username, string password)
        {
            return new UserManager(options).LoadByLogin(username, password);
        }

        [HttpPost("{rollback?}")]
        public int post([FromBody] User user, bool rollback = false)
        {
            try
            {
                return new UserManager(options).Insert(user, rollback);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("{id}/{rollback?}")]
        public int put(Guid id, [FromBody] User user, bool rollback = false)
        {
            try
            {
                return new UserManager(options).Update(user, rollback);
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
                return new UserManager(options).Delete(id, rollback);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}