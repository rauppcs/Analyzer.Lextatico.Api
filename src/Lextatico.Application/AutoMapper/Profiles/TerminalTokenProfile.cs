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
            CreateMap<TerminalToken, TerminalTokenDto>().ReverseMap();

            CreateMap<TerminalTokenDto, AnalyzerTerminalToken>()
                .ForMember(analyzerTerminalToken => analyzerTerminalToken.Id,
                    options => options.Ignore())
                .ForMember(analyzerTerminalToken => analyzerTerminalToken.TerminalTokenId,
                    options => options.MapFrom(terminalTokenDto => terminalTokenDto.Id))
                .ReverseMap()
                .ForAllMembers(options =>
                    options.MapFrom(analyzerTerminalToken => analyzerTerminalToken.TerminalToken));
        }
    }
}
