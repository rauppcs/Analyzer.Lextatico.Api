using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lextatico.Api.Controllers.Base;
using Lextatico.Domain.Dtos.Message;
using Microsoft.AspNetCore.Mvc;

namespace Lextatico.Api.Controllers
{
    public class AnalyzerController : LextaticoController
    {
        public AnalyzerController(IMessage message) : base(message)
        {
        }

        [Route("/")]
        [HttpGet]
        public async Task<IActionResult> GetAnalyzers()
        {
            throw new NotImplementedException();
        }

        [Route("/{idAnalyzer:guid}")]
        [HttpGet]
        public async Task<IActionResult> GetAnalyzers(Guid idAnalyzer)
        {
            throw new NotImplementedException();
        }
    }
}