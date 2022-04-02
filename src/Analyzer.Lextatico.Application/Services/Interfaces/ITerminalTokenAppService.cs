using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Analyzer.Lextatico.Application.Dtos.TerminalToken;

namespace Analyzer.Lextatico.Application.Services.Interfaces
{
    public interface ITerminalTokenAppService
    {
        Task<TerminalTokenDto> GetTerminalToken(Guid terminalTokenId);
        Task<IEnumerable<TerminalTokenDto>> GetTerminalTokens();
    }
}
