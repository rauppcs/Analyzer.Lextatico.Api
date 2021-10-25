using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lextatico.Application.Dtos.Analyzer;

namespace Lextatico.Application.Services.Interfaces
{
    public interface IAnalyzerAppService : IAppService
    {
        Task<AnalyzerDetailDto> GetAnalyzerByIdAsync(Guid id);
        Task<IEnumerable<AnalyzerSummaryDto>> GetAnalyzersByLoggedUserAsync();
    }
}