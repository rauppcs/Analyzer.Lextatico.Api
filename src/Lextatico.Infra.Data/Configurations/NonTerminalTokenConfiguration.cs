using Lextatico.Domain.Models;
using Lextatico.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lextatico.Infra.Data.Configurations
{
    public class NonTerminalTokenConfiguration : IEntityTypeConfiguration<NonTerminalToken>
    {
        public void Configure(EntityTypeBuilder<NonTerminalToken> builder)
        {
            builder.DefineDefaultFields();
            
            throw new System.NotImplementedException();
        }
    }
}
