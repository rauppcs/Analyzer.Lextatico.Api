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
    public class NonTerminalTokenRuleConfiguration : IEntityTypeConfiguration<NonTerminalTokenRule>
    {
        public void Configure(EntityTypeBuilder<NonTerminalTokenRule> builder)
        {
            builder.DefineDefaultFields();

            builder.Property(nonTerminalTokenRule => nonTerminalTokenRule.Name)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(nonTerminalTokenRule => nonTerminalTokenRule.Sequence)
                .HasColumnType("INT")
                .IsRequired();

            builder.HasOne(nonTerminalTokenRule => nonTerminalTokenRule.NonTerminalToken)
                .WithMany(nonTerminalToken => nonTerminalToken.NonTerminalTokenRules)
                .HasForeignKey(nonTerminalTokenRule => nonTerminalTokenRule.NonTerminalTokenId);
        }
    }
}
