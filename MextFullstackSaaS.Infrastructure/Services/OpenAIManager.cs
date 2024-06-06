using MextFullstackSaaS.Application.Common.Interfaces;
using MextFullstackSaaS.Application.Common.Models.OpenAI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaaS.Infrastructure.Services
{
    public class OpenAIManager :IOpenAIService
    {
        public Task<List<string>> DallECreateIconAsync(DallECreateIconRequestDto requestDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
