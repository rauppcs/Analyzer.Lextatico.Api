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
            // MODEL TO DTO
            CreateMap<TerminalToken, TerminalTokenDto>();
            CreateMap<TerminalToken, TerminalTokenDetailDto>();


            // DTO TO MODEL
            CreateMap<TerminalTokenDto, TerminalToken>();
            CreateMap<TerminalTokenDto, AnalyzerTerminalToken>()
                .ForMember(analyzerTerminalToken => analyzerTerminalToken.TerminalToken,
                    options => options.MapFrom(terminalTokenDto => terminalTokenDto));
        }
    }
}