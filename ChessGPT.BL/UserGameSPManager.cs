using ChessGPT.BL.Models;
using ChessGPT.PL.Data;
using ChessGPT.PL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Data;

namespace ChessGPT.BL
{
    public class UserGameSPManager : GenericManager<spGetOpenGames>
    {
        public UserGameSPManager(DbContextOptions<ChessGPTEntities> options) : base(options) { }
        public UserGameSPManager(ILogger logger, DbContextOptions<ChessGPTEntities> options) : base(logger, options) { }

        //public List<spGetOpenGames> LoadOpenGames()
        //{
        //    try
        //    {

        //        List<spGetOpenGames> rows = new List<spGetOpenGames>();
        //        using (ChessGPTEntities dc = new ChessGPTEntities(options))
        //        {
        //            var results = dc.Set<spGetOpenGames>().FromSqlRaw("exec spGetOpenGames").ToList();
        //            foreach (var row in results)
        //            {
        //                rows.Add(new spGetOpenGames
        //                {
        //                    GameId = row.GameId
        //                });
        //            }
        //        }
        //        return rows;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        public List<spGetOpenGames> LoadOpenGames()
        {
            try
            {
                List<spGetOpenGames> rows = new List<spGetOpenGames>();
                base.Load("spGetOpenGames")
                    .ForEach(row => rows.Add(
                        new spGetOpenGames
                        {
                            Id = row.Id,
                            GameName = row.GameName,
                            GameTime = row.GameTime,
                            GameBoard = row.GameBoard, 
                            GameState = row.GameState,
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


