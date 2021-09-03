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
            builder.DefineDefaultFields();

            throw new System.NotImplementedException();
        }
    }
}
