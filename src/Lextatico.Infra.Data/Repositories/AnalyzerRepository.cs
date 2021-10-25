using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lextatico.Domain.Interfaces.Repositories;
using Lextatico.Domain.Models;
using Lextatico.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Lextatico.Infra.Data.Repositories
{
    public class AnalyzerRepository : Repository<Analyzer>, IAnalyzerRepository
    {
        public AnalyzerRepository(LextaticoContext lextaticoContext)
            : base(lextaticoContext)
        {
        }

        public async Task<IEnumerable<Analyzer>> SelectAnalyzersByUserIdAsync(Guid userId) =>
            await _dataSet.Where(f => f.ApplicationUserId == userId).ToListAsync();
    }
}