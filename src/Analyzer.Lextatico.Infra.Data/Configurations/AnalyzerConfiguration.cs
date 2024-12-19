using Analyzer.Lextatico.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AnalyzerModel = Analyzer.Lextatico.Domain.Models.Analyzer;

namespace Analyzer.Lextatico.Infra.Data.Configurations
{
    public class AnalyzerConfiguration : IEntityTypeConfiguration<AnalyzerModel>
    {
        public void Configure(EntityTypeBuilder<AnalyzerModel> builder)
        {
            builder.DefineDefaultFields();

            builder.Property(model => model.Name)
                .HasColumnType("VARCHAR(50)")
                .IsRequired();

            builder.HasOne(analyzer => analyzer.ApplicationUser)
                .WithMany(applicationUser => applicationUser.Analyzers)
                .HasForeignKey(analyzer => analyzer.ApplicationUserId);
        }
    }
}
