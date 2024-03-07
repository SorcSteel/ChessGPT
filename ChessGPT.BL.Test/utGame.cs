using Castle.Core.Resource;
using ChessGPT.BL.Models;
using ChessGPT.PL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGPT.BL.Test
{
    [TestClass]
    public class utGame : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Game> games = new GameManager(options).Load();
            int expected = 3;

            Assert.AreEqual(expected, games.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            Game game = new Game
            {
                Id = Guid.NewGuid(),
                GameName = "Insert Test Game",
                GameTime = DateTime.Now,
                GameBoard = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w",
                GameState = 'o'
            };

            int result = new GameManager(options).Insert(game, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Game game = new GameManager(options).Load().FirstOrDefault();

            if (game != null) 
            {
                game.GameName = "BL Game Update Test";
                game.GameTime = DateTime.Now; 
                Assert.IsTrue(new GameManager(options).Update(game, true) > 0);
            }

        }

        [TestMethod]
        public void DeleteTest()
        {
            Game game = new GameManager(options).Load().FirstOrDefault();

            Assert.IsTrue(new GameManager(options).Delete(game.Id, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Game game = new GameManager(options).Load().FirstOrDefault();
            Assert.AreEqual(new GameManager(options).LoadById(game.Id).Id, game.Id);
        }
    }
}
