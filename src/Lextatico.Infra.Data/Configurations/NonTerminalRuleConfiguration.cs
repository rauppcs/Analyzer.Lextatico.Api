using Lextatico.Domain.Models;
using Lextatico.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lextatico.Infra.Data.Configurations
{
    public class NonTerminalRuleConfiguration : IEntityTypeConfiguration<NonTerminalRule>
    {
        public void Configure(EntityTypeBuilder<NonTerminalRule> builder)
        {
            builder.DefineDefaultFields();
            
            throw new System.NotImplementedException();
        }
    }
}
