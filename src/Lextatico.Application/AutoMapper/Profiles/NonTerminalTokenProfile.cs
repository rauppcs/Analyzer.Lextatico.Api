using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lextatico.Application.Dtos.NonTerminalToken;
using Lextatico.Domain.Models;
using Microsoft.Extensions.Options;

namespace Lextatico.Application.AutoMapper.Profiles
{
    public class NonTerminalTokenProfile : Profile
    {
        public NonTerminalTokenProfile()
        {
            CreateMap<NonTerminalToken, NonTerminalTokenDto>().ReverseMap();

            CreateMap<NonTerminalToken, NonTerminalTokenDetailDto>().ReverseMap();

            CreateMap<NonTerminalToken, NonTerminalTokenDetailWithRulesAndClausesDto>();

            CreateMap<NonTerminalTokenDto, AnalyzerNonTerminalToken>()
                .ForMember(analyzerNonTerminalToken => analyzerNonTerminalToken.Id,
                    options => options.Ignore())
                .ForMember(analyzerNonTerminalToken => analyzerNonTerminalToken.NonTerminalTokenId,
                    options => options.MapFrom(nonTerminalTokenDto => nonTerminalTokenDto.Id))
                .ReverseMap()
                .ForAllMembers(options =>
                    options.MapFrom(analyzerNonTerminalToken => analyzerNonTerminalToken.NonTerminalToken));

            CreateMap<NonTerminalTokenDetailWithRulesAndClausesDto, AnalyzerNonTerminalToken>()
                .ForMember(analyzerNonTerminalToken => analyzerNonTerminalToken.Id,
                    options => options.Ignore())
                .ForMember(analyzerNonTerminalToken => analyzerNonTerminalToken.NonTerminalTokenId,
                    options => options.MapFrom(nonTerminalTokenDetailWithRulesAndClausesDto => nonTerminalTokenDetailWithRulesAndClausesDto.Id))
                .ForMember(analyzerNonTerminalToken => analyzerNonTerminalToken.NonTerminalToken,
                    options => options.MapFrom(nonTerminalTokenDetailWithRulesAndClausesDto => nonTerminalTokenDetailWithRulesAndClausesDto))
                .ForPath(analyzerNonTerminalToken => analyzerNonTerminalToken.NonTerminalToken.NonTerminalTokenRules,
                    options => options.MapFrom(nonTerminalTokenDetailWithRulesAndClausesDto => nonTerminalTokenDetailWithRulesAndClausesDto.NonTerminalTokenRules))
                .ReverseMap()
                .ForAllMembers(options =>
                    options.MapFrom(analyzerNonTerminalToken => analyzerNonTerminalToken.NonTerminalToken));

            CreateMap<NonTerminalTokenRuleWithClausesDto, NonTerminalTokenRule>().ReverseMap();

            CreateMap<NonTerminalTokenRuleClauseDto, NonTerminalTokenRuleClause>()
                .ForMember(nonTerminalTokenRuleClause => nonTerminalTokenRuleClause.TerminalTokenId,
                    options => options.AllowNull())
                .ForMember(nonTerminalTokenRuleClause => nonTerminalTokenRuleClause.NonTerminalTokenId,
                    options => options.AllowNull())
                .ReverseMap();
        }
    }
}
