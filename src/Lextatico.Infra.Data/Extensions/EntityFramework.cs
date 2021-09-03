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
        /// <param name="nameColumnId">Property name Id for the database. Default: "Id"</param>
        /// <typeparam name="T">Type of model to be defined.</typeparam>
        public static void DefineDefaultFields<T>(this EntityTypeBuilder<T> builder, string tableName = nameof(T), string nameColumnId = "Id") where T : Base
        {
            builder.ToTable(tableName);

            builder.Property(model => model.Id)
                .HasColumnName(nameColumnId)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder.Property(model => model.CreatedAt)
                .HasColumnType("DATETIME");

            builder.Property(model => model.UpdatedAt)
                .HasColumnType("DATETIME");
        }
    }
}
