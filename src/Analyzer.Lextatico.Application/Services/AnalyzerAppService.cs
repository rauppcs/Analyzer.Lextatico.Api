using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Analyzer.Lextatico.Application.Dtos.Analyzer;
using Analyzer.Lextatico.Application.Dtos.Filter;
using Analyzer.Lextatico.Application.Services.Interfaces;
using Analyzer.Lextatico.Domain.Dtos.Message;
using Analyzer.Lextatico.Domain.Interfaces.Services;
using Analyzer.Lextatico.Domain.Models;
using Analyzer.Lextatico.Infra.Identity.User;
using Analyzer.Lextatico.Sly.Lexer;
using Analyzer.Lextatico.Sly.Parser;
using AnalyzerModel = Analyzer.Lextatico.Domain.Models.Analyzer;

namespace Analyzer.Lextatico.Application.Services
{
    public class AnalyzerAppService : IAnalyzerAppService
    {
        private readonly IMapper _mapper;
        private readonly IMessage _message;
        private readonly IAspNetUser _aspNetUser;
        private readonly IAnalyzerService _analyzerService;


        public AnalyzerAppService(IMapper mapper, IMessage message, IAspNetUser aspNetUser, IAnalyzerService analyzerService)
        {
            _mapper = mapper;
            _message = message;
            _aspNetUser = aspNetUser;
            _analyzerService = analyzerService;

        }

        public async Task<AnalyzerWithTerminalTokensAndNonTerminalTokens> GetAnalyzerByIdAsync(Guid analyzerId)
        {
            var analyzer = _mapper.Map<AnalyzerWithTerminalTokensAndNonTerminalTokens>(await _analyzerService.GetByIdAsync(analyzerId));

            analyzer.NonTerminalTokens = analyzer.NonTerminalTokens.OrderBy(order => order.Sequence);

            foreach (var nonTerminalToken in analyzer.NonTerminalTokens)
            {
                nonTerminalToken.NonTerminalTokenRules = nonTerminalToken
                    .NonTerminalTokenRules.OrderBy(order => order.Sequence);
            }

            return analyzer;
        }

        public async Task<IEnumerable<AnalyzerDto>> GetAnalyzersByLoggedUserAsync()
        {
            var analyzers = _mapper.Map<IEnumerable<AnalyzerDto>>(await _analyzerService.GetAnalyzersByLoggedUserAsync());

            return analyzers;
        }

        public async Task<(IEnumerable<AnalyzerDto>, int)> GetAnalyzersPaggedByLoggedUserAsync(int page, int size)
        {
            var (analyzers, total) = await _analyzerService.GetAnalyzersPaggedByLoggedUserAsync(page, size);

            var analyzerSummaries = _mapper.Map<IEnumerable<AnalyzerDto>>(analyzers);

            return (analyzerSummaries, total);
        }

        public async Task<bool> CreateAnalyzerAsync(AnalyzerWithTerminalTokensAndNonTerminalTokens analyzerWithTerminalTokensAndNonTerminalTokens)
        {
            var analyzerDb = _mapper.Map<AnalyzerModel>(analyzerWithTerminalTokensAndNonTerminalTokens);

            analyzerDb.SetApplicationUserId(_aspNetUser.GetUserId());

            var result = await _analyzerService.CreateAsync(analyzerDb);

            return result;
        }

        public async Task<bool> UpdateAnalyzerAsync(AnalyzerWithTerminalTokensAndNonTerminalTokens analyzerWithTerminalTokensAndNonTerminalTokens)
        {
            var analyzerDb = _mapper.Map<AnalyzerModel>(analyzerWithTerminalTokensAndNonTerminalTokens);

            analyzerDb.SetApplicationUserId(_aspNetUser.GetUserId());

            var result = await _analyzerService.UpdateAsync(analyzerDb);

            return result;
        }

        public async Task<bool> DeleteAnalyzerByIdAsync(Guid analyzerId)
        {
            var result = await _analyzerService.DeleteAsync(analyzerId);

            // TODO: AQUI VERIFICAR COMO LANÇAR 404

            return result;
        }

        public async Task<bool> DeleteAnalyzersByIdAsync(IEnumerable<Guid> analyzersIds)
        {
            var result = await _analyzerService.DeleteAsync(analyzersIds);

            return result;
        }

        public async Task<ParseResult<Token>> TestAnalyzerByIdAsync(Guid analyzerId, TesteAnalyzerDto testeAnalyzer)
        {
            var result = await _analyzerService.TestAnalyzer(analyzerId, testeAnalyzer.Content);

            return result;
        }
    }
}
