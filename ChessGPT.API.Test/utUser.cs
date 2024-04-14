

using ChessGPT.BL.Models;

namespace ChessGPT.API.Test
{
    [TestClass]
    public class utUser : utBase
    {
        [TestMethod]
        public async Task LoadTestAsync()
        {
            await base.LoadTestAsync<User>(3);
        }

        [TestMethod]
        public async Task InsertTestAsync()
        {
            User user = new User { Id = Guid.NewGuid(), UserName = "test", Password = "test", FirstName = "fnametest", LastName = "lnametest", IsComputer = false };
            await base.InsertTestAsync<User>(user);

        }

        [TestMethod]
        public async Task DeleteTestAsync()
        {
            await base.DeleteTestAsync1<User>(new KeyValuePair<string, string>("UserName", "test"));
        }

        [TestMethod]
        public async Task LoadByIdTestAsync()
        {
            await base.LoadByIdTestAsync<User>(new KeyValuePair<string, string>("UserName", "test"));
        }

        [TestMethod]
        public async Task UpdateTestAsync()
        {
            User user = new User { UserName = "updateTest", Password = "test" };
            await base.UpdateTestAsync<User>(new KeyValuePair<string, string>("UserName", "test"), user);

        }

    }
}
