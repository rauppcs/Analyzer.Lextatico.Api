using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Analyzer.Lextatico.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class new_changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NonTerminalTokenRuleClause_TerminalToken_TerminalTokenId",
                table: "NonTerminalTokenRuleClause");

            migrationBuilder.AddForeignKey(
                name: "FK_NonTerminalTokenRuleClause_TerminalToken_TerminalTokenId",
                table: "NonTerminalTokenRuleClause",
                column: "TerminalTokenId",
                principalTable: "TerminalToken",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NonTerminalTokenRuleClause_TerminalToken_TerminalTokenId",
                table: "NonTerminalTokenRuleClause");

            migrationBuilder.AddForeignKey(
                name: "FK_NonTerminalTokenRuleClause_TerminalToken_TerminalTokenId",
                table: "NonTerminalTokenRuleClause",
                column: "TerminalTokenId",
                principalTable: "TerminalToken",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
