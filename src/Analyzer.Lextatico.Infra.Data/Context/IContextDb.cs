using System.Threading.Tasks;
using Analyzer.Lextatico.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace Analyzer.Lextatico.Infra.Data.Context
{
    public interface IContextDb : IUnityOfWork
    {
        bool ActiveTransaction { get; }

        IDbContextTransaction CurrentTransaction { get; }

        Task<IDbContextTransaction> StartTransactionAsync();

        IExecutionStrategy CreateExecutionStrategy();

        Task SubmitTransactionAsync(IDbContextTransaction transaction);

        Task UndoTransaction(IDbContextTransaction transaction);
    }
}
