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

        public List<spGetOpenGames> LoadOpenGames()
        {
            try
            {
                List<spGetOpenGames> rows = new List<spGetOpenGames>();
                //using (ChessGPTEntities dc = new ChessGPTEntities(options))
                //{
                //    var results = dc.Set<spGetOpenGames>().FromSqlRaw("exec spGetOpenGames").ToList();
                //    foreach (var row in results)
                //    {
                //        rows.Add(new spGetMoviesResult
                //        {
                //            Id = row.Id,
                //            RatingId = row.RatingId,
                //            Cost = row.Cost,
                //            Description = row.Description,
                //            DirectorId = row.DirectorId,
                //            FormatId = row.FormatId,
                //            Quantity = row.Quantity,
                //            Title = row.Title,
                //            FirstName = row.FirstName,
                //            LastName = row.LastName,
                //        });
                //    }


                //}

                base.Load("spGetOpenGames")
                    .ForEach(row => rows.Add(
                        new spGetOpenGames
                        {
                            Id = row.Id,
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

