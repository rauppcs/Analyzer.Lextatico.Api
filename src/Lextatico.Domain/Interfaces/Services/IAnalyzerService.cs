using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lextatico.Domain.Models;

namespace Lextatico.Domain.Interfaces.Services
{
    public interface IAnalyzerService : IService<Analyzer>
    {
        Task<IEnumerable<Analyzer>> GetAnalyzersByLoggedUserAsync();
        Task<(IEnumerable<Analyzer>, int)> GetAnalyzersPaggedByLoggedUserAsync(int page, int size);
    }
}