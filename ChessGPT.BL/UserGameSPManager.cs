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
    public class UserGameSPManager (DbContextOptions<ChessGPTEntities> options)
    {

        public List<spGetOpenGames> LoadOpenGames()
        {
            try
            {

                List<spGetOpenGames> rows = new List<spGetOpenGames>();
                using (ChessGPTEntities dc = new ChessGPTEntities(options))
                {
                    var results = dc.Set<spGetOpenGames>().FromSqlRaw("exec spGetOpenGames").ToList();
                    foreach (var row in results)
                    {
                        rows.Add(new spGetOpenGames
                        {
                            GameId = row.GameId
                        });
                    }
                }
                return rows;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public List<spGetOpenGames> LoadOpenGames()
        //{
        //    try
        //    {
        //        List<spGetOpenGames> rows = new List<spGetOpenGames>();
        //        //using (ChessGPTEntities dc = new ChessGPTEntities(options))
        //        //{
        //        //    var results = dc.Set<spGetOpenGames>().FromSqlRaw("exec spGetOpenGames").ToList();
        //        //    foreach (var row in results)
        //        //    {
        //        //        rows.Add(new spGetMoviesResult
        //        //        {
        //        //            Id = row.Id,
        //        //            RatingId = row.RatingId,
        //        //            Cost = row.Cost,
        //        //            Description = row.Description,
        //        //            DirectorId = row.DirectorId,
        //        //            FormatId = row.FormatId,
        //        //            Quantity = row.Quantity,
        //        //            Title = row.Title,
        //        //            FirstName = row.FirstName,
        //        //            LastName = row.LastName,
        //        //        });
        //        //    }


        //        //}

        //        base.Load("spGetOpenGames")
        //            .ForEach(row => rows.Add(
        //                new spGetOpenGames
        //                {
        //                    GameId = row.GameId
        //                }));
        //        return rows;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}

