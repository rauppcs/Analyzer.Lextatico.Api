using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lextatico.Api.Controllers.Base;
using Lextatico.Application.Dtos.Analyzer;
using Lextatico.Application.Dtos.Filter;
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
        public async Task<IActionResult> GetAnalyzers([FromQuery] PaginationFilter pagination)
        {
            var (analyzers, total) = await _analyzerAppService
                .GetAnalyzersPaggedByLoggedUserAsync(pagination.Page, pagination.Size);

            return ReturnOk(analyzers, pagination, total);
        }

        [HttpGet, Route("{analyzerId:guid}")]
        public async Task<IActionResult> GetAnalyzer(Guid analyzerId)
        {
            var analyzer = await _analyzerAppService.GetAnalyzerByIdAsync(analyzerId);

            return ReturnOk(analyzer);
        }

        [HttpDelete, Route("{analyzerId:guid}")]
        public async Task<IActionResult> DeleteAnalyzer(Guid analyzerId)
        {
            await _analyzerAppService.DeleteAnalyzerByIdAsync(analyzerId);

            return ReturnOk();
        }
    }
}