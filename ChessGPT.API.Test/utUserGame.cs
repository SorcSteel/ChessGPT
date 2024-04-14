

using ChessGPT.BL;
using ChessGPT.BL.Models;

namespace ChessGPT.API.Test
{
    [TestClass]
    public class utUserGame : utBase
    {
        [TestMethod]
        public async Task LoadTestAsync()
        {
            await base.LoadTestAsync<UserGame>(6);
        }

        [TestMethod]
        public async Task InsertTestAsync()
        {
            UserGame userGame = new UserGame { UserId = Guid.NewGuid(), GameId = Guid.NewGuid(), Color = 'B' };
            await base.InsertTestAsync<UserGame>(userGame);

        }

        [TestMethod]
        public async Task DeleteTestAsync()
        {
            await base.DeleteTestAsync1<UserGame>(new KeyValuePair<string, string>("GameId", "96349c24-a518-4487-a6ff-a2429ecf2576"));
        }

        [TestMethod]
        public async Task LoadByIdTestAsync()
        {
            await base.LoadByIdTestAsync<UserGame>(new KeyValuePair<string, string>("GameId", "96349c24-a518-4487-a6ff-a2429ecf2576"));
        }


    }
}
