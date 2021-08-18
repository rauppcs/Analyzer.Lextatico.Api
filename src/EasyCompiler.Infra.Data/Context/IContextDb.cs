using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace EasyCompiler.Infra.Data.Context
{
    public interface IContextDb : IUnityOfWork
    {
        bool ActiveTransaction { get; }

        IDbContextTransaction CurrentTransaction { get; }

        Task<IDbContextTransaction> StartTransactionAsync();

        IExecutionStrategy CreateExecutionStrategy();

        Task SubmitTransactionAsync(IDbContextTransaction transaction);

        void UndoTransaction();
    }
}
