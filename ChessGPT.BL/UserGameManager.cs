﻿using ChessGPT.BL.Models;
using ChessGPT.PL.Data;
using ChessGPT.PL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;


namespace ChessGPT.BL
{
    public class UserGameManager : GenericManager<tblUserGame>
    {
        public UserGameManager(DbContextOptions<ChessGPTEntities> options) : base(options) { }

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

        public int Insert(User user, Game game, UserGame userGame, char color, bool rollback = false)
        {
            try
            {
                tblUserGame row = new tblUserGame { UserId = user.Id, GameId = game.Id, Color = color };
                userGame.Id = row.Id;
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
        
        public int Update(UserGame userGame, bool rollback = false)
        {
            try
            {
                int results = base.Update(new tblUserGame
                {
                    Id = userGame.Id,
                    UserId = userGame.UserId,
                    GameId = userGame.GameId,
                    Color = userGame.Color,
                }, rollback);
                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
