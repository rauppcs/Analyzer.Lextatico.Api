using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lextatico.Application.Dtos.Analyzer;
using Lextatico.Domain.Models;

namespace Lextatico.Application.AutoMapper.Profiles
{
    public class AnalyzerProfile : Profile
    {
        public AnalyzerProfile()
        {
            // MODEL TO DTO
            CreateMap<Analyzer, AnalyzerDto>();
            CreateMap<Analyzer, AnalyzerDetailDto>();

            // DTO TO MODEL
            CreateMap<AnalyzerWithTerminalTokensAndNonTerminalTokens, Analyzer>()
                .ForMember(a => a.AnalyzerTerminalTokens, 
                    options => options.MapFrom(analyzer => analyzer.TerminalTokens));

            
        }
    }
}