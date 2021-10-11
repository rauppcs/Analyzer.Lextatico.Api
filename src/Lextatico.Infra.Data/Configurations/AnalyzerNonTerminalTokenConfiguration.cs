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
            builder.DefineDefaultFields(nameof(AnalyzerNonTerminalToken));

            builder.Property(analyzerToken => analyzerToken.IdAnalyzer)
               .IsRequired();

            builder.Property(analyzerToken => analyzerToken.IdNonTerminalToken)
                .IsRequired();

            builder.HasIndex(analyzerToken => new { analyzerToken.IdAnalyzer, analyzerToken.IdNonTerminalToken });

            builder.HasOne(analyzerNonTerminalToken => analyzerNonTerminalToken.Analyzer)
                .WithMany(analyzer => analyzer.AnalyzerNonTerminalTokens)
                .HasForeignKey(analyzerToken => analyzerToken.IdAnalyzer);

            builder.HasOne(analyzerNonTerminalToken => analyzerNonTerminalToken.NonTerminalToken)
                .WithMany(nonTerminalToken => nonTerminalToken.AnalyzerNonTerminalTokens)
                .HasForeignKey(analyzerNonTerminalToken => analyzerNonTerminalToken.IdNonTerminalToken);
        }
    }
}