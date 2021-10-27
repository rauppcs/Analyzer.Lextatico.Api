using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lextatico.Domain.Dtos.Message;
using Lextatico.Domain.Interfaces.Repositories;
using Lextatico.Domain.Interfaces.Services;
using Lextatico.Domain.Models;
using Lextatico.Infra.Identity.User;

namespace Lextatico.Domain.Services
{
    public class AnalyzerService : Service<Analyzer>, IAnalyzerService
    {
        private readonly IAnalyzerRepository _analyzerRepository;
        private readonly IAspNetUser _aspNetUser;

        public AnalyzerService(IAnalyzerRepository analyzerRepository, IAspNetUser aspNetUser, IMessage message)
            : base(analyzerRepository)
        {
            _analyzerRepository = analyzerRepository;
            _aspNetUser = aspNetUser;
        }

        public async Task<IEnumerable<Analyzer>> GetAnalyzersByLoggedUserAsync()
        {
            var userId = _aspNetUser.GetUserId();

            var analyzers = await _analyzerRepository.SelectAnalyzersByUserIdAsync(userId);

            return analyzers;
        }

        public async Task<(IEnumerable<Analyzer>, int)> GetAnalyzersPaggedByLoggedUserAsync(int page, int size)
        {
            var userId = _aspNetUser.GetUserId();

            var result = await _analyzerRepository.SelectAnalyzersPaggedByUserIdAsync(userId, page, size);

            return result;
        }
    }
}