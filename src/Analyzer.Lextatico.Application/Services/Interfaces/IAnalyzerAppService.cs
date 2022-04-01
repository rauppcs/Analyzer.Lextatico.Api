using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Analyzer.Lextatico.Application.Dtos.Analyzer;
using Analyzer.Lextatico.Sly.Lexer;
using Analyzer.Lextatico.Sly.Parser;

namespace Analyzer.Lextatico.Application.Services.Interfaces
{
    public interface IAnalyzerAppService : IAppService
    {
        Task<AnalyzerWithTerminalTokensAndNonTerminalTokens> GetAnalyzerByLoggedUserAsync(Guid analyzerId);
        Task<IEnumerable<AnalyzerDto>> GetAnalyzersByLoggedUserAsync();
        Task<(IEnumerable<AnalyzerDto>, int)> GetAnalyzersPaggedByLoggedUserAsync(int page, int size);
        Task<bool> CreateAnalyzerAndByLoggedUserAsync(AnalyzerWithTerminalTokensAndNonTerminalTokens analyzer);
        Task<bool> UpdateAnalyzerAndByLoggedUserAsync(AnalyzerWithTerminalTokensAndNonTerminalTokens analyzer);
        Task<bool> DeleteAnalyzerByIdAndByLoggedUserAsync(Guid analyzerId);
        Task<bool> DeleteAnalyzersByIdAndByLoggedUserAsync(IEnumerable<Guid> analyzerIds);
        Task<ParseResult<Token>> TestAnalyzerByIdAndByLoggedUserAsync(Guid analyzerId, TesteAnalyzerDto testeAnalyzer);
    }
}
