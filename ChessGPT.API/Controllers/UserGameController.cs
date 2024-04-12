﻿using ChessGPT.BL;
using ChessGPT.BL.Models;
using ChessGPT.PL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KB.DVDCentral.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGameController : ControllerBase
    {
        private readonly ILogger<UserGameController> logger;
        private readonly DbContextOptions<ChessGPTEntities> options;

        public UserGameController(DbContextOptions<ChessGPTEntities> options)
        {
            this.options = options;
        }

        /// <summary>
        /// Retrieves all UserGames.
        /// </summary>

        [HttpGet]
        public IEnumerable<UserGame> Get()
        {
            return new UserGameManager(options).Load();
        }

        /// <summary>
        /// Retrieves a UserGame By Id.
        /// </summary>
        [HttpGet("{id}")]
        public UserGame Get(Guid id)
        {
            return new UserGameManager(options).LoadById(id);
        }

        //[HttpPost("{rollback?}")]
        //public int post([FromBody] UserGame userGame, bool rollback = false)
        //{
        //    try
        //    {
        //        return new UserGameManager(options).Insert(userGame, rollback);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


        /// <summary>
        /// Deletes a UserGame By Id.
        /// </summary>
        [HttpDelete("{id}/{rollback?}")]
        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                return new UserGameManager(options).Delete(id, rollback);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}