using Lextatico.Domain.Models;
using Lextatico.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lextatico.Infra.Data.Configurations
{
    public class AnalyzerConfiguration : IEntityTypeConfiguration<Analyzer>
    {
        public void Configure(EntityTypeBuilder<Analyzer> builder)
        {
            builder.DefineDefaultFields();

            throw new System.NotImplementedException();
        }
    }
}
