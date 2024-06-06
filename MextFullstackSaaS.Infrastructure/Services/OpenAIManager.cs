using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models.OpenAI;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MextFullstackSaaS.Domain.Enums;

namespace MextFullstackSaaS.Infrastructure.Services
{
    public class OpenAIManager :IOpenAIService
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly OpenAI.Interfaces.IOpenAIService _openAiService;

        public OpenAIManager(OpenAI.Interfaces.IOpenAIService openAiService, ICurrentUserService currentUserService) { 
        
            _openAiService = openAiService;
            _currentUserService = currentUserService;
        }

        public async Task<List<string>> DallECreateIconAsync(DallECreateIconRequestDto requestDto, CancellationToken cancellationToken)
        {
            var imageResult = await _openAiService.Image.CreateImage(new ImageCreateRequest
            {
                Prompt = CreateIconPrompt(requestDto),
                N = requestDto.Quantity,
                Size = GetSize(requestDto.Size),
                ResponseFormat = StaticValues.ImageStatics.ResponseFormat.Url,

                User = _currentUserService.UserId.ToString()
            },cancellationToken);//Task<ImageCreateResponse> 

            return imageResult
                .Results
                .Select(x => x.Url)
                .ToList();
        }
        private string GetSize(IconSize size)
        {
            return size switch
            {
                IconSize.Small => StaticValues.ImageStatics.Size.Size256,
                IconSize.Medium => StaticValues.ImageStatics.Size.Size512,
                IconSize.Large => StaticValues.ImageStatics.Size.Size1024,
                _ => StaticValues.ImageStatics.Size.Size256,
            };
        }

        private string CreateIconPrompt(DallECreateIconRequestDto request)
        {
            return $"Generate icon with the following specifications:\n" +
                   $"- **Description:** {request.Description}\n" +
                   $"- **Colour:** {request.ColourCode}\n" +
                   $"- **Model:** {request.Model}\n" +
                   $"- **Design Type:** {request.DesignType}\n" +
                   $"- **Size:** {request.Size}\n" +
                   $"- **Shape:** {request.Shape}\n\n" +
                   "Please ensure the icon adhere to the specified design type and are visually appealing.";
        }
    }
}
