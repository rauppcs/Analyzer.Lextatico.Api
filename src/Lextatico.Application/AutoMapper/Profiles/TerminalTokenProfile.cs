using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lextatico.Application.Dtos.TerminalToken;
using Lextatico.Domain.Models;

namespace Lextatico.Application.AutoMapper.Profiles
{
    public class TerminalTokenProfile : Profile
    {
        public TerminalTokenProfile()
        {
            // DTO TO MODEL

            // MODEL TO DTO
            CreateMap<TerminalToken, TerminalTokenDto>();
        }
    }
}