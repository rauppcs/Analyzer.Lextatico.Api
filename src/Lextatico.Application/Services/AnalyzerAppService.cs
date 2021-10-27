using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lextatico.Application.Dtos.Analyzer;
using Lextatico.Application.Services.Interfaces;
using Lextatico.Domain.Dtos.Message;
using Lextatico.Domain.Interfaces.Services;

namespace Lextatico.Application.Services
{
    public class AnalyzerAppService : IAnalyzerAppService
    {
        private readonly IMapper _mapper;
        private readonly IAnalyzerService _analyzerService;
        private readonly IMessage _message;

        public AnalyzerAppService(IMapper mapper, IAnalyzerService analyzerService, IMessage message)
        {
            _mapper = mapper;
            _analyzerService = analyzerService;
            _message = message;
        }

        public async Task<AnalyzerDetailDto> GetAnalyzerByIdAsync(Guid analyzerId)
        {
            var analyzer = _mapper.Map<AnalyzerDetailDto>(await _analyzerService.GetByIdAsync(analyzerId));

            return analyzer;
        }

        public async Task<IEnumerable<AnalyzerSummaryDto>> GetAnalyzersByLoggedUserAsync()
        {
            var analyzers = _mapper.Map<IEnumerable<AnalyzerSummaryDto>>(await _analyzerService.GetAnalyzersByLoggedUserAsync());

            return analyzers;
        }

        public async Task<bool> DeleteAnalyzerByIdAsync(Guid analyzerId)
        {
            var result = await _analyzerService.DeleteAsync(analyzerId);

            // TODO: AQUI VERIFICAR COMO LANÇAR 404

            return result;
        }
    }
}