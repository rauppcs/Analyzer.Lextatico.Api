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
            CreateMap<Analyzer, AnalyzerSummaryDto>();
            CreateMap<Analyzer, AnalyzerDetailDto>();
        }
    }
}