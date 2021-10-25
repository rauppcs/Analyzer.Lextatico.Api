using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lextatico.Domain.Interfaces.Repositories;
using Lextatico.Domain.Models;
using Lextatico.Infra.Data.Context;

namespace Lextatico.Infra.Data.Repositories
{
    public class AnalyzerRepository : Repository<Analyzer>, IAnalyzerRepository
    {
        public AnalyzerRepository(LextaticoContext lextaticoContext)
            : base(lextaticoContext)
        {
        }

        public async Task<Analyzer> SelectAnalyzerByUserIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}