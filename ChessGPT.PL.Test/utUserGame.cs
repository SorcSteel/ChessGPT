using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGPT.PL.Test
{
    [TestClass]
    internal class utUserGame : utBase<tblUserGame>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 6;
            var userGames = base.LoadTest();
            Assert.AreEqual(expected, userGames.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            int rowsAffected = InsertTest(new tblUserGame
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                GameId = Guid.NewGuid(),
                Color = 'w'
            });
            Assert.AreEqual(1, rowsAffected);

        }

        [TestMethod]
        public void UpdateTest()
        {
            tblUserGame row = base.LoadTest().FirstOrDefault();

            if (row != null)
            {
                row.Color = 't';
                int rowsAffected = UpdateTest(row);
                Assert.AreEqual(1, rowsAffected);
            }
        }


        [TestMethod]
        public void DeleteTest()
        {
            tblUserGame row = dc.tblUserGames.FirstOrDefault(x => x.Color == 'w');

            if (row != null)
            {
                int rowsAffected = DeleteTest(row);

                Assert.IsTrue(rowsAffected == 1);
            }


        }
    }
}
