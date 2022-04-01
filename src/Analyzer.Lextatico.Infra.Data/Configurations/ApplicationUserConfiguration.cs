using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Analyzer.Lextatico.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Analyzer.Lextatico.Infra.Data.Extensions;

namespace Analyzer.Lextatico.Infra.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.DefineDefaultFields("AspNetUsers");

            builder.Property(applicationUser => applicationUser.Name)
                .HasColumnType("VARCHAR(256)")
                .IsRequired();

            builder.Property(applicationUser => applicationUser.UserName)
                .HasColumnType("VARCHAR(256)")
                .IsRequired();

            builder.Property(applicationUser => applicationUser.Email)
                .HasColumnType("VARCHAR(256)")
                .IsRequired();
        }
    }
}
