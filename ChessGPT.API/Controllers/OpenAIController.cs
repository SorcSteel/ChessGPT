using ChessGPT.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChessGPT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAIController : Controller
    {
        private readonly ILogger<OpenAIController> logger;
        private readonly IOpenAIService openAiService;
        public OpenAIController(ILogger<OpenAIController> logger,
                                IOpenAIService openAiService)
        {
            this.logger = logger;
            this.openAiService = openAiService;
        }

        /// <summary>
        /// OpenAI autocompletes the given sentence
        /// </summary>

        [HttpPost()]
        [Route("CompleteSentence")]
        public async Task<IActionResult> CompleteSentence(string text)
        {
            var result = await openAiService.CompleteSentence(text);
            return Ok(result);
        }
        /// <summary>
        /// Returns a move in FEN Notation when given a board state
        /// </summary>

        [HttpPost()]
        [Route("ComputerMove")]
        public async Task<IActionResult> ComputerMove(string board)
        {
            var result = await openAiService.ComputerMove(board);
            return Ok(result);
        }
    }
}
