namespace ChessGPT.API.Services
{
    public interface IOpenAIService
    {
        Task<string> CompleteSentence(string text);
        Task<string> ComputerMove(string board);
    }
}
