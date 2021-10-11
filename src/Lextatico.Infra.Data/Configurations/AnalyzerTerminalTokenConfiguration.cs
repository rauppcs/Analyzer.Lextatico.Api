using Lextatico.Domain.Models;
using Lextatico.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lextatico.Infra.Data.Configurations
{
    public class AnalyzerTerminalTokenConfiguration : IEntityTypeConfiguration<AnalyzerTerminalToken>
    {
        public void Configure(EntityTypeBuilder<AnalyzerTerminalToken> builder)
        {
            builder.DefineDefaultFields(nameof(AnalyzerTerminalToken));

            builder.Property(analyzerToken => analyzerToken.IdAnalyzer)
                .IsRequired();

            builder.Property(analyzerToken => analyzerToken.IdTerminalToken)
                .IsRequired();

            builder.HasIndex(analyzerToken => new { analyzerToken.IdAnalyzer, analyzerToken.IdTerminalToken });

            builder.HasOne(analyzerToken => analyzerToken.Analyzer)
                .WithMany(analyzer => analyzer.AnalyzerTokens)
                .HasForeignKey(analyzerToken => analyzerToken.IdAnalyzer);

            builder.HasOne(analyzerToken => analyzerToken.TerminalToken)
                .WithMany(terminalToken => terminalToken.AnalyzerTokens)
                .HasForeignKey(analyzerToken => analyzerToken.IdTerminalToken);
        }
    }
}
