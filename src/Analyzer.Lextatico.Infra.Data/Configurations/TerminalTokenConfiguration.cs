using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Analyzer.Lextatico.Domain.Models;
using Analyzer.Lextatico.Infra.Data.Extensions;

namespace Analyzer.Lextatico.Infra.Data.Configurations
{
    public class TerminalTokenConfiguration : IEntityTypeConfiguration<TerminalToken>
    {
        public void Configure(EntityTypeBuilder<TerminalToken> builder)
        {
            builder.DefineDefaultFields();

            builder.Property(terminalToken => terminalToken.Name)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(terminalToken => terminalToken.ViewName)
                .HasColumnType("VARCHAR(20)")
                .IsRequired();

            builder.Property(terminalToken => terminalToken.Resume)
                .HasColumnType("VARCHAR(200)");

            builder.Property(terminalToken => terminalToken.Lexeme)
                .HasColumnType("VARCHAR(30)")
                .IsRequired();

            builder.Property(terminalToken => terminalToken.TokenType)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(terminalToken => terminalToken.IdentifierType)
                .HasColumnType("VARCHAR(50)")
                .IsRequired(false);
        }
    }
}
