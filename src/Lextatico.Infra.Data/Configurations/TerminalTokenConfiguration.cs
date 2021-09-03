using Lextatico.Domain.Models;
using Lextatico.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lextatico.Infra.Data.Configurations
{
    public class TerminalTokenConfiguration : IEntityTypeConfiguration<TerminalToken>
    {
        public void Configure(EntityTypeBuilder<TerminalToken> builder)
        {
            builder.DefineDefaultFields();
            
            throw new System.NotImplementedException();
        }
    }
}
