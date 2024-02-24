using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGPT.PL.Test
{
    [TestClass]
    internal class utUser : utBase<tblUser>
    {
        [TestMethod]
        public void LoadTest()
        {
            int expected = 3;
            var users = base.LoadTest();
            Assert.AreEqual(expected, users.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            int rowsAffected = InsertTest(new tblUser
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "Test",
                UserName = "Test",
                Password = "Test",
                IsComputer = false
                
            });
            Assert.AreEqual(1, rowsAffected);

        }

        [TestMethod]
        public void UpdateTest()
        {
            tblUser row = base.LoadTest().FirstOrDefault();

            if (row != null)
            {
                row.FirstName = "Updated";
                row.LastName = "Updated";
                int rowsAffected = UpdateTest(row);
                Assert.AreEqual(1, rowsAffected);
            }
        }


        [TestMethod]
        public void DeleteTest()
        {
            tblUser row = dc.tblUsers.FirstOrDefault(x => x.FirstName == "Kaiden");

            if (row != null)
            {
                int rowsAffected = DeleteTest(row);

                Assert.IsTrue(rowsAffected == 1);
            }


        }
    }
}
