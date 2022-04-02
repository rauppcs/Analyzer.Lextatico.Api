using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Analyzer.Lextatico.Domain.Models;
using System.Reflection;
using AnalyzerModel = Analyzer.Lextatico.Domain.Models.Analyzer;
using Analyzer.Lextatico.Domain.Interfaces.Repositories;

namespace Analyzer.Lextatico.Infra.Data.Context
{
    public class LextaticoContext : DbContext, IContextDb, IUnityOfWork
    {
        public LextaticoContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ApplicationUser> AspNetUsers { get; set; }

        public DbSet<AnalyzerModel> Analyzers { get; set; }

        public DbSet<AnalyzerTerminalToken> AnalyzerTerminalTokens { get; set; }

        public DbSet<NonTerminalToken> NonTerminalTokens { get; set; }

        public DbSet<NonTerminalTokenRule> NonTerminalTokenRules { get; set; }

        public DbSet<NonTerminalTokenRuleClause> NonTerminalTokenRuleClauses { get; set; }

        public DbSet<TerminalToken> TerminalTokens { get; set; }

        public bool ActiveTransaction => CurrentTransaction != null;

        public IDbContextTransaction CurrentTransaction { get; private set; }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var rows = await SaveChangesAsync(cancellationToken);

            return rows > 0;
        }

        public async Task<IDbContextTransaction> StartTransactionAsync()
        {
            if (!(CurrentTransaction is null)) return null;

            CurrentTransaction = await Database.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted);

            return CurrentTransaction;
        }

        public async Task SubmitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction is null) throw new ArgumentNullException(nameof(transaction));

            if (transaction != CurrentTransaction) throw new InvalidOperationException($"{transaction.TransactionId} não é a transação atual.");

            await SaveChangesAsync();

            await transaction.CommitAsync();
        }

        public async Task UndoTransaction(IDbContextTransaction transaction = null)
        {
            if (transaction == null)
                transaction = CurrentTransaction;

            await transaction.RollbackAsync();
        }

        public async Task DiscardCurrentTransactionAsync()
        {
            if (CurrentTransaction is null) return;

            await CurrentTransaction.DisposeAsync();

            CurrentTransaction = null;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.Load("Analyzer.Lextatico.Infra.Data"));

            base.OnModelCreating(builder);
        }

        public IExecutionStrategy CreateExecutionStrategy()
        {
            return Database.CreateExecutionStrategy();
        }
    }
}
