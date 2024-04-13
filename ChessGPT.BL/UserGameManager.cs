using ChessGPT.BL.Models;
using ChessGPT.PL.Data;
using ChessGPT.PL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;


namespace ChessGPT.BL
{
    public class UserGameManager : GenericManager<tblUserGame>
    {
        public UserGameManager(DbContextOptions<ChessGPTEntities> options) : base(options) { }
        public UserGameManager(ILogger logger, DbContextOptions<ChessGPTEntities> options) : base(logger, options) { }

        public List<UserGame> Load()
        {

            try
            {
                List<UserGame> rows = new List<UserGame>();
                base.Load()
                    .ForEach(d => rows.Add(
                        new UserGame
                        {
                            Id = d.Id,
                            UserId = d.Id,
                            GameId = d.GameId,
                            Color = d.Color,
                        }));

                return rows;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public UserGame LoadById(Guid id)
        {
            try
            {
                tblUserGame row = base.LoadById(id);

                if (row != null)
                {
                    UserGame userGame = new UserGame
                    {
                        Id = row.Id,
                        UserId = row.UserId,
                        GameId = row.GameId,
                        Color = row.Color,
                    };

                    return userGame;
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Insert(Guid userId, Guid gameId, char color, bool rollback = false)
        {
            try
            {
                tblUserGame row = new tblUserGame { Id = Guid.NewGuid(), UserId = userId, GameId = gameId, Color = color };
                return base.Insert(row, rollback);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                return base.Delete(id, rollback);
            }
            catch (Exception)
            {

                throw;
            }
        }
        // Theres no need to update UserGame, It's either you're White or Black
        // Unless we're updating the players that are playing the game which makes little sense
    }
}
