using Lextatico.Domain.Models;
using Lextatico.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lextatico.Infra.Data.Configurations
{
    public class RefreshTokenModelConfiguration : IEntityTypeConfiguration<RefreshTokenModel>
    {
        public void Configure(EntityTypeBuilder<RefreshTokenModel> builder)
        {
            builder.DefineDefaultFields("RefreshToken");

            builder.Property(refreshToken => refreshToken.Token)
                .HasColumnType("VARCHAR(32)")
                .IsRequired();

            builder.Property(refreshToken => refreshToken.TokenExpiration)
                .HasColumnType("DATETIME")
                .IsRequired();

            builder.HasIndex(refreshToken => new { refreshToken.Token, refreshToken.TokenExpiration });

            builder.HasOne(refreshToken => refreshToken.ApplicationUser)
                .WithMany(applicationUser => applicationUser.RefreshTokens)
                .HasForeignKey(refreshToken => refreshToken.IdApplicationUser);
        }
    }
}