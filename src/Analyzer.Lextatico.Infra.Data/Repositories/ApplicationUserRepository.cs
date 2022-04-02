using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Analyzer.Lextatico.Domain.Interfaces.Repositories;
using Analyzer.Lextatico.Domain.Models;
using Analyzer.Lextatico.Infra.Data.Context;

namespace Analyzer.Lextatico.Infra.Data.Repositories
{
    public class ApplicationUserRepository : BaseRepository<ApplicationUser>, IApplicationUserRepository
    {
        public ApplicationUserRepository(LextaticoContext lextaticoContext)
            : base(lextaticoContext)
        {
        }
    }
}
