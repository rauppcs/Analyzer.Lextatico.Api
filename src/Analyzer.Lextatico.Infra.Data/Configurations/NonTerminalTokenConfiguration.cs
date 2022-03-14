using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Analyzer.Lextatico.Domain.Models;
using Analyzer.Lextatico.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Analyzer.Lextatico.Infra.Data.Configurations
{
    public class NonTerminalTokenConfiguration : IEntityTypeConfiguration<NonTerminalToken>
    {
        public void Configure(EntityTypeBuilder<NonTerminalToken> builder)
        {
            builder.DefineDefaultFields();

            builder.Property(nonTerminalToken => nonTerminalToken.Name)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(nonTerminalToken => nonTerminalToken.Sequence)
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(nonTerminalToken => nonTerminalToken.IsStart)
                .HasColumnType("BIT")
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasOne(nonTerminalToken => nonTerminalToken.Analyzer)
                .WithMany(analyzer => analyzer.NonTerminalTokens)
                .HasForeignKey(nonTerminalToken => nonTerminalToken.AnalyzerId);
        }
    }
}
