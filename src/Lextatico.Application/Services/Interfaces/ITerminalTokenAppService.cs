using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lextatico.Application.Dtos.TerminalToken;

namespace Lextatico.Application.Services.Interfaces
{
    public interface ITerminalTokenAppService
    {
        Task<TerminalTokenDetailDto> GetTerminalToken(Guid terminalTokenId);
        Task<IEnumerable<TerminalTokenDetailDto>> GetTerminalTokens();
    }
}
