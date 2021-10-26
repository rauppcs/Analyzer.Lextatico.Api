using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lextatico.Api.Controllers.Base;
using Lextatico.Application.Dtos.Analyzer;
using Lextatico.Application.Dtos.Response;
using Lextatico.Application.Services.Interfaces;
using Lextatico.Domain.Dtos.Message;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lextatico.Api.Controllers
{
    public class AnalyzerController : LextaticoController
    {
        private readonly IAnalyzerAppService _analyzerAppService;
        public AnalyzerController(IMessage message, IAnalyzerAppService analyzerAppService)
            : base(message)
        {
            _analyzerAppService = analyzerAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnalyzers()
        {
            var analyzers = await _analyzerAppService.GetAnalyzersByLoggedUserAsync();

            return ReturnOk(analyzers);
        }

        [HttpGet, Route("{analyzerId:guid}")]
        public async Task<IActionResult> GetAnalyzers(Guid analyzerId)
        {
            var analyzer = await _analyzerAppService.GetAnalyzerByIdAsync(analyzerId);

            return ReturnOk(analyzer);
        }
    }
}