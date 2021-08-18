using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;

namespace EasyCompiler.Infra.Data.Context
{
    public class EasyCompilerContext : IdentityDbContext, IContextDb
    {
        public EasyCompilerContext(DbContextOptions options) : base(options)
        {
        }

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

            try
            {
                await SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (System.Exception)
            {
                // _logger TODO: implementar logger

                UndoTransaction();

                throw;
            }
            finally
            {
                await DiscardCurrentTransactionAsync();
            }
        }

        public void UndoTransaction()
        {
            throw new NotImplementedException();
        }

        private async Task DiscardCurrentTransactionAsync()
        {
            if (CurrentTransaction is null) return;

            await CurrentTransaction.DisposeAsync();

            CurrentTransaction = null;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // builder.ApplyConfigurationsFromAssembly(Assembly.Load("EasyCompiler.Infra.Data"));

            base.OnModelCreating(builder);
        }

        public IExecutionStrategy CreateExecutionStrategy()
        {
            return Database.CreateExecutionStrategy();
        }
    }
}
