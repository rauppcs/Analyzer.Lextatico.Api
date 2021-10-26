using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lextatico.Api.Controllers.Base;
using Lextatico.Domain.Dtos.Message;
using Microsoft.AspNetCore.Mvc;

namespace Lextatico.Api.Controllers
{
    public class TerminalTokenController : LextaticoController
    {
        public TerminalTokenController(IMessage message)
            : base(message)
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetTerminalTokens()
        {
            throw new NotImplementedException();
        }
    }
}