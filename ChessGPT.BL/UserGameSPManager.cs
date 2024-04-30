using ChessGPT.BL.Models;
using ChessGPT.PL.Data;
using ChessGPT.PL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace ChessGPT.BL
{
    public class UserGameSPManager : GenericManager<spGetOpenGames>
    {
        public UserGameSPManager(DbContextOptions<ChessGPTEntities> options) : base(options) { }
        public UserGameSPManager(ILogger logger, DbContextOptions<ChessGPTEntities> options) : base(logger, options) { }

        public List<UserGame> Load()
        {
            try
            {
                List<UserGame> rows = new List<UserGame>();
                

                base.Load("spGetOpenGames")
                    .ForEach(row => rows.Add(
                        new UserGame
                        {
                            Id = Guid.Empty,
                            GameId = row.GameId
                        }));
                return rows;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

