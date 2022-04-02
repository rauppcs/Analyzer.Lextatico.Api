using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Analyzer.Lextatico.Domain.Models;
using Analyzer.Lextatico.Sly.Lexer;
using Analyzer.Lextatico.Sly.Parser;
using AnalyzerModel = Analyzer.Lextatico.Domain.Models.Analyzer;

namespace Analyzer.Lextatico.Domain.Interfaces.Services
{
    public interface IAnalyzerService : IService<AnalyzerModel>
    {
        Task<AnalyzerModel> GetAnalyzerByIdAndUserIdAsync(Guid id);
        Task<IEnumerable<AnalyzerModel>> GetAnalyzersByIdsAndByLoggedUserAsync(IEnumerable<Guid> analyzersIds);
        Task<IEnumerable<AnalyzerModel>> GetAnalyzersByLoggedUserAsync();
        Task<(IEnumerable<AnalyzerModel>, int)> GetAnalyzersPaggedByLoggedUserAsync(int page, int size);
        Task<ParseResult<Token>> TestAnalyzerByIdAndUserIdAsync(Guid analyzerId, string content);
    }
}
