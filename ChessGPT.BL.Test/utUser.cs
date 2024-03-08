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
    public class utUser : utBase
    {
        [TestMethod]
        public void LoadTest()
        {
            var users = new UserManager(options).Load();
            int expected = 3;

            Assert.AreEqual(expected, users.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            User user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "Test",
                UserName = "Test",
                Password = "Test",
                IsComputer = false
            };

            int result = new UserManager(options).Insert(user, true);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            User user = new UserManager(options).Load().FirstOrDefault();

            if (user != null) 
            {
                user.FirstName = "First Name update";
                user.LastName = "Last Name update"; 
                Assert.IsTrue(new UserManager(options).Update(user, true) > 0);
            }

        }

        [TestMethod]
        public void DeleteTest()
        {
            User user = new UserManager(options).Load().FirstOrDefault(x => x.UserName == "500201348");

            Assert.IsTrue(new UserManager(options).Delete(user.Id, true) > 0);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            User user = new UserManager(options).Load().FirstOrDefault();
            Assert.AreEqual(new UserManager(options).LoadById(user.Id).Id, user.Id);
        }
    }
}
