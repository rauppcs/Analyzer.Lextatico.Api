using Analyzer.Lextatico.Application.Dtos.Analyzer;
using Analyzer.Lextatico.Application.Dtos.Filter;
using Analyzer.Lextatico.Application.Services.Interfaces;
using Analyzer.Lextatico.Domain.Dtos.Message;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Analyzer.Lextatico.Api.Controllers.V1
{
    [ApiVersion("1.0")]
    public class AnalyzerController : LextaticoController
    {
        private readonly IAnalyzerAppService _analyzerAppService;
        public AnalyzerController(IMessage message, IAnalyzerAppService analyzerAppService)
            : base(message)
        {
            _analyzerAppService = analyzerAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnalyzers([FromQuery] PaginationFilterDto pagination)
        {
            var (analyzers, total) = await _analyzerAppService
                .GetAnalyzersPaggedByLoggedUserAsync(pagination.Page, pagination.Size);

            return ReturnOk(analyzers, pagination, total);
        }

        [HttpGet, Route("{analyzerId:guid}")]
        public async Task<IActionResult> GetAnalyzer(Guid analyzerId)
        {
            var analyzer = await _analyzerAppService.GetAnalyzerByLoggedUserAsync(analyzerId);

            return ReturnOk(analyzer);
        }

        [HttpPost]
        public async Task<IActionResult> PostAnalyzer(AnalyzerWithTerminalTokensAndNonTerminalTokensDto analyzer)
        {
            await _analyzerAppService.CreateAnalyzerAndByLoggedUserAsync(analyzer);

            return ReturnCreated();
        }

        [HttpPut, Route("{analyzerId:guid}")]
        public async Task<IActionResult> PutAnalyzer([FromRoute] Guid analyzerId, AnalyzerWithTerminalTokensAndNonTerminalTokensDto analyzer)
        {
            analyzer.Id = analyzerId;

            await _analyzerAppService.UpdateAnalyzerAndByLoggedUserAsync(analyzer);

            return ReturnOk();
        }

        [HttpDelete, Route("{analyzerId:guid}")]
        public async Task<IActionResult> DeleteAnalyzer(Guid analyzerId)
        {
            await _analyzerAppService.DeleteAnalyzerByIdAndByLoggedUserAsync(analyzerId);

            return ReturnOk();
        }

        [HttpPost, Route("deleteBulk")]
        public async Task<IActionResult> DeleteAnalyzers([FromBody] IEnumerable<Guid> analyzerIds)
        {
            await _analyzerAppService.DeleteAnalyzersByIdAndByLoggedUserAsync(analyzerIds);

            return ReturnOk();
        }

        [HttpPost, Route("{analyzerId:guid}/test")]
        public async Task<IActionResult> TestAnalyzer([FromRoute] Guid analyzerId, TesteAnalyzerDto testeAnalyzer)
        {
            var result = await _analyzerAppService.TestAnalyzerByIdAndByLoggedUserAsync(analyzerId, testeAnalyzer);

            return ReturnOk(result);
        }
    }
}
