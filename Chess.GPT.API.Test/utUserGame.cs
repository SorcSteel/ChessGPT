

using ChessGPT.BL.Models;

namespace Chess.GPT.API.Test
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
        public async Task InsertTestAsyncFail()
        {
            UserGame userGame = new UserGame { UserId = Guid.Parse("4882ba82-2809-4f40-848d-5230a1d398de"), GameId = Guid.NewGuid(), Color = 'B'  };
            await base.InsertTestAsync<UserGame>(userGame);

        }

        [TestMethod]
        public async Task DeleteTestAsync()
        {
            await base.DeleteTestAsync1<UserGame>(new KeyValuePair<string, string>("Description", "Other"));
        }

        [TestMethod]
        public async Task LoadByIdTestAsync()
        {
            await base.LoadByIdTestAsync<UserGame>(new KeyValuePair<string, string>("Description", "Other"));
        }

        [TestMethod]
        public async Task UpdateTestAsync()
        {
            UserGame userGame = new UserGame { Color = 'B' };
            await base.UpdateTestAsync<UserGame>(new KeyValuePair<string, string>("Description", "Other"), userGame);

        }

    }
}
