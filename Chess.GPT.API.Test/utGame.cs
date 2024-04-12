

using ChessGPT.BL.Models;

namespace Chess.GPT.API.Test
{
    [TestClass]
    public class utGame : utBase
    {
        [TestMethod]
        public async Task LoadTestAsync()
        {
            await base.LoadTestAsync<Game>(3);
        }

        [TestMethod]
        public async Task InsertTestAsync()
        {
            Game game = new Game { GameName = "Test", GameTime = DateTime.Now, GameBoard = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR", GameState = 'o' };
            await base.InsertTestAsync<Game>(game);

        }

        [TestMethod]
        public async Task DeleteTestAsync()
        {
            await base.DeleteTestAsync1<Game>(new KeyValuePair<string, string>("GameName", "First Game"));
        }

        [TestMethod]
        public async Task LoadByIdTestAsync()
        {
            await base.LoadByIdTestAsync<Game>(new KeyValuePair<string, string>("GameName", "First Game"));
        }

        [TestMethod]
        public async Task UpdateTestAsync()
        {
            Game game = new Game { GameName = "Test", GameTime = DateTime.Now, GameBoard = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR", GameState = 'w' };
            await base.UpdateTestAsync<Game>(new KeyValuePair<string, string>("GameState", "o"), game);

        }

    }
}
