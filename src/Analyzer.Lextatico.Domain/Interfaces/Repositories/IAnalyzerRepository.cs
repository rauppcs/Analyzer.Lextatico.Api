using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnalyzerModel = Analyzer.Lextatico.Domain.Models.Analyzer;

namespace Analyzer.Lextatico.Domain.Interfaces.Repositories
{
    public interface IAnalyzerRepository : IBaseRepository<AnalyzerModel>
    {
        Task<AnalyzerModel> SelectAnalyzerByIdAndUserIdAsync(Guid id, Guid userId);
        Task<IEnumerable<AnalyzerModel>> SelectAnalyzersByUserIdAsync(Guid userId);
        Task<IEnumerable<AnalyzerModel>> SelectAnalyzersByIdsByUserIdAsync(IEnumerable<Guid> analyzersIds, Guid userId);
        Task<(IEnumerable<AnalyzerModel>, int)> SelectAnalyzersPaggedByUserIdAsync(Guid userId, int page, int size);
    }
}
