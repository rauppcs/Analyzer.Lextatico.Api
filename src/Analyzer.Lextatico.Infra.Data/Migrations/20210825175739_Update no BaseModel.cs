using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Analyzer.Lextatico.Infra.Data.Migrations
{
    public partial class UpdatenoBaseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "RefreshToken",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "RefreshToken",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "RefreshToken",
                type: "DATETIME",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "RefreshToken",
                type: "DATETIME",
                nullable: false,
                defaultValueSql: "'1753-01-01 00:00:00.000'",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "RefreshToken",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "RefreshToken",
                newName: "created_at");

            migrationBuilder.AlterColumn<DateTime>(
                name: "updated_at",
                table: "RefreshToken",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "RefreshToken",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME");
        }
    }
}
