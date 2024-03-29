﻿using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;

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