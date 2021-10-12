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
    public class NonTerminalTokenRuleClauseConfiguration : IEntityTypeConfiguration<NonTerminalTokenRuleClause>
    {
        public void Configure(EntityTypeBuilder<NonTerminalTokenRuleClause> builder)
        {
            builder.DefineDefaultFields(nameof(NonTerminalTokenRuleClause));

            builder.Property(nonTerminalTokenRuleClause => nonTerminalTokenRuleClause.Name)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.Property(nonTerminalTokenRuleClause => nonTerminalTokenRuleClause.Sequence)
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(nonTerminalTokenRuleClause => nonTerminalTokenRuleClause.IsTerminalToken)
                .HasColumnType("BIT")
                .IsRequired();

            builder.HasOne(nonTerminalTokenRuleClause => nonTerminalTokenRuleClause.NonTerminalToken)
                .WithMany(nonTerminalToken => nonTerminalToken.NonTerminalTokenRuleClauses)
                .HasForeignKey(nonTerminalTokenRuleClause => nonTerminalTokenRuleClause.IdNonTerminalToken)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(nonTerminalTokenRuleClause => nonTerminalTokenRuleClause.TerminalToken)
                .WithMany(terminalToken => terminalToken.NonTerminalTokenRuleClauses)
                .HasForeignKey(nonTerminalTokenRuleClause => nonTerminalTokenRuleClause.IdTerminalToken);

            builder.HasOne(nonTerminalTokenRuleClause => nonTerminalTokenRuleClause.NonTerminalTokenRule)
                .WithMany(nonTerminalTokenRule => nonTerminalTokenRule.NonTerminalTokenRuleClauses)
                .HasForeignKey(nonTerminalTokenRuleClause => nonTerminalTokenRuleClause.IdNonTerminalTokenRule);
        }
    }
}