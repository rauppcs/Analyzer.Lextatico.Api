﻿// <auto-generated />
using System;
using Analyzer.Lextatico.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Analyzer.Lextatico.Infra.Data.Migrations
{
    [DbContext(typeof(LextaticoContext))]
    partial class LextaticoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Analyzer.Lextatico.Domain.Models.Analyzer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<Guid>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Analyzer", (string)null);
                });

            modelBuilder.Entity("Analyzer.Lextatico.Domain.Models.AnalyzerTerminalToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<Guid>("AnalyzerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("TerminalTokenId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.HasIndex("TerminalTokenId");

                    b.HasIndex("AnalyzerId", "TerminalTokenId");

                    b.ToTable("AnalyzerTerminalToken", (string)null);
                });

            modelBuilder.Entity("Analyzer.Lextatico.Domain.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(256)");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(256)");

                    b.HasKey("Id");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Analyzer.Lextatico.Domain.Models.NonTerminalToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<Guid>("AnalyzerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("IsStart")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIT")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("Sequence")
                        .HasColumnType("INT");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.HasIndex("AnalyzerId");

                    b.ToTable("NonTerminalToken", (string)null);
                });

            modelBuilder.Entity("Analyzer.Lextatico.Domain.Models.NonTerminalTokenRule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<Guid>("NonTerminalTokenId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Sequence")
                        .HasColumnType("INT");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.HasIndex("NonTerminalTokenId");

                    b.ToTable("NonTerminalTokenRule", (string)null);
                });

            modelBuilder.Entity("Analyzer.Lextatico.Domain.Models.NonTerminalTokenRuleClause", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("IsTerminalToken")
                        .HasColumnType("BIT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<Guid?>("NonTerminalTokenId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("NonTerminalTokenRuleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Sequence")
                        .HasColumnType("INT");

                    b.Property<Guid?>("TerminalTokenId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.HasIndex("NonTerminalTokenId");

                    b.HasIndex("NonTerminalTokenRuleId");

                    b.HasIndex("TerminalTokenId");

                    b.ToTable("NonTerminalTokenRuleClause", (string)null);
                });

            modelBuilder.Entity("Analyzer.Lextatico.Domain.Models.TerminalToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id")
                        .HasDefaultValueSql("NEWSEQUENTIALID()");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("IdentifierType")
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Lexeme")
                        .IsRequired()
                        .HasColumnType("VARCHAR(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<string>("Resume")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200)");

                    b.Property<string>("TokenType")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("DATETIME")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("ViewName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)");

                    b.HasKey("Id");

                    b.ToTable("TerminalToken", (string)null);
                });

            modelBuilder.Entity("Analyzer.Lextatico.Domain.Models.Analyzer", b =>
                {
                    b.HasOne("Analyzer.Lextatico.Domain.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Analyzers")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Analyzer.Lextatico.Domain.Models.AnalyzerTerminalToken", b =>
                {
                    b.HasOne("Analyzer.Lextatico.Domain.Models.Analyzer", "Analyzer")
                        .WithMany("AnalyzerTerminalTokens")
                        .HasForeignKey("AnalyzerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Analyzer.Lextatico.Domain.Models.TerminalToken", "TerminalToken")
                        .WithMany("AnalyzerTokens")
                        .HasForeignKey("TerminalTokenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Analyzer");

                    b.Navigation("TerminalToken");
                });

            modelBuilder.Entity("Analyzer.Lextatico.Domain.Models.NonTerminalToken", b =>
                {
                    b.HasOne("Analyzer.Lextatico.Domain.Models.Analyzer", "Analyzer")
                        .WithMany("NonTerminalTokens")
                        .HasForeignKey("AnalyzerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Analyzer");
                });

            modelBuilder.Entity("Analyzer.Lextatico.Domain.Models.NonTerminalTokenRule", b =>
                {
                    b.HasOne("Analyzer.Lextatico.Domain.Models.NonTerminalToken", "NonTerminalToken")
                        .WithMany("NonTerminalTokenRules")
                        .HasForeignKey("NonTerminalTokenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NonTerminalToken");
                });

            modelBuilder.Entity("Analyzer.Lextatico.Domain.Models.NonTerminalTokenRuleClause", b =>
                {
                    b.HasOne("Analyzer.Lextatico.Domain.Models.NonTerminalToken", "NonTerminalToken")
                        .WithMany("NonTerminalTokenRuleClauses")
                        .HasForeignKey("NonTerminalTokenId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Analyzer.Lextatico.Domain.Models.NonTerminalTokenRule", "NonTerminalTokenRule")
                        .WithMany("NonTerminalTokenRuleClauses")
                        .HasForeignKey("NonTerminalTokenRuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Analyzer.Lextatico.Domain.Models.TerminalToken", "TerminalToken")
                        .WithMany("NonTerminalTokenRuleClauses")
                        .HasForeignKey("TerminalTokenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NonTerminalToken");

                    b.Navigation("NonTerminalTokenRule");

                    b.Navigation("TerminalToken");
                });

            modelBuilder.Entity("Analyzer.Lextatico.Domain.Models.Analyzer", b =>
                {
                    b.Navigation("AnalyzerTerminalTokens");

                    b.Navigation("NonTerminalTokens");
                });

            modelBuilder.Entity("Analyzer.Lextatico.Domain.Models.ApplicationUser", b =>
                {
                    b.Navigation("Analyzers");
                });

            modelBuilder.Entity("Analyzer.Lextatico.Domain.Models.NonTerminalToken", b =>
                {
                    b.Navigation("NonTerminalTokenRuleClauses");

                    b.Navigation("NonTerminalTokenRules");
                });

            modelBuilder.Entity("Analyzer.Lextatico.Domain.Models.NonTerminalTokenRule", b =>
                {
                    b.Navigation("NonTerminalTokenRuleClauses");
                });

            modelBuilder.Entity("Analyzer.Lextatico.Domain.Models.TerminalToken", b =>
                {
                    b.Navigation("AnalyzerTokens");

                    b.Navigation("NonTerminalTokenRuleClauses");
                });
#pragma warning restore 612, 618
        }
    }
}
