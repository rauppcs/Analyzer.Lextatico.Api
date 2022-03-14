using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Analyzer.Lextatico.Domain.Dtos.Message;
using Analyzer.Lextatico.Domain.Interfaces.Repositories;
using Analyzer.Lextatico.Domain.Interfaces.Services;
using Analyzer.Lextatico.Domain.Models;
using Analyzer.Lextatico.Infra.Identity.User;
using Analyzer.Lextatico.Sly.Lexer;
using Analyzer.Lextatico.Sly.Parser;
using Analyzer.Lextatico.Sly.Parser.Builder;
using AnalyzerModel = Analyzer.Lextatico.Domain.Models.Analyzer;

namespace Analyzer.Lextatico.Domain.Services
{
    public class AnalyzerService : Service<AnalyzerModel>, IAnalyzerService
    {
        private readonly IMessage _message;
        private readonly IAnalyzerRepository _analyzerRepository;
        private readonly IAspNetUser _aspNetUser;

        public AnalyzerService(IMessage message, IAnalyzerRepository analyzerRepository, IAspNetUser aspNetUser)
            : base(analyzerRepository)
        {
            _message = message;
            _analyzerRepository = analyzerRepository;
            _aspNetUser = aspNetUser;
        }

        public async Task<IEnumerable<AnalyzerModel>> GetAnalyzersByLoggedUserAsync()
        {
            var userId = _aspNetUser.GetUserId();

            var analyzers = await _analyzerRepository.SelectAnalyzersByUserIdAsync(userId);

            return analyzers;
        }

        public async Task<(IEnumerable<AnalyzerModel>, int)> GetAnalyzersPaggedByLoggedUserAsync(int page, int size)
        {
            var userId = _aspNetUser.GetUserId();

            var result = await _analyzerRepository.SelectAnalyzersPaggedByUserIdAsync(userId, page, size);

            return result;
        }

        public async Task<ParseResult<Token>> TestAnalyzer(Guid analyzerId, string content)
        {
            var analyzerDb = await GetByIdAsync(analyzerId);

            var startingNonTerminalToken = analyzerDb.NonTerminalTokens.FirstOrDefault(f => f.IsStart);

            if (startingNonTerminalToken == null)
            {
                _message.AddError("Analisador não possui regra inicial.");

                return null;
            }

            var tokens = analyzerDb.AnalyzerTerminalTokens
                .Select(s => s.TerminalToken)
                .Select(s =>
                    new Token(
                        s.Name,
                        s.ViewName,
                        s.Resume,
                        s.Lexeme,
                        Enum.Parse<TokenType>(s.TokenType.ToString()),
                        s.IdentifierType != null ? Enum.Parse<IdentifierType>(s.IdentifierType.ToString()) : null))
                        .ToList();

            var productionRules = analyzerDb.NonTerminalTokens
                .SelectMany(s => s.NonTerminalTokenRules).OrderBy(order => order.Sequence)
                .Select(s => $"{s.NonTerminalToken.Name}: { string.Join(" ", s.NonTerminalTokenRuleClauses.OrderBy(order => order.Sequence).Select(ss => ss.IsTerminalToken ? ss.TerminalToken.ViewName : ss.NonTerminalToken.Name))}");

            if (!productionRules.Any())
            {
                _message.AddError("Analisador não possui regras de produção.");

                return null;
            }

            var lextaticoParserBuilder = new LextaticoParserBuilder<Token>(tokens);

            var buildResult = lextaticoParserBuilder.BuildParser(startingNonTerminalToken.Name, ParserType.LlRecursiveDescent, productionRules);

            if (!buildResult.IsOk)
            {
                buildResult.Errors.ForEach(error =>
                {
                    _message.AddError(error.Message);
                });

                return null;
            }

            var parseResult = buildResult.Result.Parse(content, startingNonTerminalToken.Name);

            if (!parseResult.IsOk)
            {
                parseResult.Errors.ForEach(error =>
                {
                    _message.AddError(error.ErrorMessage);
                });

                return null;
            }

            return parseResult;
        }
    }
}
