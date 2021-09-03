using Lextatico.Domain.Models;
using Lextatico.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lextatico.Infra.Data.Configurations
{
    public class NonTerminalClauseConfiguration : IEntityTypeConfiguration<NonTerminalClause>
    {
        public void Configure(EntityTypeBuilder<NonTerminalClause> builder)
        {
            builder.DefineDefaultFields();

            throw new System.NotImplementedException();
        }
    }
}
