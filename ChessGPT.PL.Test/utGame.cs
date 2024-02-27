using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGPT.PL.Test
{
    [TestClass]
    public class utGame : utBase<tblGame>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 3;
            var games = base.LoadTest();
            Assert.AreEqual(expected, games.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            int rowsAffected = InsertTest(new tblGame
            {
                Id = Guid.NewGuid(),
                GameName =  "Test Game",
                GameTime = DateTime.Now,
                GameBoard = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w",
                GameState = 'o'
            });
            Assert.AreEqual(1, rowsAffected);

        }

        [TestMethod]
        public void UpdateTest()
        {
            tblGame row = base.LoadTest().FirstOrDefault();

            if (row != null)
            {
                row.GameName = "Update  Test";
                row.GameTime = DateTime.Now;
                int rowsAffected = UpdateTest(row);
                Assert.AreEqual(1, rowsAffected);
            }
        }


        [TestMethod]
        public void DeleteTest()
        {
            tblGame row = dc.tblGames.FirstOrDefault(x => x.GameName == "First Game");

            if (row != null)
            {
                int rowsAffected = DeleteTest(row);

                Assert.IsTrue(rowsAffected == 1);
            }


        }
    }
}
