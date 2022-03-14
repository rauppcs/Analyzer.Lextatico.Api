using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Analyzer.Lextatico.Domain.Dtos.Message;
using Analyzer.Lextatico.Domain.Interfaces.Repositories;
using Analyzer.Lextatico.Domain.Interfaces.Services;
using Analyzer.Lextatico.Domain.Models;

namespace Analyzer.Lextatico.Domain.Services
{
    public class TerminalTokenService : Service<TerminalToken>, ITerminalTokenService
    {
        public TerminalTokenService(ITerminalTokenRepository terminalTokenRepository, IMessage message) 
            : base(terminalTokenRepository)
        {
        }
    }
}
