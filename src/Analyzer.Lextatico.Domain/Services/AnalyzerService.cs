using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Analyzer.Lextatico.Domain.Dtos.Message;
using Analyzer.Lextatico.Domain.Exceptions;
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

        public async Task<AnalyzerModel> GetAnalyzerByIdAndUserIdAsync(Guid id)
        {
            var userId = _aspNetUser.GetUserId();

            var analyzer = await _analyzerRepository.SelectAnalyzerByIdAndUserIdAsync(id, userId);

            if (analyzer == null)
                throw new NotFoundException("Analisador não encontrado");

            return analyzer;
        }

        public async Task<IEnumerable<AnalyzerModel>> GetAnalyzersByIdsAndByLoggedUserAsync(IEnumerable<Guid> analyzersIds)
        {
            var userId = _aspNetUser.GetUserId();

            var analyzers = await _analyzerRepository.SelectAnalyzersByIdsByUserIdAsync(analyzersIds, userId);

            return analyzers;
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

        public async Task<ParseResult<Token>> TestAnalyzerByIdAndUserIdAsync(Guid analyzerId, string content)
        {
            var analyzerDb = await GetAnalyzerByIdAndUserIdAsync(analyzerId);

            if (analyzerDb == null)
                throw new NotFoundException("Analisador não encontrado");

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

        public override async Task<bool> CreateAsync(AnalyzerModel analyzer)
        {
            if (analyzer.ApplicationUserId != _aspNetUser.GetUserId())
                throw new NotFoundException("Analisador não encontrado");

            return await base.CreateAsync(analyzer);
        }

        public override async Task<bool> UpdateAsync(AnalyzerModel analyzer)
        {
            if (analyzer.ApplicationUserId != _aspNetUser.GetUserId())
                throw new NotFoundException("Analisador não encontrado");

            return await base.UpdateAsync(analyzer);
        }

        public override async Task<bool> DeleteAsync(AnalyzerModel analyzer)
        {
            if (analyzer.ApplicationUserId != _aspNetUser.GetUserId())
                throw new NotFoundException("Analisador não encontrado");

            return await base.DeleteAsync(analyzer);
        }

        public override async Task<bool> DeleteAsync(IEnumerable<AnalyzerModel> analyzers)
        {
            if (!analyzers.Any(a => a.ApplicationUserId == _aspNetUser.GetUserId()))
                throw new NotFoundException("Analisador não encontrado");

            return await base.DeleteAsync(analyzers);
        }
    }
}
