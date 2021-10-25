using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lextatico.Domain.Models;
using Lextatico.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lextatico.Infra.Data.Configurations
{
    public class AnalyzerNonTerminalTokenConfiguration : IEntityTypeConfiguration<AnalyzerNonTerminalToken>
    {
        public void Configure(EntityTypeBuilder<AnalyzerNonTerminalToken> builder)
        {
            builder.DefineDefaultFields();

            builder.Property(analyzerToken => analyzerToken.AnalyzerId)
               .IsRequired();

            builder.Property(analyzerToken => analyzerToken.NonTerminalTokenId)
                .IsRequired();

            builder.HasIndex(analyzerToken => new { analyzerToken.AnalyzerId, analyzerToken.NonTerminalTokenId });

            builder.HasOne(analyzerNonTerminalToken => analyzerNonTerminalToken.Analyzer)
                .WithMany(analyzer => analyzer.AnalyzerNonTerminalTokens)
                .HasForeignKey(analyzerToken => analyzerToken.AnalyzerId);

            builder.HasOne(analyzerNonTerminalToken => analyzerNonTerminalToken.NonTerminalToken)
                .WithMany(nonTerminalToken => nonTerminalToken.AnalyzerNonTerminalTokens)
                .HasForeignKey(analyzerNonTerminalToken => analyzerNonTerminalToken.NonTerminalTokenId);
        }
    }
}