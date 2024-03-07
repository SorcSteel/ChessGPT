using ChessGPT.BL.Models;
using ChessGPT.PL.Data;
using ChessGPT.PL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ChessGPT.BL
{
    public class GameManager : GenericManager<tblGame>
    {
        public GameManager(DbContextOptions<ChessGPTEntities> options) : base(options) { }



        public List<Game> Load()
        {

            try
            {
                List<Game> rows = new List<Game>();
                base.Load()
                    .ForEach(d => rows.Add(
                        new Game
                        {
                            Id = d.Id,
                            GameName = d.GameName,
                            GameTime = d.GameTime,
                            GameBoard = d.GameBoard,
                            GameState = d.GameState
                        }));

                return rows;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public Game LoadById(Guid id)
        {
            try
            {
                tblGame row = base.LoadById(id);

                if (row != null)
                {
                    Game game = new Game
                    {
                        Id = row.Id,
                        GameName = row.GameName,
                        GameTime = row.GameTime,
                        GameBoard = row.GameBoard,
                        GameState = row.GameState
                    };

                    return game;
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

        public int Insert(Game game, bool rollback = false)
        {
            try
            {
                tblGame row = new tblGame { GameName = game.GameName, GameTime = game.GameTime, GameBoard = game.GameBoard, GameState = game.GameState };
                game.Id = row.Id;
                return base.Insert(row, rollback);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Update(Game game, bool rollback = false)
        {
            try
            {
                int results = base.Update(new tblGame
                {
                    Id = game.Id,
                    GameName = game.GameName,
                    GameTime = game.GameTime,
                    GameBoard = game.GameBoard,
                    GameState = game.GameState
                }, rollback);
                return results;
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
    }
}
