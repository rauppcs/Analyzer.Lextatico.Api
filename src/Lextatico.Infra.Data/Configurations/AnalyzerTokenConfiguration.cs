using Lextatico.Domain.Models;
using Lextatico.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lextatico.Infra.Data.Configurations
{
    public class AnalyzerTokenConfiguration : IEntityTypeConfiguration<AnalyzerToken>
    {
        public void Configure(EntityTypeBuilder<AnalyzerToken> builder)
        {
            builder.DefineDefaultFields(nameof(AnalyzerToken));

            builder.Property(analyzerToken => analyzerToken.IdAnalyzer)
                .IsRequired();

            builder.Property(analyzerToken => analyzerToken.IdToken)
                .IsRequired();

            builder.HasOne(analyzerToken => analyzerToken.Analyzer)
                .WithMany(analyzer => analyzer.AnalyzerTokens)
                .HasForeignKey(analyzerToken => analyzerToken.IdAnalyzer);

            builder.HasOne(analyzerToken => analyzerToken.TerminalToken)
                .WithMany(terminalToken => terminalToken.AnalyzerTokens)
                .HasForeignKey(analyzerToken => analyzerToken.IdToken);
        }
    }
}
