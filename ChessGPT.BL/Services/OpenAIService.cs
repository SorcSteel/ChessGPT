using ChessGPT.BL.Services;
using Microsoft.Extensions.Options;

namespace ChessGPT.BL
{
    public class OpenAIService : IOpenAIService
    {
        private readonly OpenAIConfig openAIConfig;
        public OpenAIService(IOptionsMonitor<OpenAIConfig> options)
        {
            this.openAIConfig = options.CurrentValue;
        }

        public Task<string> CompleteSentence(string text)
        {
            var api = new OpenAI_API.OpenAIAPI(openAIConfig.apiKey);
            var result = api.Completions.GetCompletion(text);
            return result;
        }

        public async Task<string> ComputerMove(string board)
        {
            var api = new OpenAI_API.OpenAIAPI(openAIConfig.apiKey);
            var chat = api.Chat.CreateConversation();

            chat.AppendSystemMessage("You are a chess bot that is playing against a player. You will be sent a board in FEN Notation, you are the black pieces designated by lowercase letters and the player are the white pieces designated by uppercase letters. You will respond by playing the best move and changing the FEN notation. You cannot En Passant or Castle. You will only respond with the FEN notation.");

            chat.AppendUserInput(board);

            var response = await chat.GetResponseFromChatbotAsync();
            return response;
        }
    }
}
