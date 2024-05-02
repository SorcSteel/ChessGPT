namespace ChessGPT.BL
{
    public interface IOpenAIService
    {
        Task<string> CompleteSentence(string text);
        Task<string> ComputerMove(string board);
    }
}
