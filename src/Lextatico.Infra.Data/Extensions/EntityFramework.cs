using Lextatico.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lextatico.Infra.Data.Extensions
{
    public static class EntityFramework
    {
        /// <summary>
        /// Define some default fields for the model.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="nameColnumnId">Property name Id for the bank. Default: "Id"</param>
        /// <typeparam name="TEntidade">Type of model to be defined.</typeparam>
        public static void DefineDefaultFields<TEntidade>(this EntityTypeBuilder<TEntidade> builder, string tableName, string nameColnumnId = "Id") where TEntidade : BaseModel
        {
            builder.ToTable(tableName);

            builder.Property(model => model.Id)
                .HasColumnName(nameColnumnId)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(model => model.CreatedAt)
                .HasColumnType("DATETIME");

            builder.Property(model => model.UpdatedAt)
                .HasColumnType("DATETIME");
        }
    }
}