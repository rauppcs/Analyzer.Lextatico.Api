using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Analyzer.Lextatico.Application.Dtos.Analyzer;
using Analyzer.Lextatico.Domain.Models;
using AnalyzerModel = Analyzer.Lextatico.Domain.Models.Analyzer;

namespace Analyzer.Lextatico.Application.AutoMapper.Profiles
{
    public class AnalyzerProfile : Profile
    {
        public AnalyzerProfile()
        {
            CreateMap<AnalyzerModel, AnalyzerDto>().ReverseMap();

            CreateMap<AnalyzerWithTerminalTokensAndNonTerminalTokensDto, AnalyzerModel>()
                .ForMember(analyzer => analyzer.AnalyzerTerminalTokens,
                    options => options.MapFrom(analyzerWithTerminalTokensAndNonTerminalTokens => analyzerWithTerminalTokensAndNonTerminalTokens.TerminalTokens))
                .ForMember(analyzer => analyzer.NonTerminalTokens,
                    options => options.MapFrom(analyzerWithTerminalTokensAndNonTerminalTokens => analyzerWithTerminalTokensAndNonTerminalTokens.NonTerminalTokens))
                .ReverseMap();
        }
    }
}
