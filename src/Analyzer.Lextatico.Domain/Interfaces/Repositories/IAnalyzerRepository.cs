using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnalyzerModel = Analyzer.Lextatico.Domain.Models.Analyzer;

namespace Analyzer.Lextatico.Domain.Interfaces.Repositories
{
    public interface IAnalyzerRepository : IBaseRepository<AnalyzerModel>
    {
        Task<IEnumerable<AnalyzerModel>> SelectAnalyzersByUserIdAsync(Guid userId);
        Task<(IEnumerable<AnalyzerModel>, int)> SelectAnalyzersPaggedByUserIdAsync(Guid userId, int page, int size);
    }
}
