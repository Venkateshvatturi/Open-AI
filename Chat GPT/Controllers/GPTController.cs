using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API.Completions;
using OpenAI_API;

namespace Chat_GPT.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GPTController : ControllerBase
    {
        [HttpGet]

        public async Task<IActionResult> GetData(string input)
        {

            Console.WriteLine("Method Entered!");
            string apikey = "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";
            string response = "";
            OpenAIAPI gptcontroller = new OpenAIAPI(apikey);
            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = input;
            completion.Model = "text-davinci-003";
            completion.MaxTokens = 4000;
            var output = await gptcontroller.Completions.CreateCompletionsAsync(completion);
            if (output != null)
            {
                foreach (var item in output.Completions)
                {
                    response = item.Text;

                }
                return Ok(response);

            }
            else
            {
                return BadRequest("NotFound");
            }
        }
    }
}