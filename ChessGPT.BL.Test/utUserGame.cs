using Castle.Core.Resource;
using ChessGPT.BL.Models;
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
    public class utUserGame : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            var userGames = new UserGameManager(options).Load();
            int expected = 6;

            Assert.AreEqual(expected, userGames.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            Guid userId = new UserManager(options).Load().FirstOrDefault().Id;
            Guid gameId = new GameManager(options).Load().FirstOrDefault().Id;

            int result = new UserGameManager(options).Insert(userId, gameId, 'b', true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void DeleteTest()
        {
            UserGame userGame = new UserGameManager(options).Load().FirstOrDefault();

            Assert.IsTrue(new UserGameManager(options).Delete(userGame.Id, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            UserGame userGame = new UserGameManager(options).Load().FirstOrDefault();
            Assert.AreEqual(new UserGameManager(options).LoadById(userGame.Id).Id, userGame.Id);
        }
    }
}
